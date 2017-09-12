using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.AspNetCore.Mvc;

using Application;
using Domain.RepositoryInterfaces;
using Repositories;
using System.Reflection;
using SharedKernel;
using Domain.EventHandlers;
using DependencyResolver;
using App.WebAPI.Middleware;

using Infra.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Domain.Enums;
using App.WebAPI.Swagger;
using App.WebAPI.AutoMapperConfig;
using System.Security.Claims;
using System.Linq;
using Application.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;

namespace App.WebAPI
{
    /// <summary>
    /// Startup da webapi
    /// </summary>
    public class Startup
    {
        private readonly Container container = ContainerFactory.Container;

        private IConfigurationRoot _config;

        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Objeto de configuração do ASP.NET
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configuração dos serviços
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            #region Autenticação e Autorização

            services.AddAuthentication((options) =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidAudience = Configuration["Tokens:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                };
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.Audience = Configuration["Tokens:Audience"];
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "Administradores", 
                    p => p.RequireClaim("Profile", PerfilUsuario.Administradores.ToString()));
            });

            #endregion

            IntegrateSimpleInjector(services);

            #region Swagger Doc
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Asp Net Core Testes",
                    Description = "Modelo de implementação DDD utilizando ASP Net Core 2.0",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Fernando Barbieri", Email = "fbarbieri@viceri.com.br", Url = "" }
                });

                // Usar a documentação XML dos métodos.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "App.WebAPI.xml");
                options.IncludeXmlComments(xmlPath);
                options.OperationFilter<AuthorizationHeaderOperationFilter>();
            });

            #endregion

        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
              .AddEnvironmentVariables();

            _config = builder.Build();


            #region configuração de container ioc

            InitializeContainer(app);

            // Registro dos middlewares
            container.Register<ApiRequestMiddleware>();
            container.Register<ErrorHandlerMiddleware>();

            container.Verify();

            #endregion

            // Aplica os middlewares
            app.Use((c, next) => container.GetInstance<ApiRequestMiddleware>().Invoke(c, next));
            app.Use((c, next) => container.GetInstance<ErrorHandlerMiddleware>().Invoke(c, next));


            #region Swagger Middleware

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Asp Net Core Testes API V1");
            });

            #endregion

            // Aplica Autenticação
            app.UseAuthentication();

            // Aplica o MVC
            app.UseMvcWithDefaultRoute();
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            // Configurações
            container.RegisterSingleton(typeof(IConfigurationRoot), _config);
            container.RegisterSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            // Services (Presentation)
            container.Register<IUsuarioApplicationService, UsuarioApplicationService>(Lifestyle.Scoped);
            container.Register<IPedidoApplicationService, PedidoApplicationService>(Lifestyle.Scoped);
            container.Register<IClienteApplicationService, ClienteApplicationService>(Lifestyle.Scoped);
            container.Register<ILoginApplicationService, LoginApplicationService>(Lifestyle.Scoped);


            // Repositories
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IPedidoRepository, PedidoRepository>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<ITenantRepository, TenantRepository>(Lifestyle.Scoped);

            // Tenho o usuario logado disponível para injetar em qualquer classe.
            container.Register(typeof(UserInfo),() => ObterUserInfo(), Lifestyle.Scoped);

            //DbContexts
            //TODO: Verificar se está sendo realizado o dispose.
            container.Register(() => 
            {
                var options = new DbContextOptionsBuilder<AdminContext>();
                options.UseSqlServer(GetDatabaseForUser());
                return new AdminContext(options.Options);
            }, Lifestyle.Scoped);

            container.Register(() =>
            {
                var options = new DbContextOptionsBuilder<LojaContext>();
                options.UseSqlServer(GetDatabaseForUser());
                return new LojaContext(options.Options);
            }, Lifestyle.Scoped);

            container.Register(() =>
            {
                var options = new DbContextOptionsBuilder<TenantManagementContext>();
                options.UseSqlServer(Configuration.GetConnectionString("Meritus"));
                return new TenantManagementContext(options.Options);
            }, Lifestyle.Scoped);

            // Registro de todos os event handlers
            // Observação: Por questões de performance, registrar apenas uma classe por projeto
            Assembly[] assemblies = new[] {
                 typeof(IHandle<>).GetTypeInfo().Assembly // Shared Kernel
               , typeof(UsuarioCriadoEventHandler).GetTypeInfo().Assembly // Domain
               , typeof(Application.EventHandlers.EmailPedidoEnviadoHandler).GetTypeInfo().Assembly // Application
               , typeof(Repositories.EventHandlers.UserCreatedEventHandler).GetTypeInfo().Assembly // Repositories
            };
            container.RegisterCollection(typeof(IHandle<>), assemblies);
            
            // Automapper
            container.RegisterSingleton(() => container.GetInstance<MapperProvider>().GetMapper());
            
            // Cross-wire ASP.NET services (if any). For instance:
            container.CrossWire<ILoggerFactory>(app);
        }
        
        private string GetDatabaseForUser()
        {
            var tenant = ObterTenantUsuario();
            if (tenant != null)
            {
                var cnn = Configuration.GetConnectionString("Tenant");
                return cnn.Replace("{tenant}", tenant);
            }
            return Configuration.GetConnectionString("Meritus");
        }

        /// <summary>
        /// Retorna o dominio do email do usuario logado.
        /// OBS: Esse modelo de obter os dados de tenant não me parece adequado. 
        /// Estudar se deve usar outro modelo ou potenciais problemas com isso.
        /// </summary>
        /// <returns></returns>
        private string ObterTenantUsuario()
        {
            var usuario = container.GetInstance<UserInfo>();
            return usuario?.Tenant;
        }

        private UserInfo ObterUserInfo()
        {
            var userInfo = new UserInfo();

            userInfo.Usuario = ObterUsuario();
            userInfo.Tenant = userInfo.Usuario?.Email.Split('@')[1];

            return userInfo;
        }


        private UsuarioViewModel ObterUsuario()
        {
            var httpContext = container.GetInstance<IHttpContextAccessor>();

            if (httpContext.HttpContext == null
                || httpContext.HttpContext.User == null
                || httpContext.HttpContext.User.Identity == null)
                return null;

            var usuario = new UsuarioViewModel();

            var userIdentity = httpContext.HttpContext.User.Identity;

            //TODO: Deve ter um jeito melhor de fazer isso:
            var identity = userIdentity as ClaimsIdentity;
            if (identity == null)
                return null;

            var claims = identity.Claims.ToList();
            var id = GetClaimValue(claims, JwtRegisteredClaimNames.Jti);

            usuario.Id = int.Parse(id);
            usuario.Nome = GetClaimValue(claims, ClaimTypes.GivenName);
            usuario.Email = GetClaimValue(claims, ClaimTypes.Email);
            usuario.Perfil = GetClaimValue(claims, "Profile");

            return usuario;
        }

        private string GetClaimValue(IList<Claim> claims, string type)
        {
            return claims.FirstOrDefault(c => c.Type == type)?.Value;
        }


    }
}

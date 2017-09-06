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
                options.AddPolicy("Administradores", p => p.RequireClaim("Profile", PerfilUsuario.Administradores.ToString()));
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

            // Aplica os middlewares
            app.Use((c, next) => container.GetInstance<ApiRequestMiddleware>().Invoke(c, next));
            app.Use((c, next) => container.GetInstance<ErrorHandlerMiddleware>().Invoke(c, next));

            #endregion

            #region Swagger Middleware

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
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
            
            // Services (Presentation)
            //container.Register<IUserService, UserService>(Lifestyle.Scoped);

            // Registro das interfaces do sistema:
            container.Register<IUsuarioApplicationService, UsuarioApplicationService>(Lifestyle.Scoped);
            container.Register<IPedidoApplicationService, PedidoApplicationService>(Lifestyle.Scoped);
            container.Register<IClienteApplicationService, ClienteApplicationService>(Lifestyle.Scoped);
            
            // Repositories
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IPedidoRepository, PedidoRepository>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            
            //DbContexts
            //TODO: Verificar se está sendo realizado o dispose.
            container.Register(() => 
            {
                var options = new DbContextOptionsBuilder<AdminContext>();
                options.UseSqlServer(Configuration.GetConnectionString("Meritus"));
                return new AdminContext(options.Options);
            }, Lifestyle.Scoped);

            container.Register(() =>
            {
                var options = new DbContextOptionsBuilder<LojaContext>();
                options.UseSqlServer(Configuration.GetConnectionString("Meritus"));
                return new LojaContext(options.Options);
            }, Lifestyle.Scoped);
            
            // Registro de todos os event handlers
            // Observação: Por questões de performance, registrar apenas uma classe por projeto
            Assembly[] assemblies = new[] {
                 typeof(IHandle<>).GetTypeInfo().Assembly // Shared Kernel
               , typeof(UsuarioCriadoEventHandler).GetTypeInfo().Assembly // Domain
               , typeof(Application.EventHandlers.EmailPedidoEnviadoHandler).GetTypeInfo().Assembly // Application
               , typeof(Repositories.EventHandlers.UserCreatedEventHandler).GetTypeInfo().Assembly // Application
            };

            container.RegisterCollection(typeof(IHandle<>), assemblies);
            
            // Automapper
            container.RegisterSingleton(() => container.GetInstance<MapperProvider>().GetMapper());
            
            // Cross-wire ASP.NET services (if any). For instance:
            container.CrossWire<ILoggerFactory>(app);
        }
    }
}

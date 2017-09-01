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
using SimpleInjector.Integration.AspNetCore;
using SimpleInjector.Integration.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain.RepositoryInterfaces;
using Repositories;
using System.Reflection;
using SharedKernel;
using Domain.EventHandlers;
using DependencyResolver;
using App.WebAPI.Middleware;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Infra.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;

namespace App.WebAPI
{
    public class Startup
    {

        private Container container = ContainerFactory.Container;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            IntegrateSimpleInjector(services);
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            #region configuração de container ioc
            InitializeContainer(app);

            container.Register<ApiRequestMiddleware>();

            container.Verify();

            app.Use((c, next) => container.GetInstance<ApiRequestMiddleware>().Invoke(c, next));

            #endregion

            /*
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }*/

            app.UseExceptionHandler(
                 options =>
                 {
                     options.Run(
                     async context =>
                     {
                         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                         context.Response.ContentType = "text/html";
                         var ex = context.Features.Get<IExceptionHandlerFeature>();
                         if (ex != null)
                         {
                             var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace }";
                             await context.Response.WriteAsync(err).ConfigureAwait(false);
                         }
                     });
                 }
                );


            app.UseMvc();
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

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
            container.Register<AdminContext>(() => 
            {
                var options = new DbContextOptionsBuilder<AdminContext>();
                options.UseSqlServer(Configuration.GetConnectionString("Meritus"));
                return new AdminContext(options.Options);
            }, Lifestyle.Scoped);

            container.Register<LojaContext>(() =>
            {
                var options = new DbContextOptionsBuilder<LojaContext>();
                options.UseSqlServer(Configuration.GetConnectionString("Meritus"));
                return new LojaContext(options.Options);
            }, Lifestyle.Scoped);
            
            // Registro de todos os event handlers
            // Observação: Por questões de performance, registrar apenas uma classe por projeto
            Assembly[] assemblies = new[] {
                 typeof(SharedKernel.IHandle<>).GetTypeInfo().Assembly // Shared Kernel
               , typeof(Domain.EventHandlers.UsuarioCriadoEventHandler).GetTypeInfo().Assembly // Domain
               , typeof(Application.EventHandlers.EmailPedidoEnviadoHandler).GetTypeInfo().Assembly // Application
               , typeof(Repositories.EventHandlers.UserCreatedEventHandler).GetTypeInfo().Assembly // Application
            };

            container.RegisterCollection(typeof(IHandle<>), assemblies);

            // Cross-wire ASP.NET services (if any). For instance:
            container.CrossWire<ILoggerFactory>(app);
        }
    }
}

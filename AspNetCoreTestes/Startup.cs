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
using AspNetCoreTestes.UserServices;
using AspNetCoreTestes.Middleware;
using Application;
using Domain.RepositoryInterfaces;
using Repositories;
using System.Reflection;
using SharedKernel;
using Domain.EventHandlers;
using DependencyResolver;
using Application.Interfaces;

namespace AspNetCoreTestes
{
    public class Startup
    {
        private Container container = ContainerFactory.Container;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            #region configuração de container ioc
            InitializeContainer(app);

            container.Register<RequestMiddleware>();

            container.Verify();

            app.Use((c, next) => container.GetInstance<RequestMiddleware>().Invoke(c, next));

            #endregion
            
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            // Services (interface)
            container.Register<IUserService, UserService>(Lifestyle.Scoped);

            // Registro das interfaces do sistema:
            container.Register<IUsuarioApplicationService, UsuarioApplicationService>(Lifestyle.Scoped);
            container.Register<IPedidoApplicationService, PedidoApplicationService>(Lifestyle.Scoped);

            // Repositories
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IPedidoRepository, PedidoRepository>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);

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

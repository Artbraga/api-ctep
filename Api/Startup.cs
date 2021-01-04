using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unity;
using Ioc;
using Unity.Interception;
using Microsoft.Extensions.Logging;
using Entities.Util;
using System.Reflection;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using CTEP.Repositories.Impl.Context;
using Microsoft.AspNetCore.Http;
using log4net;
using System.IO;
using log4net.Config;
using Microsoft.AspNetCore.Mvc;
using Unity.Lifetime;

namespace ctep
{
    public class Startup
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Startup));
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            RegisterLogger();
            services.AddControllers().AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.DateFormatString = ApplicationConstants.DateTimeFormat;
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHealthChecks();

            services.AddMvc()
            .AddControllersAsServices();

            log.Info("ConfigureServices - ok");
        }

        public void ConfigureContainer(IUnityContainer container)
        {
            container.AddNewExtension<Interception>();
            IHttpContextAccessor httpContextAccessor = container.Resolve<IHttpContextAccessor>();
            //container.RegisterInstance<DbContext>(new , new SingletonLifetimeManager());
            container.RegisterFactory<DbContext>((c) => new CtepContext(Configuration));
            container.RegisterRepositories();
            container.RegisterBusiness();
            log.Info("ConfigureContainer - ok");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();

            app.UseHealthChecks("/health");
            app.UseCors(option => {
                option.AllowAnyOrigin();
                option.AllowAnyHeader();
                option.AllowAnyMethod();
            });

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            log.Info("Configure - ok");
        }

        public void RegisterLogger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
    }
}

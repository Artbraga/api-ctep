using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unity;
using Ioc;
using Unity.Interception;
using Microsoft.Extensions.Logging;
using Entities.Util;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;

namespace ctep
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add<LoggingFilterAttribute>();
                options.Filters.Add<HanddleExceptionFilterAttribute>();
            }).AddJsonOptions(options =>
            {
                options.SerializerSettings.DateFormatString = ApplicationConstants.DateTimeFormat;
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
                //etc
            });
        }

        public void ConfigureContainer(IUnityContainer container)
        {
            container.AddNewExtension<Interception>();
            container.AddExtension(new Diagnostic());
            container.RegisterDbContext();
            container.RegisterRepositories();
            container.RegisterBusiness();
            container.AddExtension(new Diagnostic());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(option => {
                option.AllowAnyOrigin();
                option.AllowAnyHeader();
                option.AllowAnyMethod();
            });

            app.UseMvc();
        }
    }

    internal class LoggingFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger _log;
        public LoggingFilterAttribute(ILogger<LoggingFilterAttribute> log)
        {
            _log = log;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var version = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            _log.LogInformation("[{2}] Método {0} iniciado com os parâmetros {1}", new object[] { context.ActionDescriptor.DisplayName, JsonConvert.SerializeObject(context.ActionArguments), version });
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                _log.LogError("Método {0} levantou uma exceção: {1}", new object[] { context.ActionDescriptor.DisplayName, JsonConvert.SerializeObject(context.Exception) });
            }
            else
            {
                var result = context.Result as ObjectResult;
                const int AcceptedStatus = 202;
                if ((result != null)  && (result.Value != null) && (result.StatusCode != AcceptedStatus) && (result.Value.GetType().ReflectedType == typeof(System.Linq.Enumerable)))
                {
                    _log.LogInformation("Método {0} finalizado com o resultado {1}", new object[] { context.ActionDescriptor.DisplayName, JsonConvert.SerializeObject(context.Result.ToString()) });
                }
                else
                {
                    _log.LogInformation("Método {0} finalizado com o resultado {1}", new object[] { context.ActionDescriptor.DisplayName, JsonConvert.SerializeObject(context.Result) });
                }
            }
        }
    }

    internal class HanddleExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception != null)
            {
                context.Result = new JsonResult(context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}

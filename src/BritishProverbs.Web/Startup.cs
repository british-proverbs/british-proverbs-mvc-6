using BritishProverbs.Domain;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using BritishProverbs.Web.Middlewares;

namespace BritishProverbs.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IApplicationEnvironment appEnv, IHostingEnvironment env)
        {
            _configuration = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables("BritishProverbs-")
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {          
            services.Configure<AppSettings>(_configuration.GetSection("AppSettings"));
            services.Configure<DomainSettings>(_configuration.GetSection("Data:DbConnection"));
            services.AddSingleton<IBritishProverbsContext, BritishProverbsContext>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole();

            if (env.IsEnvironment("Development"))
            {
                app.UseErrorPage();
            }
            else
            {
                app.UseErrorHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMiddleware<VisitRecorderMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

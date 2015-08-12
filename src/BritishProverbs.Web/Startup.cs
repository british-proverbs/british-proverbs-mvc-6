using BritishProverbs.Domain;
using BritishProverbs.Web.Middlewares;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Runtime;

namespace BritishProverbs.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IApplicationEnvironment appEnv, IHostingEnvironment env)
        {
            _configuration = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(_configuration.GetConfigurationSection("AppSettings"));
            services.Configure<DomainSettings>(_configuration.GetConfigurationSection("Data:DbConnection"));
            services.AddScoped<IBritishProverbsContext, BritishProverbsContext>();
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

using CapacitorWebApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CapacitorWebApplication
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:Capacitor:ConnectionString"]));

            services.AddTransient<IResinRepository, EFResinRepository>();
            services.AddTransient<IMaterialRepository, EFMaterialRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // This extension method displays details of exceptions that occur in the 
            // application, which is useful during the development process. It should
            // not be enabled in deployed applications.
            app.UseDeveloperExceptionPage();

            // This extension method adds a simple message to HTTP responses that
            // would not otherwise have a body, such as  404 - Not Found responses. 
            app.UseStatusCodePages();

            // This extension method enables support for serving static content from
            // the wwwroot  folder.
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Material}/{action=List}/{id?}");
            });

            SeedData.EnsurePopulated(app);
        }
    }
}

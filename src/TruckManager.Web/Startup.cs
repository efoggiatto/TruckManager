using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckManager.Context;
using TruckManager.Domain;
using TruckManager.Repository;

namespace TruckManager.Web
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
            services.AddDbContextPool<TruckManagerContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("TruckDb")));

            services.AddMvc(options=> { options.EnableEndpointRouting = false; }).AddXmlSerializerFormatters();

            services.AddScoped(typeof(ITruckRepository), typeof(TruckRepository));
            services.AddScoped(typeof(ITruckModelRepository), typeof(TruckModelRepository));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{chassis?}");
            });


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}

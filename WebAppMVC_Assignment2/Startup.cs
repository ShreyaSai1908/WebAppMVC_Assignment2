using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAppMVC_Assignment2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /*these statements are needed to be added for using Sessions*/
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            /*these statements are needed to be added for using Sessions*/

            services.AddMvc(); //this is mandatory to add here for MVC projects 
            services.AddControllersWithViews();
            services.AddRazorPages();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles();   //this used so that webserver can recognize index.html file by its default name
            //app.UseStaticFiles();   //this is used so that webserver can recognize static files like html, img files, css file javascript files
            app.UseRouting();      //this is used to enable routing of user requests in the web application
            app.UseSession();      // this is mandatory for using Sessions in your Web App

            app.UseEndpoints(endpoints =>
            {
                /*
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                */


                //Need not to define endpoints for each action
                /*
                endpoints.MapControllerRoute(
                     name: "people",
                     pattern: "People",
                     defaults: new { controller = "People", action = "ViewPeople" });

                endpoints.MapControllerRoute(
                     name: "addpeople",
                     pattern: "AddPeople",
                     defaults: new { controller = "People", action = "AddPeople" });
                
                endpoints.MapControllerRoute(
                     name: "deletepeople",
                     pattern: "{action=DeletePeople}/{id?}",
                     defaults: new { controller = "People", action = "DeletePeople" });
                */

                //Endpoints should rather be more generic like these 
                endpoints.MapControllerRoute(
                     name: "Route_1",
                     pattern: "{controller}/{action}/{id?}",
                     defaults: new { controller = "PeopleOneView", action = "Add_View_People" });

                /*
                endpoints.MapControllerRoute(
                     name: "Route_2",
                     pattern: "{controller}/{action}/{id?}",
                     defaults: new { controller = "People", action = "AddPeople" });*/

            });
        }
    }
}

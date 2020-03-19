using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shoping.BLL.Service;
using Shoping.DAL.EF;
using Shoping.DAL.Entities;
using Shoping.DAL.IRepositories;
using Shoping.DAL.Repositories;

namespace ShopCar
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
    

            public void ConfigureServices(IServiceCollection services)
            {

            //подключаем конфиг из appsetting.json
            Configuration.Bind("ConnectionStrings", new Config());
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AppDBContext>(x => x.UseSqlServer(Config.ConnectionString));





            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<DataManager>();
            


            services.AddIdentity<ApplicationUser, IdentityRole>(opts => {
             //   opts.Password.RequiredLength = 5;   
              //  opts.Password.RequireNonAlphanumeric = false;   
               // opts.Password.RequireLowercase = false; 
               // opts.Password.RequireUppercase = false; 
               // opts.Password.RequireDigit = false; 
            })
               .AddEntityFrameworkStores<AppDBContext>();

                                 
            services.AddControllersWithViews();
            }


            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }
                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
            }
        
    }
}
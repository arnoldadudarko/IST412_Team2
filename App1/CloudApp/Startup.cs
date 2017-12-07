using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CloudApp.Data;
using CloudApp.Services;
using Microsoft.AspNetCore.Authentication.Facebook;

namespace CloudApp
//{
//    public class Startup
//    {
//        string _testSecret = null;
//        public Startup(IHostingEnvironment env)
//            }
//        {
//            var builder = new ConfigurationBuilder();

//            if (env.IsDevelopment())
//            {
//                builder.AddUserSecrets<Startup>();

//            Configuration = builder.Build();
//        }

//        public IConfigurationRoot Configuration { get; }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            _testSecret = Configuration["MySecret"];
//        }

//        public void Configure(IApplicationBuilder app)
//        {
//            var result = string.IsNullOrEmpty(_testSecret) ? "Null" : "Not Null";
//            app.Run(async (context) =>
//            {
//                await context.Response.WriteAsync($"Secret is {result}");
//            });
//        }
//    }
//}
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account/Manage");
                    options.Conventions.AuthorizePage("/Account/Logout");
                });
            //services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores();

            // If you want to tweak identity cookies, they no longer are part of identityOptions
            services.ConfigureApplicationCookie(o => o.LoginPath = new PathString("/login"));
            services.AddAuthentication()
                        .AddFacebook(o =>
                        {
                            o.AppId = "775398839329980";
                            o.AppSecret = "c1a488fcfbcfceda003a238378fdd7cf";
                        });

            // Register no-op EmailSender used by account confirmation and password reset during development
            // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
            services.AddSingleton<IEmailSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}

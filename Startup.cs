using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SKFWebServicesSchedular.Data;
using SKFWebServicesSchedular.Services;

namespace SKFWebServicesSchedular
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static string MasterConnectionString
        {
            get;
            private set;
        }

        public static string UserConnectionString
        {
            get;
            private set;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("SKF.User")));

            services.AddDefaultIdentity<IdentityUser>()
               .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddHangfire(Config => Config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                            .UseSimpleAssemblyNameTypeSerializer()
                            .UseDefaultTypeSerializer()
                            .UseMemoryStorage());

            services.AddHangfireServer();
            services.AddSingleton<CallApiService>();
            services.AddSingleton<SmartEdgeServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager, IServiceProvider serviceProvider)
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

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseHangfireDashboard();
            //backgroundJobClient.Enqueue(() => Console.WriteLine("Sart"));
            recurringJobManager.AddOrUpdate("run every 5 Mint", () => serviceProvider.GetService<CallApiService>().CallService(), "*/60 * * * *");
            //recurringJobManager.AddOrUpdate("run every 3 Mint", () => serviceProvider.GetService<SmartEdgeServices>().CallServices(), "*/30 * * * *");

        }
    }
}

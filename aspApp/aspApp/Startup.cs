using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace aspApp
{
    public class PolicyItem
    {
        public string PolicyContent { get; set; }
        public string PolicyClaim { get; set; }
    }

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<fkLists>();
            services.AddMvc();

            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.Name = "usercredentials";
            //    options.LoginPath = "/Login";
            //    options.AccessDeniedPath = "/Error";
            //    options.SlidingExpiration = true;
            //});

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "usercredentials";
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/Error";
            });

            List<PolicyItem> policyItems = new List<PolicyItem>()
            {
                new PolicyItem(){PolicyContent = "HomePolicy", PolicyClaim = "Home"},
                new PolicyItem(){PolicyContent = "View1Policy", PolicyClaim = "View 1"},
                new PolicyItem(){PolicyContent = "View2Policy", PolicyClaim = "View 2"},
                new PolicyItem(){PolicyContent = "View3Policy", PolicyClaim = "View 3"},
                new PolicyItem(){PolicyContent = "View4Policy", PolicyClaim = "View 4"},
                new PolicyItem(){PolicyContent = "View5Policy", PolicyClaim = "View 5"},
                new PolicyItem(){PolicyContent = "View6Policy", PolicyClaim = "View 6"},

                new PolicyItem(){PolicyContent = "UserListPolicy", PolicyClaim = "User List"},
                new PolicyItem(){PolicyContent = "UserViewPolicy", PolicyClaim = "User View"},
                new PolicyItem(){PolicyContent = "UserAddPolicy", PolicyClaim = "User Add"},
                new PolicyItem(){PolicyContent = "UserEditPolicy", PolicyClaim = "User Edit"},
                new PolicyItem(){PolicyContent = "UserDeletePolicy", PolicyClaim = "User Delete"},

                new PolicyItem(){PolicyContent = "RolListPolicy", PolicyClaim = "Rol List"},
                new PolicyItem(){PolicyContent = "RolViewPolicy", PolicyClaim = "Rol View"},
                new PolicyItem(){PolicyContent = "RolAddPolicy", PolicyClaim = "Rol Add"},
                new PolicyItem(){PolicyContent = "RolEditPolicy", PolicyClaim = "Rol Edit"},
                new PolicyItem(){PolicyContent = "RolDeletePolicy", PolicyClaim = "Rol Delete"},

                new PolicyItem(){PolicyContent = "ClaimsListPolicy", PolicyClaim = "Claims List"},
                new PolicyItem(){PolicyContent = "ClaimsViewPolicy", PolicyClaim = "Claims View"},
                new PolicyItem(){PolicyContent = "ClaimsAddPolicy", PolicyClaim = "Claims Add"},
                new PolicyItem(){PolicyContent = "ClaimsEditPolicy", PolicyClaim = "Claims Edit"},
                new PolicyItem(){PolicyContent = "ClaimsDeletePolicy", PolicyClaim = "Claims Delete"},

                new PolicyItem(){PolicyContent = "RolClaimsListPolicy", PolicyClaim = "RolClaims List"},
                new PolicyItem(){PolicyContent = "RolClaimsViewPolicy", PolicyClaim = "RolClaims View"},
                new PolicyItem(){PolicyContent = "RolClaimsAddPolicy", PolicyClaim = "RolClaims Add"},
                new PolicyItem(){PolicyContent = "RolClaimsEditPolicy", PolicyClaim = "RolClaims Edit"},
                new PolicyItem(){PolicyContent = "RolClaimsDeletePolicy", PolicyClaim = "RolClaims Delete"},

                new PolicyItem(){PolicyContent = "RolManageRolClaimsPolicy", PolicyClaim = "Rol ManageRolClaims"},
                new PolicyItem(){PolicyContent = "RolAddRolClaimsPolicy", PolicyClaim = "Rol AddRolClaims"},
                new PolicyItem(){PolicyContent = "RolDeleteRolClaimsPolicy", PolicyClaim = "Rol DeleteRolClaims"}
            };

            services.AddAuthorization(options => 
            {
                //options.AddPolicy("HomePolicy", policy => policy.RequireClaim("Home"));
                //options.AddPolicy("View1Policy", policy => policy.RequireClaim("View 1"));
                //options.AddPolicy("View2Policy", policy => policy.RequireClaim("View 2"));
                //options.AddPolicy("View3Policy", policy => policy.RequireClaim("View 3"));
                //options.AddPolicy("View4Policy", policy => policy.RequireClaim("View 4"));
                //options.AddPolicy("View5Policy", policy => policy.RequireClaim("View 5"));
                //options.AddPolicy("View6Policy", policy => policy.RequireClaim("View 6"));

                foreach (var item in policyItems)
                {
                    options.AddPolicy(item.PolicyContent, policy => policy.RequireClaim(item.PolicyClaim));
                }
            });

            /*
             * Users in db
             * 1: useradministrator
             * 2: usermoderator
             * 3: user
             * 4: user2
             * All password
             * password: password
             * 
             * */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseAuthentication();

            app.UseFileServer();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );

                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}

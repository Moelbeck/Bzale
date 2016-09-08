using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Web2.Services;
using Web2.Repository.Context;
using Web2.Models;

namespace Web2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                //.setBasePath("") if we want to have appsettings or other config in some other path               
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                //Secrets for Facebook, Twitter and other OAuth
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();//EnvVar will override the appsettings
            Configuration = builder.Build();
        }

        public static IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddEntityFramework()
            .AddSqlServer()
            //This still could be separated to 2 databases
            //.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]))
            .AddDbContext<BzaleContext>();

            //TODO HERE GOES THE CONNECTION TO BIZ2BIZ DATABASE AND B2BContext

            services.AddIdentity<Account, IdentityRole>()
                .AddEntityFrameworkStores<BzaleContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 10;
            });

            services.AddMvc();

            // Add application services.
            //TODO
            //HERE could be different mail service for testing/debug and real one for production
#if DEBUG
            //Fake messange sender
            services.AddTransient<IEmailSender, FakeAuthMessageSender>();
#else
            //Real messange sender
            services.AddTransient<IEmailSender, AuthMessageSender>();
#endif
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddTransient<BzaleContextSeedData>();

            services.Configure<AuthMessageSenderOptions>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider, BzaleContextSeedData seeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");

                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                //try
                //{
                //    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                //        .CreateScope())
                //    {
                //        serviceScope.ServiceProvider.GetService<BzaleContext>()
                //             .Database.Migrate();
                //    }
                //}
                //catch { }
            }

            app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());

            app.UseStaticFiles();

            app.UseIdentity();

            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                // add the new route here.
                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller}/{action}",
                    defaults: new { controller = "Manage", action = "Index" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            seeder.EnsureSeedData();
            //Initialize Admin account      
            await CreateRoles(serviceProvider);
        }

        private async Task CreateUsers(IServiceProvider serviceProvider)
        {

            var UserManager = serviceProvider.GetRequiredService<UserManager<Account>>();
            var user = await UserManager.FindByNameAsync("susu@o2.pl");

            IdentityResult result;
            if (user == null)
            {
                var newUser = new Account { UserName = "susu@o2.pl", Email = "susu@o2.pl" };
                result = await UserManager.CreateAsync(newUser, "!Admin12");
            }

        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<Account>>();

            //Add an account if doesn't exists
            await CreateUsers(serviceProvider);

            string[] roles = { "Admin", "User" };
            IdentityResult roleResult;
            foreach (var roleName in roles)
            {
                var roleExists = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var user = await UserManager.FindByNameAsync("susu@o2.pl");//FindByIdAsync("110a47fb-2983-474a-a044-6b1410fdbbc7");            
            var adminRole = await RoleManager.FindByNameAsync("Admin");
            if (user != null && user.Roles.Where(r => r.RoleId == adminRole.Id).ToList().Count > 0) await UserManager.AddToRoleAsync(user, "Admin");
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

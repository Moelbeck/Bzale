using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using bzale.Repository.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using AutoMapper;
using biz2biz.Service.Automapper;
using bzale.Core.ServiceHost.Interfaces;
using bzale.Repository;
using bzale.WebService;

namespace bzale.Core.ServiceHost
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BzaleAutoMapper());
            });
        }
        private MapperConfiguration _mapperConfiguration { get; set; }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddEntityFramework();

            services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());
            //services.AddDbContext<BzaleDatabaseContext>(options => options.UseSqlServer(@"Data Source=CHRISTOPHER\SQLEXPRESS;Initial Catalog=BzaleDatabase;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddDbContext<BzaleDatabaseContext>(options => options.UseInMemoryDatabase());

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<ISaleListingRepository, SaleListingRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMvc();
        }
    }
}

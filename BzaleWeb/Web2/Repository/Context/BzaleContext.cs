using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Web2.Models;

namespace Web2.Repository.Context
{
    public class BzaleContext : IdentityDbContext<Account>
    {

        public BzaleContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Image> Images { get; set; }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Advertiser> Advertisers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AnnonceSubscription> ItemSubscriptions { get; set; }
        public DbSet<AnnonceSubscriptionDescription> ItemSubscriptionDescriptions { get; set; }
        public DbSet<Annonce> Items { get; set; }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<CategoryPreferences> CategoryPreferenceses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:DefaultConnection:ConnectionString"];
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }


    }
}

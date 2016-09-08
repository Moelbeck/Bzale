
using bzale.Model;
using bzale.Model.Log;
using bzale.Model.Base;

using Microsoft.EntityFrameworkCore;

namespace bzale.Repository.DatabaseContext
{
    public class BzaleDatabaseContext : DbContext
    {

        public BzaleDatabaseContext(DbContextOptions<BzaleDatabaseContext> con)
            : base(con)
        { 
            }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Advertiser> Advertisers { get; set; }
        public DbSet<BaseCategory> Categories { get; set; }
        public DbSet<CategoryPreferences> CategoryPreferenceses { get; set; }
        public DbSet<BaseComment> Comments { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ProductType> Products { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SaleListing> SaleListings { get; set; }
        public DbSet<BaseLog> Loggings { get; set; }

    }
}

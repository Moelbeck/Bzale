
using depross.Model;
using depross.Model.Log;
using depross.Model.Base;
using System.Data.Entity;

namespace depross.Repository.DatabaseContext
{
    public class BzaleDatabaseContext : DbContext
    {

        public BzaleDatabaseContext()
            : base("DaProsaConnection")
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

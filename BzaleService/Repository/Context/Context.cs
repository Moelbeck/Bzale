﻿
using depross.Model;
using depross.Model.Base;
using System.Data.Entity;
using Repository.Migrations;

namespace depross.Repository.DatabaseContext
{
    public class BzaleDatabaseContext : DbContext
    {

        public BzaleDatabaseContext()
            : base("ConnectionString")
        {
          //  InitializeDatabase();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Advertiser> Advertisers { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<CategoryPreferences> CategoryPreferenceses { get; set; }
        public DbSet<BaseComment> Comments { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SaleListing> SaleListings { get; set; }


        private void InitializeDatabase()
        {
            if (Database.Exists())
            {
                Database.Initialize(true);
               var config = new Configuration();
                config.Seed(this);
            }
        }
    }
}

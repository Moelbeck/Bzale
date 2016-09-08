using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using biz2biz.Model;

namespace biz2biz.Repository.context
{
    public class Context : DbContext
    {
        //private static SqlConnection _cn = new SqlConnection(ConfigurationManager.ConnectionStrings["BzaleConnectionString"].ConnectionString);
        //private static string test = _cn.ConnectionString;

        public Context() : base("BzaleConnectionString")
        {
            
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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

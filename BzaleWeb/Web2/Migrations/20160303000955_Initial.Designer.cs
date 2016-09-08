using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Web2.Repository.Context;

namespace Web2.Migrations
{
    [DbContext(typeof(BzaleContext))]
    [Migration("20160303000955_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("Web2.Models.Account", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<int?>("CompanyID");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<int?>("Gender");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int?>("PostalCode");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTime?>("Updated")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Web2.Models.Advertisement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdvertiserID");

                    b.Property<DateTime>("Created")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ExpirationDate")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<int?>("ImageID");

                    b.Property<string>("Title");

                    b.Property<string>("URL");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Web2.Models.Advertiser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("URL");

                    b.Property<DateTime?>("Updated")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Web2.Models.Annonce", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("AmountType");

                    b.Property<DateTime>("Created")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime?>("Deleted")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ExpirationDate")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<bool>("IsPriceNegotiable");

                    b.Property<int?>("ManufacturerID");

                    b.Property<int?>("OwnerID");

                    b.Property<double>("Price");

                    b.Property<int?>("ProductCategoryID");

                    b.Property<int?>("ProductID");

                    b.Property<int?>("SubscriptionID");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("Updated")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Web2.Models.AnnonceSubscription", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<DateTime>("Deleted")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<int>("ItemSubscriptionType");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Web2.Models.AnnonceSubscriptionDescription", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("ItemSubscriptionType");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Web2.Models.CategoryPreferences", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountId");

                    b.Property<DateTime>("Created")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<DateTime?>("Updated")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Web2.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AnnonceID");

                    b.Property<DateTime>("Created")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<DateTime>("Deleted")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<bool>("IsPrivateMessage");

                    b.Property<string>("Message");

                    b.Property<string>("SenderId");

                    b.Property<string>("Title");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Web2.Models.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Addresse");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<string>("Email");

                    b.Property<int?>("ImageID");

                    b.Property<bool>("IsVerified");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int>("PostalCode");

                    b.Property<DateTime?>("Updated")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<string>("VAT");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Web2.Models.Image", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AnnonceID");

                    b.Property<int?>("AnnonceSubscriptionDescriptionID");

                    b.Property<DateTime>("Created")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<string>("ImageURL");

                    b.Property<int>("Type");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Web2.Models.JobCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryPreferencesID");

                    b.Property<string>("Description");

                    b.Property<int?>("ImageID");

                    b.Property<string>("Name");

                    b.Property<int?>("ProductCategoryID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Web2.Models.Manufacturer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryID");

                    b.Property<DateTime>("Created")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("Updated")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Web2.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.Property<int?>("ManufacturerID");

                    b.Property<string>("Name");

                    b.Property<int?>("ProductCategoryID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Web2.Models.ProductCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("ImageID");

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Web2.Models.Rating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CommentID");

                    b.Property<int?>("CompanyID");

                    b.Property<DateTime>("Created")
                        .HasAnnotation("Relational:ColumnType", "DateTime2");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Web2.Models.Account")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Web2.Models.Account")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Web2.Models.Account")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Web2.Models.Account", b =>
                {
                    b.HasOne("Web2.Models.Company")
                        .WithMany()
                        .HasForeignKey("CompanyID");
                });

            modelBuilder.Entity("Web2.Models.Advertisement", b =>
                {
                    b.HasOne("Web2.Models.Advertiser")
                        .WithMany()
                        .HasForeignKey("AdvertiserID");

                    b.HasOne("Web2.Models.Image")
                        .WithMany()
                        .HasForeignKey("ImageID");
                });

            modelBuilder.Entity("Web2.Models.Annonce", b =>
                {
                    b.HasOne("Web2.Models.Account")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Web2.Models.Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerID");

                    b.HasOne("Web2.Models.Company")
                        .WithMany()
                        .HasForeignKey("OwnerID");

                    b.HasOne("Web2.Models.ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryID");

                    b.HasOne("Web2.Models.Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.HasOne("Web2.Models.AnnonceSubscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionID");
                });

            modelBuilder.Entity("Web2.Models.CategoryPreferences", b =>
                {
                    b.HasOne("Web2.Models.Account")
                        .WithMany()
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("Web2.Models.Comment", b =>
                {
                    b.HasOne("Web2.Models.Annonce")
                        .WithMany()
                        .HasForeignKey("AnnonceID");

                    b.HasOne("Web2.Models.Account")
                        .WithMany()
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("Web2.Models.Company", b =>
                {
                    b.HasOne("Web2.Models.Image")
                        .WithMany()
                        .HasForeignKey("ImageID");
                });

            modelBuilder.Entity("Web2.Models.Image", b =>
                {
                    b.HasOne("Web2.Models.Annonce")
                        .WithMany()
                        .HasForeignKey("AnnonceID");

                    b.HasOne("Web2.Models.AnnonceSubscriptionDescription")
                        .WithMany()
                        .HasForeignKey("AnnonceSubscriptionDescriptionID");
                });

            modelBuilder.Entity("Web2.Models.JobCategory", b =>
                {
                    b.HasOne("Web2.Models.CategoryPreferences")
                        .WithMany()
                        .HasForeignKey("CategoryPreferencesID");

                    b.HasOne("Web2.Models.Image")
                        .WithMany()
                        .HasForeignKey("ImageID");

                    b.HasOne("Web2.Models.ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryID");
                });

            modelBuilder.Entity("Web2.Models.Product", b =>
                {
                    b.HasOne("Web2.Models.Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerID");

                    b.HasOne("Web2.Models.ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryID");
                });

            modelBuilder.Entity("Web2.Models.ProductCategory", b =>
                {
                    b.HasOne("Web2.Models.Image")
                        .WithMany()
                        .HasForeignKey("ImageID");
                });

            modelBuilder.Entity("Web2.Models.Rating", b =>
                {
                    b.HasOne("Web2.Models.Comment")
                        .WithMany()
                        .HasForeignKey("CommentID");

                    b.HasOne("Web2.Models.Company")
                        .WithMany()
                        .HasForeignKey("CompanyID");
                });
        }
    }
}

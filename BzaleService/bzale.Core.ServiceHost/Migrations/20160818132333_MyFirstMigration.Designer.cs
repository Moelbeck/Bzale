using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using bzale.Repository.DatabaseContext;

namespace bzale.Core.ServiceHost.Migrations
{
    [DbContext(typeof(BzaleDatabaseContext))]
    [Migration("20160818132333_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bzale.Model.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int?>("CompanyID");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<bool>("HasValidatedMail");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<int>("PostalCode");

                    b.Property<string>("Salt");

                    b.Property<int>("Type");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("DateTime2");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("bzale.Model.Advertisement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdvertiserID");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("DateTime2");

                    b.Property<int?>("ImageID");

                    b.Property<string>("Title");

                    b.Property<string>("URL");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("DateTime2");

                    b.HasKey("ID");

                    b.HasIndex("AdvertiserID");

                    b.HasIndex("ImageID");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("bzale.Model.Advertiser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("URL");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("DateTime2");

                    b.HasKey("ID");

                    b.ToTable("Advertisers");
                });

            modelBuilder.Entity("bzale.Model.Base.BaseComment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Message");

                    b.Property<int?>("SenderID");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("DateTime2");

                    b.HasKey("ID");

                    b.HasIndex("SenderID");

                    b.ToTable("Comments");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseComment");
                });

            modelBuilder.Entity("bzale.Model.Base.BaseLog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("DateTime2");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.ToTable("Loggings");
                });

            modelBuilder.Entity("bzale.Model.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryPreferencesID");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Description");

                    b.Property<int?>("ImageID");

                    b.Property<int?>("ManufacturerID");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("DateTime2");

                    b.HasKey("ID");

                    b.HasIndex("CategoryPreferencesID");

                    b.HasIndex("ImageID");

                    b.HasIndex("ManufacturerID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("bzale.Model.CategoryPreferences", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountID");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("DateTime2");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.ToTable("CategoryPreferenceses");
                });

            modelBuilder.Entity("bzale.Model.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Email");

                    b.Property<int?>("ImageID");

                    b.Property<bool>("IsVerified");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int>("PostalCode");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("DateTime2");

                    b.Property<string>("VAT");

                    b.HasKey("ID");

                    b.HasIndex("ImageID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("bzale.Model.Image", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("DateTime2");

                    b.Property<string>("ImageURL");

                    b.Property<int?>("SaleListingID");

                    b.Property<int>("Type");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("DateTime2");

                    b.HasKey("ID");

                    b.HasIndex("SaleListingID");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("bzale.Model.Manufacturer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryID");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("DateTime2");

                    b.HasKey("ID");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("bzale.Model.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryID");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("DateTime2");

                    b.Property<int?>("ManufacturerID");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("DateTime2");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ManufacturerID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("bzale.Model.Rating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountID");

                    b.Property<int?>("CompanyID");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Description");

                    b.Property<int>("GivenRating");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("DateTime2");

                    b.Property<int>("Votes");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("bzale.Model.SaleListing", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("AmountType");

                    b.Property<int?>("CategoryID");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<int?>("CreatedByID");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("DateTime2");

                    b.Property<int?>("ManufacturerID");

                    b.Property<int?>("OwnerID");

                    b.Property<double>("Price");

                    b.Property<int?>("ProductID");

                    b.Property<int?>("SubscriptionID");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("DateTime2");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("CreatedByID");

                    b.HasIndex("ManufacturerID");

                    b.HasIndex("OwnerID");

                    b.HasIndex("ProductID");

                    b.HasIndex("SubscriptionID");

                    b.ToTable("SaleListings");
                });

            modelBuilder.Entity("bzale.Model.Subscription", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("DateTime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("DateTime2");

                    b.Property<double>("Price");

                    b.Property<int>("SubscriptionCategory");

                    b.Property<int>("SubscriptionType");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("DateTime2");

                    b.HasKey("ID");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("bzale.Model.Comment", b =>
                {
                    b.HasBaseType("bzale.Model.Base.BaseComment");

                    b.Property<int>("CommentType");

                    b.Property<bool>("IsPrivateMessage");

                    b.Property<int?>("SaleListingID");

                    b.HasIndex("SaleListingID");

                    b.ToTable("Comment");

                    b.HasDiscriminator().HasValue("Comment");
                });

            modelBuilder.Entity("bzale.Model.CommentAnswer", b =>
                {
                    b.HasBaseType("bzale.Model.Base.BaseComment");

                    b.Property<int?>("ParentCommentID");

                    b.HasIndex("ParentCommentID");

                    b.ToTable("CommentAnswer");

                    b.HasDiscriminator().HasValue("CommentAnswer");
                });

            modelBuilder.Entity("bzale.Model.Account", b =>
                {
                    b.HasOne("bzale.Model.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID");
                });

            modelBuilder.Entity("bzale.Model.Advertisement", b =>
                {
                    b.HasOne("bzale.Model.Advertiser", "Advertiser")
                        .WithMany("Advertisements")
                        .HasForeignKey("AdvertiserID");

                    b.HasOne("bzale.Model.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageID");
                });

            modelBuilder.Entity("bzale.Model.Base.BaseComment", b =>
                {
                    b.HasOne("bzale.Model.Account", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderID");
                });

            modelBuilder.Entity("bzale.Model.Category", b =>
                {
                    b.HasOne("bzale.Model.CategoryPreferences")
                        .WithMany("PreferedCategories")
                        .HasForeignKey("CategoryPreferencesID");

                    b.HasOne("bzale.Model.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageID");

                    b.HasOne("bzale.Model.Manufacturer")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ManufacturerID");
                });

            modelBuilder.Entity("bzale.Model.CategoryPreferences", b =>
                {
                    b.HasOne("bzale.Model.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID");
                });

            modelBuilder.Entity("bzale.Model.Company", b =>
                {
                    b.HasOne("bzale.Model.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageID");
                });

            modelBuilder.Entity("bzale.Model.Image", b =>
                {
                    b.HasOne("bzale.Model.SaleListing")
                        .WithMany("Images")
                        .HasForeignKey("SaleListingID");
                });

            modelBuilder.Entity("bzale.Model.Product", b =>
                {
                    b.HasOne("bzale.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("bzale.Model.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerID");
                });

            modelBuilder.Entity("bzale.Model.Rating", b =>
                {
                    b.HasOne("bzale.Model.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID");

                    b.HasOne("bzale.Model.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID");
                });

            modelBuilder.Entity("bzale.Model.SaleListing", b =>
                {
                    b.HasOne("bzale.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("bzale.Model.Account", "CreatedBy")
                        .WithMany("Following")
                        .HasForeignKey("CreatedByID");

                    b.HasOne("bzale.Model.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerID");

                    b.HasOne("bzale.Model.Company", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerID");

                    b.HasOne("bzale.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.HasOne("bzale.Model.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionID");
                });

            modelBuilder.Entity("bzale.Model.Comment", b =>
                {
                    b.HasOne("bzale.Model.SaleListing")
                        .WithMany("Comments")
                        .HasForeignKey("SaleListingID");
                });

            modelBuilder.Entity("bzale.Model.CommentAnswer", b =>
                {
                    b.HasOne("bzale.Model.Comment", "ParentComment")
                        .WithMany("Answers")
                        .HasForeignKey("ParentCommentID");
                });
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bzale.Core.ServiceHost.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Loggings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loggings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Price = table.Column<double>(nullable: false),
                    SubscriptionCategory = table.Column<int>(nullable: false),
                    SubscriptionType = table.Column<int>(nullable: false),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    SenderID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    CommentType = table.Column<int>(nullable: true),
                    IsPrivateMessage = table.Column<bool>(nullable: true),
                    SaleListingID = table.Column<int>(nullable: true),
                    ParentCommentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentCommentID",
                        column: x => x.ParentCommentID,
                        principalTable: "Comments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPreferenceses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountID = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPreferenceses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountID = table.Column<int>(nullable: true),
                    CompanyID = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GivenRating = table.Column<int>(nullable: false),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Votes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SaleListings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    AmountType = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    CreatedByID = table.Column<int>(nullable: true),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    ManufacturerID = table.Column<int>(nullable: true),
                    OwnerID = table.Column<int>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ProductID = table.Column<int>(nullable: true),
                    SubscriptionID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleListings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SaleListings_Manufacturers_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleListings_Subscriptions_SubscriptionID",
                        column: x => x.SubscriptionID,
                        principalTable: "Subscriptions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    SaleListingID = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Image_SaleListings_SaleListingID",
                        column: x => x.SaleListingID,
                        principalTable: "SaleListings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdvertiserID = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    ImageID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Advertisements_Advertisers_AdvertiserID",
                        column: x => x.AdvertiserID,
                        principalTable: "Advertisers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advertisements_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryPreferencesID = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageID = table.Column<int>(nullable: true),
                    ManufacturerID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categories_CategoryPreferenceses_CategoryPreferencesID",
                        column: x => x.CategoryPreferencesID,
                        principalTable: "CategoryPreferenceses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categories_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categories_Manufacturers_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ImageID = table.Column<int>(nullable: true),
                    IsVerified = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PostalCode = table.Column<int>(nullable: false),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    VAT = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Companies_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    ManufacturerID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    CompanyID = table.Column<int>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    HasValidatedMail = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PostalCode = table.Column<int>(nullable: false),
                    Salt = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accounts_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CompanyID",
                table: "Accounts",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_AdvertiserID",
                table: "Advertisements",
                column: "AdvertiserID");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_ImageID",
                table: "Advertisements",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SenderID",
                table: "Comments",
                column: "SenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SaleListingID",
                table: "Comments",
                column: "SaleListingID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentID",
                table: "Comments",
                column: "ParentCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryPreferencesID",
                table: "Categories",
                column: "CategoryPreferencesID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ImageID",
                table: "Categories",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ManufacturerID",
                table: "Categories",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPreferenceses_AccountID",
                table: "CategoryPreferenceses",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ImageID",
                table: "Companies",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_SaleListingID",
                table: "Image",
                column: "SaleListingID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerID",
                table: "Products",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AccountID",
                table: "Ratings",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CompanyID",
                table: "Ratings",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleListings_CategoryID",
                table: "SaleListings",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleListings_CreatedByID",
                table: "SaleListings",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleListings_ManufacturerID",
                table: "SaleListings",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleListings_OwnerID",
                table: "SaleListings",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleListings_ProductID",
                table: "SaleListings",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleListings_SubscriptionID",
                table: "SaleListings",
                column: "SubscriptionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Accounts_SenderID",
                table: "Comments",
                column: "SenderID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_SaleListings_SaleListingID",
                table: "Comments",
                column: "SaleListingID",
                principalTable: "SaleListings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPreferenceses_Accounts_AccountID",
                table: "CategoryPreferenceses",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Companies_CompanyID",
                table: "Ratings",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Accounts_AccountID",
                table: "Ratings",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleListings_Companies_OwnerID",
                table: "SaleListings",
                column: "OwnerID",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleListings_Accounts_CreatedByID",
                table: "SaleListings",
                column: "CreatedByID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleListings_Categories_CategoryID",
                table: "SaleListings",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleListings_Products_ProductID",
                table: "SaleListings",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Companies_CompanyID",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleListings_Companies_OwnerID",
                table: "SaleListings");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Image_ImageID",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Loggings");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Advertisers");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "SaleListings");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryPreferenceses");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}

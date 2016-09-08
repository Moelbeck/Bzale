using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Web2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Advertiser",
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
                    table.PrimaryKey("PK_Advertiser", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "AnnonceSubscription",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    ItemSubscriptionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnonceSubscription", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "AnnonceSubscriptionDescription",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ItemSubscriptionType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnonceSubscriptionDescription", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "Manufacturer",
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
                    table.PrimaryKey("PK_Manufacturer", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<string>", x => new { x.LoginProvider, x.ProviderKey });
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<string>", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CompanyID = table.Column<int>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    PostalCode = table.Column<int>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "CategoryPreferences",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPreferences", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategoryPreferences_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Advertisement",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdvertiserID = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    ImageID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Advertisement_Advertiser_AdvertiserID",
                        column: x => x.AdvertiserID,
                        principalTable: "Advertiser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Annonce",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    AmountType = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    IsPriceNegotiable = table.Column<bool>(nullable: false),
                    ManufacturerID = table.Column<int>(nullable: true),
                    OwnerID = table.Column<int>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ProductCategoryID = table.Column<int>(nullable: true),
                    ProductID = table.Column<int>(nullable: true),
                    SubscriptionID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annonce", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Annonce_Account_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Annonce_Manufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Annonce_AnnonceSubscription_SubscriptionID",
                        column: x => x.SubscriptionID,
                        principalTable: "AnnonceSubscription",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnonceID = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    IsPrivateMessage = table.Column<bool>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    SenderId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_Annonce_AnnonceID",
                        column: x => x.AnnonceID,
                        principalTable: "Annonce",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Account_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnonceID = table.Column<int>(nullable: true),
                    AnnonceSubscriptionDescriptionID = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Image_Annonce_AnnonceID",
                        column: x => x.AnnonceID,
                        principalTable: "Annonce",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_AnnonceSubscriptionDescription_AnnonceSubscriptionDescriptionID",
                        column: x => x.AnnonceSubscriptionDescriptionID,
                        principalTable: "AnnonceSubscriptionDescription",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Addresse = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Company", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Company_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ImageID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentID = table.Column<int>(nullable: true),
                    CompanyID = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rating_Comment_CommentID",
                        column: x => x.CommentID,
                        principalTable: "Comment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "JobCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryPreferencesID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProductCategoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JobCategory_CategoryPreferences_CategoryPreferencesID",
                        column: x => x.CategoryPreferencesID,
                        principalTable: "CategoryPreferences",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobCategory_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobCategory_ProductCategory_ProductCategoryID",
                        column: x => x.ProductCategoryID,
                        principalTable: "ProductCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    ManufacturerID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProductCategoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Manufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_ProductCategoryID",
                        column: x => x.ProductCategoryID,
                        principalTable: "ProductCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");
            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName");
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_Account_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_Account_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_Account_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Account_Company_CompanyID",
                table: "AspNetUsers",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Image_ImageID",
                table: "Advertisement",
                column: "ImageID",
                principalTable: "Image",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Annonce_Company_OwnerID",
                table: "Annonce",
                column: "OwnerID",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Annonce_ProductCategory_ProductCategoryID",
                table: "Annonce",
                column: "ProductCategoryID",
                principalTable: "ProductCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Annonce_Product_ProductID",
                table: "Annonce",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Annonce_Account_CreatedById", table: "Annonce");
            migrationBuilder.DropForeignKey(name: "FK_Image_Annonce_AnnonceID", table: "Image");
            migrationBuilder.DropTable("AspNetRoleClaims");
            migrationBuilder.DropTable("AspNetUserClaims");
            migrationBuilder.DropTable("AspNetUserLogins");
            migrationBuilder.DropTable("AspNetUserRoles");
            migrationBuilder.DropTable("Advertisement");
            migrationBuilder.DropTable("JobCategory");
            migrationBuilder.DropTable("Rating");
            migrationBuilder.DropTable("AspNetRoles");
            migrationBuilder.DropTable("Advertiser");
            migrationBuilder.DropTable("CategoryPreferences");
            migrationBuilder.DropTable("Comment");
            migrationBuilder.DropTable("AspNetUsers");
            migrationBuilder.DropTable("Annonce");
            migrationBuilder.DropTable("Company");
            migrationBuilder.DropTable("Product");
            migrationBuilder.DropTable("AnnonceSubscription");
            migrationBuilder.DropTable("Manufacturer");
            migrationBuilder.DropTable("ProductCategory");
            migrationBuilder.DropTable("Image");
            migrationBuilder.DropTable("AnnonceSubscriptionDescription");
        }
    }
}

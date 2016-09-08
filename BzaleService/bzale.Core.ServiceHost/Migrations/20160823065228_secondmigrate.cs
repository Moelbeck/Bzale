using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bzale.Core.ServiceHost.Migrations
{
    public partial class secondmigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Manufacturers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Manufacturers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Categories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MainCategoryID",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MainCategoryID",
                table: "Categories",
                column: "MainCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_MainCategoryID",
                table: "Categories",
                column: "MainCategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_MainCategoryID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MainCategoryID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MainCategoryID",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Manufacturers",
                nullable: false,
                defaultValue: 0);
        }
    }
}

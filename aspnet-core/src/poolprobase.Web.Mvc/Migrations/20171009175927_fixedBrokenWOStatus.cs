using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace poolprobase.Web.Migrations
{
    public partial class fixedBrokenWOStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WO_Status",
                table: "WorkOrders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WO_Status",
                table: "WorkOrders",
                nullable: false,
                defaultValue: 0);
        }
    }
}

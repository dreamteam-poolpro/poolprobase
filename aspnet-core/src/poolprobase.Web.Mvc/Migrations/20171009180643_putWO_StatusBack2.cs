using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace poolprobase.Web.Migrations
{
    public partial class putWO_StatusBack2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WO_Status",
                table: "WorkOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WO_Status",
                table: "WorkOrders");
        }
    }
}

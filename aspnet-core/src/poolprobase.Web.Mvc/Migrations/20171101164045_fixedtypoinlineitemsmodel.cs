using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace poolprobase.Web.Migrations
{
    public partial class fixedtypoinlineitemsmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_WorkOrders_WorkOrderID",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "WordOrderID",
                table: "LineItems");

            migrationBuilder.AlterColumn<int>(
                name: "WorkOrderID",
                table: "LineItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_WorkOrders_WorkOrderID",
                table: "LineItems",
                column: "WorkOrderID",
                principalTable: "WorkOrders",
                principalColumn: "WorkOrderID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_WorkOrders_WorkOrderID",
                table: "LineItems");

            migrationBuilder.AlterColumn<int>(
                name: "WorkOrderID",
                table: "LineItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WordOrderID",
                table: "LineItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_WorkOrders_WorkOrderID",
                table: "LineItems",
                column: "WorkOrderID",
                principalTable: "WorkOrders",
                principalColumn: "WorkOrderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

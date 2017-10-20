using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace poolprobase.Web.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_WorkOrders_WorkOrderID",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "LineItems");

            migrationBuilder.AlterColumn<int>(
                name: "WorkOrderID",
                table: "LineItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Units",
                table: "LineItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WordOrderID",
                table: "LineItems",
                type: "int",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_WorkOrders_WorkOrderID",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "Units",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "WordOrderID",
                table: "LineItems");

            migrationBuilder.AlterColumn<int>(
                name: "WorkOrderID",
                table: "LineItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "LineItems",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_WorkOrders_WorkOrderID",
                table: "LineItems",
                column: "WorkOrderID",
                principalTable: "WorkOrders",
                principalColumn: "WorkOrderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

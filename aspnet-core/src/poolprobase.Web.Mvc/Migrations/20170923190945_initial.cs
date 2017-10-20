using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace poolprobase.Web.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        CustomerID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customers", x => x.CustomerID);
            //    });

        //    migrationBuilder.CreateTable(
        //        name: "ServiceTechs",
        //        columns: table => new
        //        {
        //            ServiceTechID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ServiceTechs", x => x.ServiceTechID);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "WorkOrders",
        //        columns: table => new
        //        {
        //            WorkOrderID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            CustomerID = table.Column<int>(type: "int", nullable: false),
        //            ServiceTechID = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_WorkOrders", x => x.WorkOrderID);
        //            table.ForeignKey(
        //                name: "FK_WorkOrders_Customers_CustomerID",
        //                column: x => x.CustomerID,
        //                principalTable: "Customers",
        //                principalColumn: "CustomerID",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_WorkOrders_ServiceTechs_ServiceTechID",
        //                column: x => x.ServiceTechID,
        //                principalTable: "ServiceTechs",
        //                principalColumn: "ServiceTechID",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "LineItems",
        //        columns: table => new
        //        {
        //            LineItemID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Quantity = table.Column<int>(type: "int", nullable: false),
        //            Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            UnitCost = table.Column<double>(type: "float", nullable: false),
        //            WorkOrderID = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_LineItems", x => x.LineItemID);
        //            table.ForeignKey(
        //                name: "FK_LineItems_WorkOrders_WorkOrderID",
        //                column: x => x.WorkOrderID,
        //                principalTable: "WorkOrders",
        //                principalColumn: "WorkOrderID",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_LineItems_WorkOrderID",
        //        table: "LineItems",
        //        column: "WorkOrderID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_WorkOrders_CustomerID",
        //        table: "WorkOrders",
        //        column: "CustomerID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_WorkOrders_ServiceTechID",
        //        table: "WorkOrders",
        //        column: "ServiceTechID");
        //}

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "LineItems");

        //    migrationBuilder.DropTable(
        //        name: "WorkOrders");

        //    migrationBuilder.DropTable(
        //        name: "Customers");

        //    migrationBuilder.DropTable(
        //        name: "ServiceTechs");
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using poolprobase.Web.Data;
using System;

namespace poolprobase.Web.Migrations
{
    [DbContext(typeof(CustomerContext))]
    [Migration("20171007184728_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("poolprobase.Web.Models.Customer.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("poolprobase.Web.Models.Customer.LineItem", b =>
                {
                    b.Property<int>("LineItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Quantity");

                    b.Property<double>("UnitCost");

                    b.Property<string>("Units");

                    b.Property<int>("WordOrderID");

                    b.Property<int?>("WorkOrderID");

                    b.HasKey("LineItemID");

                    b.HasIndex("WorkOrderID");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("poolprobase.Web.Models.Customer.ServiceTech", b =>
                {
                    b.Property<int>("ServiceTechID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ServiceTechID");

                    b.ToTable("ServiceTechs");
                });

            modelBuilder.Entity("poolprobase.Web.Models.Customer.WorkOrder", b =>
                {
                    b.Property<int>("WorkOrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerID");

                    b.Property<int>("ServiceTechID");

                    b.HasKey("WorkOrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ServiceTechID");

                    b.ToTable("WorkOrders");
                });

            modelBuilder.Entity("poolprobase.Web.Models.Customer.LineItem", b =>
                {
                    b.HasOne("poolprobase.Web.Models.Customer.WorkOrder")
                        .WithMany("LineItems")
                        .HasForeignKey("WorkOrderID");
                });

            modelBuilder.Entity("poolprobase.Web.Models.Customer.WorkOrder", b =>
                {
                    b.HasOne("poolprobase.Web.Models.Customer.Customer", "Customer")
                        .WithMany("WorkOrders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("poolprobase.Web.Models.Customer.ServiceTech", "ServiceTech")
                        .WithMany("WorkOrders")
                        .HasForeignKey("ServiceTechID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

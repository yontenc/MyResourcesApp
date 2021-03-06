﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyResourcesApp.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyResourcesApp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210317055704_OrderTable_Added_StatusColumn")]
    partial class OrderTable_Added_StatusColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("MyResourcesApp.Models.Customer", b =>
                {
                    b.Property<string>("CID")
                        .HasColumnType("text");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CID");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("MyResourcesApp.Models.DepositAdance", b =>
                {
                    b.Property<string>("CustomerCID")
                        .HasColumnType("text");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.HasKey("CustomerCID");

                    b.ToTable("advanceDeposit");
                });

            modelBuilder.Entity("MyResourcesApp.Models.DepositAdvanceHistory", b =>
                {
                    b.Property<int>("DepositeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("BalanceAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("CreditAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("CustomerCID")
                        .HasColumnType("text");

                    b.Property<decimal>("DebitAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("DepositTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("DepositeID");

                    b.ToTable("depositAdvanceHistory");
                });

            modelBuilder.Entity("MyResourcesApp.Models.PlaceOrder", b =>
                {
                    b.Property<string>("CID")
                        .HasColumnType("text");

                    b.Property<decimal>("AdvanceBalance")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PriceAmount")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("SiteID")
                        .HasColumnType("integer");

                    b.Property<char>("Status")
                        .HasColumnType("character(1)");

                    b.Property<decimal>("TransportAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CID");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("MyResourcesApp.Models.Product", b =>
                {
                    b.Property<string>("productName")
                        .HasColumnType("text");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TransportRate")
                        .HasColumnType("numeric");

                    b.HasKey("productName");

                    b.ToTable("product");
                });

            modelBuilder.Entity("MyResourcesApp.Models.Site", b =>
                {
                    b.Property<int>("SiteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CustomerID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Distance")
                        .HasColumnType("numeric");

                    b.Property<string>("SiteName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SiteID");

                    b.ToTable("siteInfo");
                });
#pragma warning restore 612, 618
        }
    }
}

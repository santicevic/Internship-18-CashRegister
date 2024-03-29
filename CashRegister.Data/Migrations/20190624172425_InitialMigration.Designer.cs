﻿// <auto-generated />
using System;
using CashRegister.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CashRegister.Data.Migrations
{
    [DbContext(typeof(CashRegisterContext))]
    [Migration("20190624172425_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CashRegister.Data.Entities.Models.CashRegister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("CashRegisters");
                });

            modelBuilder.Entity("CashRegister.Data.Entities.Models.Cashier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cashiers");
                });

            modelBuilder.Entity("CashRegister.Data.Entities.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountInStock");

                    b.Property<int>("Barcode");

                    b.Property<string>("Name");

                    b.Property<float>("PriceWithTax");

                    b.Property<float>("Tax");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CashRegister.Data.Entities.Models.ItemReceipt", b =>
                {
                    b.Property<int>("ItemId");

                    b.Property<Guid>("ReceiptId");

                    b.Property<int>("Amount");

                    b.HasKey("ItemId", "ReceiptId");

                    b.HasIndex("ReceiptId");

                    b.ToTable("ItemReceipts");
                });

            modelBuilder.Entity("CashRegister.Data.Entities.Models.Receipt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CashRegisterId");

                    b.Property<int>("CashierId");

                    b.Property<DateTime>("CreationTime");

                    b.HasKey("Id");

                    b.HasIndex("CashRegisterId");

                    b.HasIndex("CashierId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("CashRegister.Data.Entities.Models.ItemReceipt", b =>
                {
                    b.HasOne("CashRegister.Data.Entities.Models.Item", "Item")
                        .WithMany("ItemReceipts")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CashRegister.Data.Entities.Models.Receipt", "Receipt")
                        .WithMany("ItemReceipts")
                        .HasForeignKey("ReceiptId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CashRegister.Data.Entities.Models.Receipt", b =>
                {
                    b.HasOne("CashRegister.Data.Entities.Models.CashRegister", "CashRegister")
                        .WithMany("Receipts")
                        .HasForeignKey("CashRegisterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CashRegister.Data.Entities.Models.Cashier", "Cashier")
                        .WithMany("Receipts")
                        .HasForeignKey("CashierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using CashRegister.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CashRegister.Data.Migrations
{
    [DbContext(typeof(CashRegisterContext))]
    partial class CashRegisterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            Id = 1
                        },
                        new
                        {
                            Id = 2
                        },
                        new
                        {
                            Id = 3
                        },
                        new
                        {
                            Id = 4
                        });
                });

            modelBuilder.Entity("CashRegister.Data.Entities.Models.Cashier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cashiers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ivana Ivanković"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Marko Marković"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Jure Jurić"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Marija Marić"
                        });
                });

            modelBuilder.Entity("CashRegister.Data.Entities.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountInStock");

                    b.Property<string>("Barcode");

                    b.Property<string>("Name");

                    b.Property<float>("PriceWithTax");

                    b.Property<float>("Tax");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmountInStock = 25,
                            Barcode = "4383294211",
                            Name = "Juha u vrečici",
                            PriceWithTax = 12.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 2,
                            AmountInStock = 25,
                            Barcode = "4383520151",
                            Name = "Kruh didov",
                            PriceWithTax = 6.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 3,
                            AmountInStock = 25,
                            Barcode = "6201694211",
                            Name = "Choco loco",
                            PriceWithTax = 10.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 4,
                            AmountInStock = 25,
                            Barcode = "4380284111",
                            Name = "Vrečica velika",
                            PriceWithTax = 0.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 5,
                            AmountInStock = 25,
                            Barcode = "4383281055",
                            Name = "Vrečica mala",
                            PriceWithTax = 0.59f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 6,
                            AmountInStock = 25,
                            Barcode = "4381172991",
                            Name = "Brod na napuhivanje",
                            PriceWithTax = 123.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 7,
                            AmountInStock = 25,
                            Barcode = "8821230211",
                            Name = "Poli parizer",
                            PriceWithTax = 6.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 8,
                            AmountInStock = 25,
                            Barcode = "4389928510",
                            Name = "Majoneza",
                            PriceWithTax = 14.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 9,
                            AmountInStock = 25,
                            Barcode = "439912411",
                            Name = "Kiseli krastavci",
                            PriceWithTax = 9.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 10,
                            AmountInStock = 25,
                            Barcode = "8822104211",
                            Name = "Panirani odrezak",
                            PriceWithTax = 29.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 11,
                            AmountInStock = 25,
                            Barcode = "43119834211",
                            Name = "Tuna konzerva",
                            PriceWithTax = 12.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 12,
                            AmountInStock = 25,
                            Barcode = "4382194211",
                            Name = "Bublica",
                            PriceWithTax = 3.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 13,
                            AmountInStock = 25,
                            Barcode = "4399994211",
                            Name = "Heiniken pivo",
                            PriceWithTax = 8.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 14,
                            AmountInStock = 25,
                            Barcode = "4383292741",
                            Name = "Ožujsko pivo",
                            PriceWithTax = 7.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 15,
                            AmountInStock = 25,
                            Barcode = "4329482911",
                            Name = "IsoSport napitak",
                            PriceWithTax = 7.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 16,
                            AmountInStock = 25,
                            Barcode = "4383299462",
                            Name = "Coca-cola",
                            PriceWithTax = 6.99f,
                            Tax = 25f
                        },
                        new
                        {
                            Id = 17,
                            AmountInStock = 25,
                            Barcode = "4383729131",
                            Name = "Čaše plastične",
                            PriceWithTax = 29.99f,
                            Tax = 25f
                        });
                });

            modelBuilder.Entity("CashRegister.Data.Entities.Models.ItemReceipt", b =>
                {
                    b.Property<int>("ItemId");

                    b.Property<Guid>("ReceiptId");

                    b.Property<int>("Amount");

                    b.Property<float>("PriceWithTax");

                    b.Property<float>("Tax");

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

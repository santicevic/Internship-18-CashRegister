using CashRegister.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Data.Entities
{
    public class CashRegisterContext : DbContext
    {
        public CashRegisterContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cashier> Cashiers  { get; set; }
        public DbSet<Models.CashRegister> CashRegisters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemReceipt> ItemReceipts { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemReceipt>()
                .HasKey(ir => new { ir.ItemId, ir.ReceiptId });
            modelBuilder.Entity<ItemReceipt>()
                .HasOne(ir => ir.Item)
                .WithMany(i => i.ItemReceipts)
                .HasForeignKey(ir => ir.ItemId);
            modelBuilder.Entity<ItemReceipt>()
                .HasOne(ir => ir.Receipt)
                .WithMany(r => r.ItemReceipts)
                .HasForeignKey(ir => ir.ReceiptId);

            modelBuilder.Entity<Models.CashRegister>().HasData(
            new Models.CashRegister { Id = 1 });
            modelBuilder.Entity<Models.CashRegister>().HasData(
            new Models.CashRegister { Id = 2 });
            modelBuilder.Entity<Models.CashRegister>().HasData(
            new Models.CashRegister { Id = 3 });
            modelBuilder.Entity<Models.CashRegister>().HasData(
            new Models.CashRegister { Id = 4 });

            modelBuilder.Entity<Cashier>().HasData(
            new Cashier { Id = 1, Name="Ivana Ivanković" });
            modelBuilder.Entity<Cashier>().HasData(
            new Cashier { Id = 2, Name = "Marko Marković" });
            modelBuilder.Entity<Cashier>().HasData(
            new Cashier { Id = 3, Name = "Jure Jurić" });
            modelBuilder.Entity<Cashier>().HasData(
            new Cashier { Id = 4, Name = "Marija Marić" });

            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 1, Name = "Juha u vrečici", Barcode = "4383294211", PriceWithTax = 12.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 2, Name = "Kruh didov", Barcode = "4383520151", PriceWithTax = 6.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 3, Name = "Choco loco", Barcode = "6201694211", PriceWithTax = 10.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 4, Name = "Vrečica velika", Barcode = "4380284111", PriceWithTax = 0.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 5, Name = "Vrečica mala", Barcode = "4383281055", PriceWithTax = 0.59F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 6, Name = "Brod na napuhivanje", Barcode = "4381172991", PriceWithTax = 123.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 7, Name = "Poli parizer", Barcode = "8821230211", PriceWithTax = 6.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 8, Name = "Majoneza", Barcode = "4389928510", PriceWithTax = 14.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 9, Name = "Kiseli krastavci", Barcode = "439912411", PriceWithTax = 9.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 10, Name = "Panirani odrezak", Barcode = "8822104211", PriceWithTax = 29.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 11, Name = "Tuna konzerva", Barcode = "43119834211", PriceWithTax = 12.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 12, Name = "Bublica", Barcode = "4382194211", PriceWithTax = 3.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 13, Name = "Heiniken pivo", Barcode = "4399994211", PriceWithTax = 8.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 14, Name = "Ožujsko pivo", Barcode = "4383292741", PriceWithTax = 7.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 15, Name = "IsoSport napitak", Barcode = "4329482911", PriceWithTax = 7.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 16, Name = "Coca-cola", Barcode = "4383299462", PriceWithTax = 6.99F, Tax = 25F, AmountInStock = 25 });
            modelBuilder.Entity<Item>().HasData(
            new Item { Id = 17, Name = "Čaše plastične", Barcode = "4383729131", PriceWithTax = 29.99F, Tax = 25F, AmountInStock = 25 });
        }
    }
}


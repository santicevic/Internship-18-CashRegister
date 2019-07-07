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
        }
    }
}


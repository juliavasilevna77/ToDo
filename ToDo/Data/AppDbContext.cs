using System;
using Microsoft.EntityFrameworkCore;
using ToDoListMVC.Models;

namespace ToDoListMVC.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(30);
                entity.Property(e => e.Description)
                      .IsRequired()
                      .HasMaxLength(600);
            });
        }
    }
}
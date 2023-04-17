using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DemoCrud.Models;

#nullable disable

namespace DemoCrud.Data
{
    public partial class FirstCrudContext : DbContext
    {
        public FirstCrudContext()
        {
        }

        public FirstCrudContext(DbContextOptions<FirstCrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;initial catalog=FirstCrud;trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Description).HasMaxLength(225);

                entity.Property(e => e.Name).HasMaxLength(225);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Author).HasMaxLength(225);

                entity.Property(e => e.Content).HasMaxLength(225);

                entity.Property(e => e.Description).HasMaxLength(225);

                entity.Property(e => e.Title).HasMaxLength(225);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

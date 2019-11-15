using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatingApp.API.Models
{
    public partial class DatingContext : DbContext
    {
        public DatingContext()
        {
        }

        public DatingContext(DbContextOptions<DatingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogComments> BlogComments { get; set; }
        public virtual DbSet<Blogs> Blogs { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredient { get; set; }
        public virtual DbSet<Users> Users { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogComments>(entity =>
            {
                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(500);

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogComments)
                    .HasForeignKey(d => d.BlogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlogComments_Blogs");
            });

            modelBuilder.Entity<Blogs>(entity =>
            {
                entity.HasKey(e => e.BlogId);

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.UniqId);

                entity.Property(e => e.UniqId).HasColumnName("uniqID");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.ToTable("photos");

                entity.Property(e => e.DateAdded)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_photos_Users");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.UniqId);

                entity.Property(e => e.UniqId).HasColumnName("UniqID");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.ImagePath)
                    .HasColumnName("imagePath")
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.HasKey(e => e.UniqId);

                entity.Property(e => e.UniqId).HasColumnName("uniqID");

                entity.Property(e => e.IngredientId).HasColumnName("ingredientId");

                entity.Property(e => e.RecipeId).HasColumnName("recipeId");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipeIngredient)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceipeIngredient_Ingredient");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeIngredient)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceipeIngredient_Recipe");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.LastActive)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class WebUserContext : DbContext
    {
        public WebUserContext()
        {
        }

        public WebUserContext(DbContextOptions<WebUserContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<User> User { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=WebUser;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.Property(e => e.CatId)
                    .HasColumnName("Cat_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CatName)
                    .HasColumnName("Cat_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProCode);

                entity.Property(e => e.ProCode)
                    .HasColumnName("Pro_Code")
                    .ValueGeneratedNever();

                entity.Property(e => e.CatId).HasColumnName("Cat_ID");

                entity.Property(e => e.ProDescription)
                    .HasColumnName("Pro_Description")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProName)
                    .HasColumnName("Pro_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProPrice)
                    .HasColumnName("Pro_Price")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProQty)
                    .HasColumnName("Pro_qty")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProUnitPerPrice)
                    .HasColumnName("Pro_UnitPerPrice")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UnitId).HasColumnName("Unit_ID");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_Product_Unit");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.Property(e => e.TitleId)
                    .HasColumnName("Title_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TitleName)
                    .HasColumnName("Title_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.UnitId)
                    .HasColumnName("Unit_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UnitName)
                    .HasColumnName("Unit_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TitleId).HasColumnName("Title_ID");

                entity.Property(e => e.UserLast)
                    .HasColumnName("User_Last")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("User_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.TitleId)
                    .HasConstraintName("FK_User_Title");
            });
        }
    }
}

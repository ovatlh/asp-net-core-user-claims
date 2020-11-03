using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aspApp.Models
{
    public partial class dbloginclaimsContext : DbContext
    {
        public dbloginclaimsContext()
        {
        }

        public dbloginclaimsContext(DbContextOptions<dbloginclaimsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claims> Claims { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Rolclaims> Rolclaims { get; set; }
        public virtual DbSet<Startpage> Startpage { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost; user id=root; password=root; database=dbloginclaims;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claims>(entity =>
            {
                entity.ToTable("claims");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.HasIndex(e => e.IdStartPage)
                    .HasName("fk_rol_startpage1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdStartPage)
                    .HasColumnName("idStartPage")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdStartPageNavigation)
                    .WithMany(p => p.Rol)
                    .HasForeignKey(d => d.IdStartPage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rol_startpage1");
            });

            modelBuilder.Entity<Rolclaims>(entity =>
            {
                entity.ToTable("rolclaims");

                entity.HasIndex(e => e.IdClaims)
                    .HasName("fk_rolclaims_claims1_idx");

                entity.HasIndex(e => e.IdRol)
                    .HasName("fk_rol_has_claim_rol_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdClaims)
                    .HasColumnName("idClaims")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdRol)
                    .HasColumnName("idRol")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdClaimsNavigation)
                    .WithMany(p => p.Rolclaims)
                    .HasForeignKey(d => d.IdClaims)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rolclaims_claims1");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Rolclaims)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rol_has_claim_rol");
            });

            modelBuilder.Entity<Startpage>(entity =>
            {
                entity.ToTable("startpage");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnType("varchar(300)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.IdRol)
                    .HasName("fk_user_rol1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdRol)
                    .HasColumnName("idRol")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_rol1");
            });
        }
    }
}

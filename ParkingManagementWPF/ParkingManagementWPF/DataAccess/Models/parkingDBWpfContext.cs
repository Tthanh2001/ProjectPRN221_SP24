using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace _DataAccess.Models
{
    public partial class parkingDBWpfContext : DbContext
    {
        public parkingDBWpfContext()
        {
        }

        public parkingDBWpfContext(DbContextOptions<parkingDBWpfContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Lot> Lots { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
        public virtual DbSet<VehicleType> VehicleTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conf = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conf.GetConnectionString("DbConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.CheckInOut).HasColumnType("datetime");

                entity.Property(e => e.CheckInTime).HasColumnType("datetime");

                entity.Property(e => e.LotId).HasMaxLength(5);

                entity.Property(e => e.TotalPaid).HasColumnType("money");

                entity.Property(e => e.VehicleCode).HasMaxLength(20);

                entity.HasOne(d => d.Lot)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.LotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoices__LotId__300424B4");

                entity.HasOne(d => d.VehicleCodeNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.VehicleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoices__Vehicl__2F10007B");
            });

            modelBuilder.Entity<Lot>(entity =>
            {
                entity.Property(e => e.LotId).HasMaxLength(5);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Lots)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lots__TypeId__2C3393D0");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(225);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.VehicleCode)
                    .HasName("PK__Vehicles__4F9DC82EB080A00C");

                entity.Property(e => e.VehicleCode).HasMaxLength(20);

                entity.Property(e => e.Brand).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vehicles__TypeId__29572725");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vehicles__UserId__286302EC");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__VehicleT__516F03B52B811F1D");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.PricePerDay).HasColumnType("money");

                entity.Property(e => e.PricePerHour).HasColumnType("money");

                entity.Property(e => e.PricePerMonth).HasColumnType("money");

                entity.Property(e => e.PricePerWeek).HasColumnType("money");

                entity.Property(e => e.PricePerYear).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

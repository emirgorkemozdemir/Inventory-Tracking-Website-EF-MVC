using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Stok_Takip_Mvc_.net6.Models
{
    public partial class StokTakipVeritabanıContext : DbContext
    {
        public StokTakipVeritabanıContext()
        {
        }

        public StokTakipVeritabanıContext(DbContextOptions<StokTakipVeritabanıContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategoritablosu> Kategoritablosus { get; set; } = null!;
        public virtual DbSet<Musteritablosu> Musteritablosus { get; set; } = null!;
        public virtual DbSet<Satistablosu> Satistablosus { get; set; } = null!;
        public virtual DbSet<Uruntablosu> Uruntablosus { get; set; } = null!;
        public virtual DbSet<Uyetablosu> Uyetablosus { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-N542L05B;Database=StokTakipVeritabanı;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategoritablosu>(entity =>
            {
                entity.HasKey(e => e.Kategoriid);

                entity.ToTable("KATEGORITABLOSU");

                entity.Property(e => e.Kategoriid).HasColumnName("KATEGORIID");

                entity.Property(e => e.Kategoriad)
                    .HasMaxLength(50)
                    .HasColumnName("KATEGORIAD");
            });

            modelBuilder.Entity<Musteritablosu>(entity =>
            {
                entity.HasKey(e => e.Musteriid);

                entity.ToTable("MUSTERITABLOSU");

                entity.Property(e => e.Musteriid).HasColumnName("MUSTERIID");

                entity.Property(e => e.Musteriad)
                    .HasMaxLength(50)
                    .HasColumnName("MUSTERIAD");

                entity.Property(e => e.Musterisoyad)
                    .HasMaxLength(50)
                    .HasColumnName("MUSTERISOYAD");
            });

            modelBuilder.Entity<Satistablosu>(entity =>
            {
                entity.HasKey(e => e.Satisid);

                entity.ToTable("SATISTABLOSU");

                entity.Property(e => e.Satisid).HasColumnName("SATISID");

                entity.Property(e => e.Musteriid).HasColumnName("MUSTERIID");

                entity.Property(e => e.Satisadet).HasColumnName("SATISADET");

                entity.Property(e => e.Satisfiyat).HasColumnName("SATISFIYAT");

                entity.Property(e => e.Urunid).HasColumnName("URUNID");

                entity.HasOne(d => d.Musteri)
                    .WithMany(p => p.Satistablosus)
                    .HasForeignKey(d => d.Musteriid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SATISTABLOSU_MUSTERITABLOSU");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.Satistablosus)
                    .HasForeignKey(d => d.Urunid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SATISTABLOSU_URUNTABLOSU");
            });

            modelBuilder.Entity<Uruntablosu>(entity =>
            {
                entity.HasKey(e => e.Urunid);

                entity.ToTable("URUNTABLOSU");

                entity.Property(e => e.Urunid).HasColumnName("URUNID");

                entity.Property(e => e.Kategoriid).HasColumnName("KATEGORIID");

                entity.Property(e => e.Urunad)
                    .HasMaxLength(50)
                    .HasColumnName("URUNAD");

                entity.Property(e => e.Urunfiyat).HasColumnName("URUNFIYAT");

                entity.Property(e => e.Urunstok).HasColumnName("URUNSTOK");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Uruntablosus)
                    .HasForeignKey(d => d.Kategoriid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_URUNTABLOSU_KATEGORITABLOSU");
            });

            modelBuilder.Entity<Uyetablosu>(entity =>
            {
                entity.HasKey(e => e.UyeId);

                entity.ToTable("UYETABLOSU");

                entity.Property(e => e.UyeId).HasColumnName("UyeID");

                entity.Property(e => e.UyeKullanıcıAdı).HasMaxLength(50);

                entity.Property(e => e.UyeSifre).HasMaxLength(64);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

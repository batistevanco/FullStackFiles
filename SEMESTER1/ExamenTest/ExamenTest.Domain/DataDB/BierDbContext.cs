using System;
using System.Collections.Generic;
using ExamenTest.Domain.EntitiesDB;
using Microsoft.EntityFrameworkCore;

namespace ExamenTest.Domain.DataDB;

public partial class BierDbContext : DbContext
{
    public BierDbContext()
    {
    }

    public BierDbContext(DbContextOptions<BierDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beers2> Beers2s { get; set; }

    public virtual DbSet<Breweries2> Breweries2s { get; set; }

    public virtual DbSet<Varieties2> Varieties2s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQL22_VIVES; Database=ExamenTest;Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beers2>(entity =>
        {
            entity.HasKey(e => e.Biernr);

            entity.ToTable("Beers2");

            entity.Property(e => e.Biernr).ValueGeneratedNever();
            entity.Property(e => e.Alcohol).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Naam)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.BrouwernrNavigation).WithMany(p => p.Beers2s)
                .HasForeignKey(d => d.Brouwernr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Beers2_Breweries2");

            entity.HasOne(d => d.SoortnrNavigation).WithMany(p => p.Beers2s)
                .HasForeignKey(d => d.Soortnr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Beers2_Varieties2");
        });

        modelBuilder.Entity<Breweries2>(entity =>
        {
            entity.HasKey(e => e.Brouwernr);

            entity.ToTable("Breweries2");

            entity.Property(e => e.Brouwernr).ValueGeneratedNever();
            entity.Property(e => e.Adres)
                .HasMaxLength(60)
                .IsFixedLength();
            entity.Property(e => e.Gemeente)
                .HasMaxLength(40)
                .IsFixedLength();
            entity.Property(e => e.Naam)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Omzet).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Postcode)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Varieties2>(entity =>
        {
            entity.HasKey(e => e.Soortnr).HasName("PK_Varieties");

            entity.ToTable("Varieties2");

            entity.Property(e => e.Soortnr).ValueGeneratedNever();
            entity.Property(e => e.Soortnaam)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

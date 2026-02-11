using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using vancoillie_batiste.Domain.EntitiesDB;

namespace vancoillie_batiste.Domain.DataDB;

public partial class LiedjesDbContext : DbContext
{
    public LiedjesDbContext()
    {
    }

    public LiedjesDbContext(DbContextOptions<LiedjesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Liedje> Liedjes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQL22_VIVES; Database=liedjesSQL;Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreNr);

            entity.ToTable("Genre");

            entity.Property(e => e.GenreNr).ValueGeneratedNever();
            entity.Property(e => e.Genre1)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("Genre");
        });

        modelBuilder.Entity<Liedje>(entity =>
        {
            entity.HasKey(e => e.SongNr)
                .HasName("aaaaaLiedjes_PK")
                .IsClustered(false);

            entity.Property(e => e.Artiest).HasMaxLength(50);
            entity.Property(e => e.Speelduur).HasMaxLength(4);
            entity.Property(e => e.Titel).HasMaxLength(50);

            entity.HasOne(d => d.GenrenrNavigation).WithMany(p => p.Liedjes)
                .HasForeignKey(d => d.Genrenr)
                .HasConstraintName("FK_Liedjes_Genre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

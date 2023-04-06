using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrtalaMatik.Models.Entities;

public partial class HesaplamatikdbContext : DbContext
{
    internal object lessons;

    public HesaplamatikdbContext()
    {
    }

    public HesaplamatikdbContext(DbContextOptions<HesaplamatikdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lessons> Lessons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=hesaplamatikdb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf16_turkish_ci")
            .HasCharSet("utf16");

        modelBuilder.Entity<Lessons>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lessons");

            entity.Property(e => e.LessonName)
                .HasMaxLength(50)
                .HasColumnName("LessonName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

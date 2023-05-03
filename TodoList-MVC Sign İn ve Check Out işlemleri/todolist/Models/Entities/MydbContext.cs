using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Models.Entities;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todo>? Todos { get; set; }

    public virtual DbSet<User>? Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseMySql("server=localhost;port=3306;database=mydb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_turkish_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("todo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsComplated).HasColumnName("isComplated");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

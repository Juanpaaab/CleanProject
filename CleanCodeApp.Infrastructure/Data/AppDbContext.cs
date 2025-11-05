using Microsoft.EntityFrameworkCore;
using CleanCodeApp.Domain.Entities;

namespace CleanCodeApp.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TaskEstado> TaskEstados { get; set; }

    public virtual DbSet<Taskmanager> Taskmanagers { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskEstado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("task_estado_pk");

            entity.ToTable("task_estado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Taskmanager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("taskmanager_pk");

            entity.ToTable("taskmanager");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EstadoId).HasColumnName("estado_id");
            entity.Property(e => e.Nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");

            entity.HasOne(d => d.Estado).WithMany(p => p.Taskmanagers)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estado_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Adoption_MVC.Models;

public partial class AdoptionDbContext : DbContext
{
    public AdoptionDbContext()
    {
    }

    public AdoptionDbContext(DbContextOptions<AdoptionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Testimonial> Testimonials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=AdoptionDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Animals__3214EC27526B52C9");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Img).HasColumnName("img");
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Testimon__3214EC276C9F43C0");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Breed)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.DateTimeColumn).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsFixedLength();
            entity.Property(e => e.Owner)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.PetName)
                .HasMaxLength(25)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace soc_backend_api.Models
{
    public partial class StickOnCarContext : DbContext
    {
        public StickOnCarContext()
        {
        }

        public StickOnCarContext(DbContextOptions<StickOnCarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Driving> Drivings { get; set; }
        public virtual DbSet<Person> People { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("Car");

                entity.Property(e => e.Brand)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Driving>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("Driving");

                entity.Property(e => e.KmPerWeek).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Region)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("Person");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FkCar).HasColumnName("FK_Car");

                entity.Property(e => e.FkDriving).HasColumnName("FK_Driving");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkCarNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.FkCar)
                    .HasConstraintName("FK_Car");

                entity.HasOne(d => d.FkDrivingNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.FkDriving)
                    .HasConstraintName("FK_Driving");
            });

        }

    }
}

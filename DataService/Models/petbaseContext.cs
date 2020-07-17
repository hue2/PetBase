using Microsoft.EntityFrameworkCore;

namespace Petbase.DataService.Models
{
    public partial class PetbaseContext : DbContext
    {
        public PetbaseContext()
        {
        }

        public PetbaseContext(DbContextOptions<PetbaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cats> Cats { get; set; }
        public virtual DbSet<Dogs> Dogs { get; set; }
        public virtual DbSet<Rabbits> Rabbits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Cats>(entity =>
            {
                entity.ToTable("cats", "petbase");

                entity.Property(e => e.Id)
                    .HasColumnName("﻿ID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Coat).IsUnicode(false);

                entity.Property(e => e.LifeSpan).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PictureUrl).IsUnicode(false);

                entity.Property(e => e.Size).IsUnicode(false);

                entity.Property(e => e.UniqueTraits).IsUnicode(false);
            });

            modelBuilder.Entity<Dogs>(entity =>
            {
                entity.ToTable("dogs", "petbase");

                entity.Property(e => e.Id)
                    .HasColumnName("﻿ID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Coat).IsUnicode(false);

                entity.Property(e => e.LifeSpan).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PictureUrl).IsUnicode(false);

                entity.Property(e => e.Size).IsUnicode(false);

                entity.Property(e => e.UniqueTraits).IsUnicode(false);
            });

            modelBuilder.Entity<Rabbits>(entity =>
            {
                entity.ToTable("rabbits", "petbase");

                entity.Property(e => e.Id)
                    .HasColumnName("﻿ID")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Coat).IsUnicode(false);

                entity.Property(e => e.LifeSpan).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PictureUrl).IsUnicode(false);

                entity.Property(e => e.Size).IsUnicode(false);

                entity.Property(e => e.UniqueTraits).IsUnicode(false);
            });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web2Hotel.Models
{
    public partial class Web2HotelContext : DbContext
    {
        public Web2HotelContext()
        {
        }

        public Web2HotelContext(DbContextOptions<Web2HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Habitacion> Habitacion { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=rootroot;Database=Web2Hotel");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Estado).HasColumnType("varchar(45)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Habitacion>(entity =>
            {
                entity.HasIndex(e => e.Numero)
                    .HasName("Numero_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Capacidad).HasColumnType("int(11)");

                entity.Property(e => e.Numero).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasIndex(e => e.CreationId)
                    .HasName("Creator_idx");

                entity.HasIndex(e => e.HabitacionId)
                    .HasName("Habitacion_idx");

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("User_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationId).HasColumnType("int(11)");

                entity.Property(e => e.Duracion).HasColumnType("int(11)");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.HabitacionId).HasColumnType("int(11)");

                entity.Property(e => e.UsuarioId).HasColumnType("int(11)");

                entity.HasOne(d => d.Creation)
                    .WithMany(p => p.ReservaCreation)
                    .HasForeignKey(d => d.CreationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Creator");

                entity.HasOne(d => d.Habitacion)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.HabitacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Habitacion");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ReservaUsuario)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .HasName("Username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Apelllido)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Email).HasColumnType("varchar(45)");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Telefono).HasColumnType("varchar(45)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(45)");
            });
        }
    }
}

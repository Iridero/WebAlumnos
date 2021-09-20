using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAlumnos.Models
{
    public partial class alumnadoContext : DbContext
    {
        public alumnadoContext()
        {
        }

        public alumnadoContext(DbContextOptions<alumnadoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user id=root;password=root;database=alumnado", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.Control)
                    .HasName("PRIMARY");

                entity.ToTable("alumnos");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Idcarrera, "FK_alumnos_1");

                entity.Property(e => e.Control)
                    .HasMaxLength(10)
                    .HasColumnName("control");

                entity.Property(e => e.Entrada)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("entrada");

                entity.Property(e => e.Idcarrera)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("idcarrera")
                    .IsFixedLength(true);

                entity.Property(e => e.Materno)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("materno");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.Paterno)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("paterno");

                entity.Property(e => e.Sexo)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("sexo");

                entity.HasOne(d => d.IdcarreraNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.Idcarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_alumnos_1");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.Clave)
                    .HasName("PRIMARY");

                entity.ToTable("carrera");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Clave)
                    .HasMaxLength(1)
                    .HasColumnName("clave")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

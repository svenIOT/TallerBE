using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Taller.DAL.Models
{
    public partial class tallerContext : DbContext
    {
        public tallerContext()
        {
        }

        public tallerContext(DbContextOptions<tallerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciclomotor> Ciclomotor { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Coche> Coche { get; set; }
        public virtual DbSet<Concesionario> Concesionario { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Jefe> Jefe { get; set; }
        public virtual DbSet<Mecanico> Mecanico { get; set; }
        public virtual DbSet<Motocicleta> Motocicleta { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Propuesta> Propuesta { get; set; }
        public virtual DbSet<Reparacion> Reparacion { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=1234;database=taller", x => x.ServerVersion("8.0.21-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciclomotor>(entity =>
            {
                entity.HasKey(e => e.MatCiclo)
                    .HasName("PRIMARY");

                entity.ToTable("ciclomotor");

                entity.HasIndex(e => e.MatCiclo)
                    .HasName("mat_ciclo")
                    .IsUnique();

                entity.HasIndex(e => e.NumBastidor)
                    .HasName("num_bastidor");

                entity.Property(e => e.MatCiclo)
                    .HasColumnName("mat_ciclo")
                    .HasColumnType("varchar(7)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NumBastidor)
                    .IsRequired()
                    .HasColumnName("num_bastidor")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.NumBastidorNavigation)
                    .WithMany(p => p.Ciclomotor)
                    .HasForeignKey(d => d.NumBastidor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ciclomotor_ibfk_1");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodCliente)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.HasIndex(e => e.Dni)
                    .HasName("dni");

                entity.Property(e => e.CodCliente).HasColumnName("cod_cliente");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasColumnType("varchar(9)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.DniNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.Dni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cliente_ibfk_1");
            });

            modelBuilder.Entity<Coche>(entity =>
            {
                entity.HasKey(e => e.MatCoche)
                    .HasName("PRIMARY");

                entity.ToTable("coche");

                entity.HasIndex(e => e.MatCoche)
                    .HasName("mat_coche")
                    .IsUnique();

                entity.HasIndex(e => e.NumBastidor)
                    .HasName("num_bastidor");

                entity.Property(e => e.MatCoche)
                    .HasColumnName("mat_coche")
                    .HasColumnType("varchar(7)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NumBastidor)
                    .IsRequired()
                    .HasColumnName("num_bastidor")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.NumBastidorNavigation)
                    .WithMany(p => p.Coche)
                    .HasForeignKey(d => d.NumBastidor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("coche_ibfk_1");
            });

            modelBuilder.Entity<Concesionario>(entity =>
            {
                entity.HasKey(e => e.CodConce)
                    .HasName("PRIMARY");

                entity.ToTable("concesionario");

                entity.Property(e => e.CodConce).HasColumnName("cod_conce");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.CodEmpleado)
                    .HasName("PRIMARY");

                entity.ToTable("empleado");

                entity.HasIndex(e => e.CodConce)
                    .HasName("cod_conce");

                entity.HasIndex(e => e.Dni)
                    .HasName("dni");

                entity.HasIndex(e => e.Usuario)
                    .HasName("usuario")
                    .IsUnique();

                entity.Property(e => e.CodEmpleado).HasColumnName("cod_empleado");

                entity.Property(e => e.CodConce).HasColumnName("cod_conce");

                entity.Property(e => e.Contrasena)
                    .HasColumnName("contrasena")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasColumnType("varchar(9)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.CodConceNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.CodConce)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empleado_ibfk_1");

                entity.HasOne(d => d.DniNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.Dni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empleado_ibfk_2");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.CodEspecialidad)
                    .HasName("PRIMARY");

                entity.ToTable("especialidad");

                entity.Property(e => e.CodEspecialidad).HasColumnName("cod_especialidad");

                entity.Property(e => e.NombreEsp)
                    .HasColumnName("nombre_esp")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Jefe>(entity =>
            {
                entity.HasKey(e => e.CodJefe)
                    .HasName("PRIMARY");

                entity.ToTable("jefe");

                entity.HasIndex(e => e.CodEmpleado)
                    .HasName("cod_empleado");

                entity.Property(e => e.CodJefe).HasColumnName("cod_jefe");

                entity.Property(e => e.CodEmpleado).HasColumnName("cod_empleado");

                entity.HasOne(d => d.CodEmpleadoNavigation)
                    .WithMany(p => p.Jefe)
                    .HasForeignKey(d => d.CodEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jefe_ibfk_1");
            });

            modelBuilder.Entity<Mecanico>(entity =>
            {
                entity.HasKey(e => e.CodMecanico)
                    .HasName("PRIMARY");

                entity.ToTable("mecanico");

                entity.HasIndex(e => e.CodEmpleado)
                    .HasName("cod_empleado");

                entity.HasIndex(e => e.CodEspecialidad)
                    .HasName("cod_especialidad");

                entity.HasIndex(e => e.CodMecanicoJefe)
                    .HasName("cod_mecanico_jefe");

                entity.Property(e => e.CodMecanico).HasColumnName("cod_mecanico");

                entity.Property(e => e.CodEmpleado).HasColumnName("cod_empleado");

                entity.Property(e => e.CodEspecialidad).HasColumnName("cod_especialidad");

                entity.Property(e => e.CodMecanicoJefe).HasColumnName("cod_mecanico_jefe");

                entity.HasOne(d => d.CodEmpleadoNavigation)
                    .WithMany(p => p.Mecanico)
                    .HasForeignKey(d => d.CodEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mecanico_ibfk_1");

                entity.HasOne(d => d.CodEspecialidadNavigation)
                    .WithMany(p => p.Mecanico)
                    .HasForeignKey(d => d.CodEspecialidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mecanico_ibfk_2");

                entity.HasOne(d => d.CodMecanicoJefeNavigation)
                    .WithMany(p => p.InverseCodMecanicoJefeNavigation)
                    .HasForeignKey(d => d.CodMecanicoJefe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mecanico_ibfk_3");
            });

            modelBuilder.Entity<Motocicleta>(entity =>
            {
                entity.HasKey(e => e.MatMoto)
                    .HasName("PRIMARY");

                entity.ToTable("motocicleta");

                entity.HasIndex(e => e.MatMoto)
                    .HasName("mat_moto")
                    .IsUnique();

                entity.HasIndex(e => e.NumBastidor)
                    .HasName("num_bastidor");

                entity.Property(e => e.MatMoto)
                    .HasColumnName("mat_moto")
                    .HasColumnType("varchar(7)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NumBastidor)
                    .IsRequired()
                    .HasColumnName("num_bastidor")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.NumBastidorNavigation)
                    .WithMany(p => p.Motocicleta)
                    .HasForeignKey(d => d.NumBastidor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("motocicleta_ibfk_1");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("PRIMARY");

                entity.ToTable("persona");

                entity.HasIndex(e => e.Dni)
                    .HasName("dni")
                    .IsUnique();

                entity.Property(e => e.Dni)
                    .HasColumnName("dni")
                    .HasColumnType("varchar(9)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Apellidos)
                    .HasColumnName("apellidos")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("varchar(9)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Propuesta>(entity =>
            {
                entity.HasKey(e => e.CodPropuesta)
                    .HasName("PRIMARY");

                entity.ToTable("propuesta");

                entity.HasIndex(e => e.CodCliente)
                    .HasName("cod_cliente");

                entity.HasIndex(e => e.CodVentas)
                    .HasName("cod_ventas");

                entity.HasIndex(e => e.NumBastidor)
                    .HasName("num_bastidor");

                entity.Property(e => e.CodPropuesta).HasColumnName("cod_propuesta");

                entity.Property(e => e.CodCliente).HasColumnName("cod_cliente");

                entity.Property(e => e.CodVentas).HasColumnName("cod_ventas");

                entity.Property(e => e.FechaValidez)
                    .HasColumnName("fecha_validez")
                    .HasColumnType("date");

                entity.Property(e => e.NumBastidor)
                    .IsRequired()
                    .HasColumnName("num_bastidor")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("varchar(6)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Vendido).HasColumnName("vendido");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.Propuesta)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("propuesta_ibfk_1");

                entity.HasOne(d => d.CodVentasNavigation)
                    .WithMany(p => p.Propuesta)
                    .HasForeignKey(d => d.CodVentas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("propuesta_ibfk_3");

                entity.HasOne(d => d.NumBastidorNavigation)
                    .WithMany(p => p.Propuesta)
                    .HasForeignKey(d => d.NumBastidor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("propuesta_ibfk_2");
            });

            modelBuilder.Entity<Reparacion>(entity =>
            {
                entity.HasKey(e => e.CodReparacion)
                    .HasName("PRIMARY");

                entity.ToTable("reparacion");

                entity.HasIndex(e => e.CodMecanico)
                    .HasName("cod_mecanico");

                entity.HasIndex(e => e.NumBastidor)
                    .HasName("num_bastidor");

                entity.Property(e => e.CodReparacion).HasColumnName("cod_reparacion");

                entity.Property(e => e.CodMecanico).HasColumnName("cod_mecanico");

                entity.Property(e => e.FechaEntrada)
                    .HasColumnName("fecha_entrada")
                    .HasColumnType("date");

                entity.Property(e => e.FechaSalida)
                    .HasColumnName("fecha_salida")
                    .HasColumnType("date");

                entity.Property(e => e.Finalizado).HasColumnName("finalizado");

                entity.Property(e => e.NumBastidor)
                    .IsRequired()
                    .HasColumnName("num_bastidor")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Piezas)
                    .HasColumnName("piezas")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("varchar(6)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.CodMecanicoNavigation)
                    .WithMany(p => p.Reparacion)
                    .HasForeignKey(d => d.CodMecanico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reparacion_ibfk_1");

                entity.HasOne(d => d.NumBastidorNavigation)
                    .WithMany(p => p.Reparacion)
                    .HasForeignKey(d => d.NumBastidor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reparacion_ibfk_2");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.NumBastidor)
                    .HasName("PRIMARY");

                entity.ToTable("vehiculo");

                entity.HasIndex(e => e.CodCliente)
                    .HasName("cod_cliente");

                entity.HasIndex(e => e.CodConce)
                    .HasName("cod_conce");

                entity.HasIndex(e => e.CodVentas)
                    .HasName("cod_ventas");

                entity.HasIndex(e => e.NumBastidor)
                    .HasName("num_bastidor")
                    .IsUnique();

                entity.Property(e => e.NumBastidor)
                    .HasColumnName("num_bastidor")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Anno)
                    .HasColumnName("anno")
                    .HasColumnType("varchar(4)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CodCliente).HasColumnName("cod_cliente");

                entity.Property(e => e.CodConce).HasColumnName("cod_conce");

                entity.Property(e => e.CodVentas).HasColumnName("cod_ventas");

                entity.Property(e => e.Combustible)
                    .HasColumnName("combustible")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Kilometros)
                    .HasColumnName("kilometros")
                    .HasColumnType("varchar(6)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Marca)
                    .HasColumnName("marca")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Modelo)
                    .HasColumnName("modelo")
                    .HasColumnType("varchar(35)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("varchar(6)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TipoVehiculo)
                    .HasColumnName("tipo_vehiculo")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.CodCliente)
                    .HasConstraintName("vehiculo_ibfk_1");

                entity.HasOne(d => d.CodConceNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.CodConce)
                    .HasConstraintName("vehiculo_ibfk_2");

                entity.HasOne(d => d.CodVentasNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.CodVentas)
                    .HasConstraintName("vehiculo_ibfk_3");
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.HasKey(e => e.CodVentas)
                    .HasName("PRIMARY");

                entity.ToTable("ventas");

                entity.HasIndex(e => e.CodEmpleado)
                    .HasName("cod_empleado");

                entity.Property(e => e.CodVentas).HasColumnName("cod_ventas");

                entity.Property(e => e.CodEmpleado).HasColumnName("cod_empleado");

                entity.HasOne(d => d.CodEmpleadoNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.CodEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ventas_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

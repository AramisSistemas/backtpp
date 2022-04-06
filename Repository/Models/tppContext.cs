using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository.Models
{
    public partial class tppContext : DbContext
    {
        public tppContext()
        {
        }

        public tppContext(DbContextOptions<tppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<ClienteGenero> ClienteGeneros { get; set; } = null!;
        public virtual DbSet<ClienteResponsabilidad> ClienteResponsabilidads { get; set; } = null!;
        public virtual DbSet<Esquema> Esquemas { get; set; } = null!;
        public virtual DbSet<Feriado> Feriados { get; set; } = null!;
        public virtual DbSet<Liquidacion> Liquidacions { get; set; } = null!;
        public virtual DbSet<ObraSocial> ObraSocials { get; set; } = null!;
        public virtual DbSet<OpAgrupacion> OpAgrupacions { get; set; } = null!;
        public virtual DbSet<OpComposicion> OpComposicions { get; set; } = null!;
        public virtual DbSet<OpConcepto> OpConceptos { get; set; } = null!;
        public virtual DbSet<OpDestino> OpDestinos { get; set; } = null!;
        public virtual DbSet<OpDetalleLiquidacion> OpDetalleLiquidacions { get; set; } = null!;
        public virtual DbSet<OpEmpleado> OpEmpleados { get; set; } = null!;
        public virtual DbSet<OpEmpleadoEmbargo> OpEmpleadoEmbargoes { get; set; } = null!;
        public virtual DbSet<OpManiobra> OpManiobras { get; set; } = null!;
        public virtual DbSet<OpPuesto> OpPuestos { get; set; } = null!;
        public virtual DbSet<Operacion> Operacions { get; set; } = null!;
        public virtual DbSet<OperacionManiobra> OperacionManiobras { get; set; } = null!;
        public virtual DbSet<ProveedorImputacion> ProveedorImputacions { get; set; } = null!;
        public virtual DbSet<SystemOption> SystemOptions { get; set; } = null!;
        public virtual DbSet<Turno> Turnos { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserLog> UserLogs { get; set; } = null!;
        public virtual DbSet<UserModule> UserModules { get; set; } = null!;
        public virtual DbSet<UserOperation> UserOperations { get; set; } = null!;
        public virtual DbSet<UserPerfil> UserPerfils { get; set; } = null!;
        public virtual DbSet<UserPerfilOperation> UserPerfilOperations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=RICARDO\\SERVER;Database=tpp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.HasIndex(e => e.Cuit, "KEY_Cliente_Cuit")
                    .IsUnique();

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Masculino')");

                entity.Property(e => e.Imputacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Mercaderia')");

                entity.Property(e => e.LimiteSaldo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreFantasia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Responsabilidad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Consumidor Final')");

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('s/d')");

                entity.HasOne(d => d.GeneroNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Genero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Genero");

                entity.HasOne(d => d.ImputacionNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Imputacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Imputacion");

                entity.HasOne(d => d.ResponsabilidadNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Responsabilidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Responsabilidad");
            });

            modelBuilder.Entity<ClienteGenero>(entity =>
            {
                entity.ToTable("ClienteGenero");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClienteResponsabilidad>(entity =>
            {
                entity.ToTable("ClienteResponsabilidad");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Esquema>(entity =>
            {
                entity.ToTable("Esquema");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Feriado>(entity =>
            {
                entity.HasKey(e => e.Fecha)
                    .HasName("PK_Feriados_Fecha");

                entity.ToTable("Feriado");

                entity.Property(e => e.Fecha).HasColumnType("date");
            });

            modelBuilder.Entity<Liquidacion>(entity =>
            {
                entity.ToTable("Liquidacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cbu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Llave)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Operador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OperadorConfirma)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmpleadoNavigation)
                    .WithMany(p => p.Liquidacions)
                    .HasForeignKey(d => d.Empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Liquidacion_Empleado");

                entity.HasOne(d => d.OperacionNavigation)
                    .WithMany(p => p.Liquidacions)
                    .HasForeignKey(d => d.Operacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Liquidacion_Operacion");

                entity.HasOne(d => d.PuestoNavigation)
                    .WithMany(p => p.Liquidacions)
                    .HasForeignKey(d => d.Puesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Liquidacion_Puesto");
            });

            modelBuilder.Entity<ObraSocial>(entity =>
            {
                entity.ToTable("ObraSocial");

                entity.HasIndex(e => e.Id, "KEY_ObraSocial_Id")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Detalle).IsUnicode(false);
            });

            modelBuilder.Entity<OpAgrupacion>(entity =>
            {
                entity.ToTable("OpAgrupacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OpComposicion>(entity =>
            {
                entity.ToTable("OpComposicion");

                entity.HasOne(d => d.EsquemaNavigation)
                    .WithMany(p => p.OpComposicions)
                    .HasForeignKey(d => d.Esquema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpComposicion_Esquema");

                entity.HasOne(d => d.ManiobraNavigation)
                    .WithMany(p => p.OpComposicions)
                    .HasForeignKey(d => d.Maniobra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpComposicion_Maniobra");

                entity.HasOne(d => d.PuestoNavigation)
                    .WithMany(p => p.OpComposicions)
                    .HasForeignKey(d => d.Puesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpComposicion_Puesto");
            });

            modelBuilder.Entity<OpConcepto>(entity =>
            {
                entity.ToTable("OpConcepto");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Concepto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.AgrupacionNavigation)
                    .WithMany(p => p.OpConceptos)
                    .HasForeignKey(d => d.Agrupacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpConcepto_Agrupacion");
            });

            modelBuilder.Entity<OpDestino>(entity =>
            {
                entity.ToTable("OpDestino");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OpDetalleLiquidacion>(entity =>
            {
                entity.ToTable("OpDetalleLiquidacion");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Concepto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ManiobraOpFkNavigation)
                    .WithMany(p => p.OpDetalleLiquidacions)
                    .HasForeignKey(d => d.ManiobraOpFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpDetalleLiquidacion_ManiobraOpFk");

                entity.HasOne(d => d.PuestoFkNavigation)
                    .WithMany(p => p.OpDetalleLiquidacions)
                    .HasForeignKey(d => d.PuestoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpDetalleLiquidacion_PuestoFk");
            });

            modelBuilder.Entity<OpEmpleado>(entity =>
            {
                entity.ToTable("OpEmpleado");

                entity.HasIndex(e => e.Nombre, "IDX_OpEmpleado_Nombre");

                entity.HasIndex(e => e.Cuil, "KEY_OpEmpleado_Cuil")
                    .IsUnique();

                entity.Property(e => e.Cbu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ingreso)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nacimiento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Osocial).HasColumnName("OSocial");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('M')")
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.HasOne(d => d.OsocialNavigation)
                    .WithMany(p => p.OpEmpleados)
                    .HasForeignKey(d => d.Osocial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpEmpleado_OSocial");
            });

            modelBuilder.Entity<OpEmpleadoEmbargo>(entity =>
            {
                entity.ToTable("OpEmpleadoEmbargo");

                entity.Property(e => e.Concepto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fin).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Operador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.EmpleadoFkNavigation)
                    .WithMany(p => p.OpEmpleadoEmbargoes)
                    .HasForeignKey(d => d.EmpleadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpEmpleadoEmbargo_EmpleadoFk");
            });

            modelBuilder.Entity<OpManiobra>(entity =>
            {
                entity.ToTable("OpManiobra");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OpPuesto>(entity =>
            {
                entity.ToTable("OpPuesto");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AgrupacionNavigation)
                    .WithMany(p => p.OpPuestos)
                    .HasForeignKey(d => d.Agrupacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpPuesto_Agrupacion");
            });

            modelBuilder.Entity<Operacion>(entity =>
            {
                entity.ToTable("Operacion");

                entity.Property(e => e.Fin)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Inicio).HasColumnType("datetime");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacion_Cliente");

                entity.HasOne(d => d.DestinoNavigation)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.Destino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacion_Destino");

                entity.HasOne(d => d.EsquemaNavigation)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.Esquema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacion_Esquema");
            });

            modelBuilder.Entity<OperacionManiobra>(entity =>
            {
                entity.ToTable("OperacionManiobra");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Produccion).HasColumnType("decimal(15, 3)");

                entity.HasOne(d => d.ManiobraNavigation)
                    .WithMany(p => p.OperacionManiobras)
                    .HasForeignKey(d => d.Maniobra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperacionManiobra_Maniobra");

                entity.HasOne(d => d.OperacionNavigation)
                    .WithMany(p => p.OperacionManiobras)
                    .HasForeignKey(d => d.Operacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperacionManiobra_Operacion");

                entity.HasOne(d => d.TurnoNavigation)
                    .WithMany(p => p.OperacionManiobras)
                    .HasForeignKey(d => d.Turno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperacionManiobra_Turno");
            });

            modelBuilder.Entity<ProveedorImputacion>(entity =>
            {
                entity.ToTable("ProveedorImputacion");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SystemOption>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Contacto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cuit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Razon)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.ToTable("Turno");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Esquema).HasDefaultValueSql("((1))");

                entity.Property(e => e.Horario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EsquemaNavigation)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.Esquema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Turno_Esquema");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.EndOfLife)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(day,(-1),getdate()))");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Perfil).HasDefaultValueSql("((1))");

                entity.Property(e => e.Username).HasColumnName("Username ");

                entity.HasOne(d => d.PerfilNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Perfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Perfil");
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.ToTable("UserLog");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Modulo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Operador)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserModule>(entity =>
            {
                entity.ToTable("UserModule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Modulo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modulo");
            });

            modelBuilder.Entity<UserOperation>(entity =>
            {
                entity.ToTable("UserOperation");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Modulo).HasColumnName("modulo");

                entity.Property(e => e.Operacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("operacion");

                entity.HasOne(d => d.ModuloNavigation)
                    .WithMany(p => p.UserOperations)
                    .HasForeignKey(d => d.Modulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_seguridadOperacion_modulo");
            });

            modelBuilder.Entity<UserPerfil>(entity =>
            {
                entity.ToTable("UserPerfil");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rol");
            });

            modelBuilder.Entity<UserPerfilOperation>(entity =>
            {
                entity.ToTable("UserPerfilOperation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOperacion).HasColumnName("idOperacion");

                entity.Property(e => e.IdPerfil).HasColumnName("idPerfil");

                entity.HasOne(d => d.IdOperacionNavigation)
                    .WithMany(p => p.UserPerfilOperations)
                    .HasForeignKey(d => d.IdOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPerfilOperation_idOperacion");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.UserPerfilOperations)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_seguridadPerfilOperacion_idPerfil");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api_soportevirtual.Models;

public partial class Test1Context : DbContext
{
    public Test1Context()
    {
    }

    public Test1Context(DbContextOptions<Test1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketImagene> TicketImagenes { get; set; }

    public virtual DbSet<TipoError> TipoErrors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GRT0OGU\\SQLEXPRESS;Database=test1;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE6F0853C58A0");

            entity.ToTable("Empleado");

            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Area).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.EmpresaId).HasName("PK__Empresa__7B9F2136602AAF49");

            entity.ToTable("Empresa");

            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.Direccion).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.RazonSocial).HasMaxLength(50);
            entity.Property(e => e.Ruc).HasMaxLength(11);
            entity.Property(e => e.Telefono).HasMaxLength(50);
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Estado__FEF86B6013C9675E");

            entity.ToTable("Estado");

            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.Descripccion).HasMaxLength(255);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolesId).HasName("PK__Roles__C4B278206ABFD009");

            entity.Property(e => e.RolesId).HasColumnName("RolesID");
            entity.Property(e => e.NombreRoles).HasMaxLength(50);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Ticket__712CC627D3DFC5C1");

            entity.ToTable("Ticket");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.FechaCierre).HasColumnType("datetime");
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.NombreAplicativo).HasMaxLength(50);
            entity.Property(e => e.NombreBaseDatos).HasMaxLength(50);
            entity.Property(e => e.NombreServidor).HasMaxLength(50);
            entity.Property(e => e.TipoErrorId).HasColumnName("TipoErrorID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.VersionSoftware).HasMaxLength(50);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__Ticket__EmpresaI__5629CD9C");

            entity.HasOne(d => d.Estado).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Ticket__EstadoID__5812160E");

            entity.HasOne(d => d.TipoError).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TipoErrorId)
                .HasConstraintName("FK__Ticket__TipoErro__571DF1D5");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Ticket__UsuarioI__5535A963");
        });

        modelBuilder.Entity<TicketImagene>(entity =>
        {
            entity.HasKey(e => e.ImagenId).HasName("PK__TicketIm__0C7D20D7DC5D193D");

            entity.Property(e => e.ImagenId).HasColumnName("ImagenID");
            entity.Property(e => e.TicketId).HasColumnName("TicketID");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketImagenes)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__TicketIma__Ticke__5AEE82B9");
        });

        modelBuilder.Entity<TipoError>(entity =>
        {
            entity.HasKey(e => e.TipoErrorId).HasName("PK__TipoErro__A2D53E5CF3A42246");

            entity.ToTable("TipoError");

            entity.Property(e => e.TipoErrorId).HasColumnName("TipoErrorID");
            entity.Property(e => e.Descripccion).HasMaxLength(255);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE798591859CE");

            entity.ToTable("Usuario");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.NombreUsuario).HasMaxLength(50);
            entity.Property(e => e.PasswordSalt).HasMaxLength(256);
            entity.Property(e => e.Passwordhash).HasMaxLength(128);
            entity.Property(e => e.RolesId).HasColumnName("RolesID");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Usuario__Emplead__4E88ABD4");

            entity.HasOne(d => d.Roles).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolesId)
                .HasConstraintName("FK__Usuario__RolesID__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

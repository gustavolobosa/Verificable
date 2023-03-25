using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Verificable.Models;

public partial class BbddverificableContext : DbContext
{
    public BbddverificableContext()
    {
    }

    public BbddverificableContext(DbContextOptions<BbddverificableContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<FormAcquirer> FormAcquirers { get; set; }

    public virtual DbSet<FormDispossessor> FormDispossessors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //        => optionsBuilder.UseSqlServer("server= LAPTOP-DE-GUSTA; database= BBDDVerificable; integrated security=true; Encrypt=False;");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasKey(e => e.FormId).HasName("PK__Form__332ADAB568642F22");

            entity.ToTable("Form");

            entity.Property(e => e.FormId)
                .ValueGeneratedNever()
                .HasColumnName("Form_ID");
            entity.Property(e => e.Block)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cne)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CNE");
            entity.Property(e => e.Commune)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Property)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasColumnType("date")
                .HasColumnName("Registration_Date");
            entity.Property(e => e.RegistrationNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Registration_Number");
        });

        modelBuilder.Entity<FormAcquirer>(entity =>
        {
            entity.HasKey(e => e.FormAcquirerId).HasName("PK__Form_Acq__0623A0312A233444");

            entity.ToTable("Form_Acquirers");

            entity.Property(e => e.FormAcquirerId)
                .ValueGeneratedNever()
                .HasColumnName("Form_Acquirer_ID");
            entity.Property(e => e.AcquirerEntitlement)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Acquirer_Entitlement");
            entity.Property(e => e.AcquirerPercentNotCredited)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Acquirer_PercentNotCredited");
            entity.Property(e => e.AcquirerRunRut)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Acquirer_RUN_RUT");
            entity.Property(e => e.FormId).HasColumnName("Form_ID");

            entity.HasOne(d => d.Form).WithMany(p => p.FormAcquirers)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK__Form_Acqu__Form___29572725");
        });

        modelBuilder.Entity<FormDispossessor>(entity =>
        {
            entity.HasKey(e => e.FormDispossessorId).HasName("PK__Form_Dis__DB212B63E68BE008");

            entity.ToTable("Form_Dispossessors");

            entity.Property(e => e.FormDispossessorId)
                .ValueGeneratedNever()
                .HasColumnName("Form_Dispossessor_ID");
            entity.Property(e => e.DispossessorEntitlement)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Dispossessor_Entitlement");
            entity.Property(e => e.DispossessorPercentNotCredited)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Dispossessor_PercentNotCredited");
            entity.Property(e => e.DispossessorRunRut)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Dispossessor_RUN_RUT");
            entity.Property(e => e.FormId).HasColumnName("Form_ID");

            entity.HasOne(d => d.Form).WithMany(p => p.FormDispossessors)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK__Form_Disp__Form___267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

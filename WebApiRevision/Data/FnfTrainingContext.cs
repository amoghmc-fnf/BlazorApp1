using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiRevision.Data;

public partial class FnfTrainingContext : DbContext
{
    public FnfTrainingContext()
    {
    }

    public FnfTrainingContext(DbContextOptions<FnfTrainingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeptTable> DeptTables { get; set; }

    public virtual DbSet<EmpTable> EmpTables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeptTable>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__DeptTabl__BE2D26B6D3B8E749");

            entity.ToTable("DeptTable");

            entity.Property(e => e.DeptId).HasColumnName("deptId");
            entity.Property(e => e.DeptName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("deptName");
        });

        modelBuilder.Entity<EmpTable>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__EmpTable__AFB3EC0DB7DB540C");

            entity.ToTable("EmpTable");

            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.DeptId).HasColumnName("deptId");
            entity.Property(e => e.EmpAddress)
                .HasMaxLength(200)
                .HasColumnName("empAddress");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .HasColumnName("empName");
            entity.Property(e => e.EmpSalary)
                .HasColumnType("money")
                .HasColumnName("empSalary");

            entity.HasOne(d => d.Dept).WithMany(p => p.EmpTables)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__EmpTable__deptId__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

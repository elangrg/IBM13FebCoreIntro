using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IBM13FebCoreIntro.Models;

public partial class Ibm25jan24DbContext : DbContext
{
    public Ibm25jan24DbContext()
    {
    }

    public Ibm25jan24DbContext(DbContextOptions<Ibm25jan24DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeDept> EmployeeDepts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IBM25Jan24Db;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
          


            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("money");
        });

        modelBuilder.Entity<EmployeeDept>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.ToTable("EmployeeDept");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.DeptName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

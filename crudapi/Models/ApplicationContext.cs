using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using crudapi.Models.ViewModels;

namespace crudapi.Models;

public partial class ApplicationContext : DbContext
{
    
    private static void SetConnectionString(string connectionstring)
    {
        if (ConnectionString == null)
        {
            ConnectionString = connectionstring;
        }
        else
        {
            throw new Exception();
        }
    }
    private static string ConnectionString { get; set; }

    public ApplicationContext()
    {
    }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblDepartment> TblDepartments { get; set; }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    //ViewModels
    public virtual DbSet<ServerResponseModel> ServerResponseModels { get; set; }
    public virtual DbSet<CommonResponseModel> CommonResponseModels { get; set; }
    public virtual DbSet<DepartmentRequestModel> DepartmentRequestModels { get; set; }
    public virtual DbSet<EmployeeRequestModel> EmployeeRequestModels { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId);

            entity.ToTable("tblDepartment");

            entity.Property(e => e.DepartmentName).HasMaxLength(100);
        });

        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.ToTable("tblEmployee");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Department).WithMany(p => p.TblEmployees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblEmployee_tblDepartment");
        });

        modelBuilder.Entity<CommonResponseModel>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<ServerResponseModel>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<DepartmentRequestModel>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<EmployeeRequestModel>(entity =>
        {
            entity.HasNoKey();
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Admin.Models
{
    public partial class LeaveSystemContext : DbContext
    {
       

        public LeaveSystemContext(DbContextOptions<LeaveSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorizationTable> AuthorizationTable { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<LeaveService> LeaveService { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorizationTable>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("Authorization_Table");

                entity.Property(e => e.EmpId)
                    .HasColumnName("Emp_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pswd)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithOne(p => p.AuthorizationTable)
                    .HasForeignKey<AuthorizationTable>(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Authorization_Table_Employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__262359AB6C49822A");

                entity.Property(e => e.EmpId)
                    .HasColumnName("Emp_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasColumnName("Emp_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfLeaveLeft).HasColumnName("No_Of_Leave_Left");
            });

            modelBuilder.Entity<LeaveService>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.EmpId)
                    .HasColumnName("Emp_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasColumnName("Emp_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfDaysLeave).HasColumnName("No_Of_Days_Leave");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithOne(p => p.LeaveService)
                    .HasForeignKey<LeaveService>(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeaveService_Employee");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

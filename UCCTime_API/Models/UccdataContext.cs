using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UCCTime_API.Models;

public partial class UccdataContext : DbContext
{
    public UccdataContext()
    {
    }

    public UccdataContext(DbContextOptions<UccdataContext> options)
        : base(options)
    {
    }
    public virtual DbSet<timeSheetDTO> timeSheetDTO { get; set; }
    public virtual DbSet<TimesheetDetailedDTO> timeSheetDetailedDTO { get; set; }
    public virtual DbSet<TimesheetpostDTO> timesheetpostDTO { get; set; }

    


    public virtual DbSet<Approval> Approvals { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DisciplineCode> DisciplineCodes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Holiday> Holidays { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Stages> Stages { get; set; }

    public virtual DbSet<Tasks> Tasks { get; set; }

    public virtual DbSet<Timesheet> Timesheets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-7RU0IFA3\\SQLEXPRESS;Database=UCCData;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
     
        modelBuilder.Entity<Timesheet>(entity =>
        {
            entity.HasKey(e => e.TimesheetId).HasName("PK__Timeshee__848CBECD1631150A");
           
             entity.HasOne(e => e.Stage)
              .WithMany(s => s.Timesheets)
              .HasForeignKey(e => e.StageId)
              .OnDelete(DeleteBehavior.Cascade)
              .IsRequired(); // Ensures FK is properly mapped

        entity.HasOne(e => e.Task)
              .WithMany(t => t.Timesheets)
              .HasForeignKey(e => e.TaskId)
              .OnDelete(DeleteBehavior.Cascade)
              .IsRequired();

            entity.ToTable("Timesheets", tb => tb.HasTrigger("trg_Timesheet_Audit"));
            
        });
        modelBuilder.Entity<timeSheetDTO>().HasNoKey(); // ✅ Mark as keyless
        base.OnModelCreating(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<TimesheetDetailedDTO>().HasNoKey();
        //modelBuilder.Entity<TimesheetpostDTO>().HasNoKey();

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

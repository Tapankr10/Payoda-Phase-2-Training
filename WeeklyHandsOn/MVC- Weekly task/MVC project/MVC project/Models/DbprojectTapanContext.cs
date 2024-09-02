using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_project.Models;

public partial class DbprojectTapanContext : DbContext
{
    public DbprojectTapanContext()
    {
    }

    public DbprojectTapanContext(DbContextOptions<DbprojectTapanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BloodUnit> BloodUnits { get; set; }

    public virtual DbSet<Donor> Donors { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Event1> Events1 { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<Recipient> Recipients { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=PTSQLTESTDB01;database=DBProject_tapan;integrated security=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BloodUnit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK__BloodUni__44F5EC95389D8C8A");

            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.BloodType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.DonorId).HasColumnName("DonorID");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Available");

            entity.HasOne(d => d.Donor).WithMany(p => p.BloodUnits)
                .HasForeignKey(d => d.DonorId)
                .HasConstraintName("FK__BloodUnit__Donor__4CA06362");
        });

        modelBuilder.Entity<Donor>(entity =>
        {
            entity.HasKey(e => e.DonorId).HasName("PK__Donors__052E3F987495AAB5");

            entity.Property(e => e.DonorId).HasColumnName("DonorID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BloodType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1FAF0E40C");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__7944C870237CCF29");

            entity.ToTable("Event");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.EventName).HasMaxLength(100);
            entity.Property(e => e.Location).HasMaxLength(100);
        });

        modelBuilder.Entity<Event1>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__7944C870861FE373");

            entity.ToTable("Events");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.EventName).HasMaxLength(100);
            entity.Property(e => e.Location).HasMaxLength(100);
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.ParticipantId).HasName("PK__Particip__7227997E50656241");

            entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            entity.Property(e => e.ContactNumber).HasMaxLength(15);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.ParticipantName).HasMaxLength(100);

            entity.HasOne(d => d.Event).WithMany(p => p.Participants)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Participa__Event__76969D2E");
        });

        modelBuilder.Entity<Recipient>(entity =>
        {
            entity.HasKey(e => e.RecipientId).HasName("PK__Recipien__F0A601ADAC562633");

            entity.Property(e => e.RecipientId).HasColumnName("RecipientID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BloodType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.Recipients)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Recipients_Employees");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B690DEEE7F9");

            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.Activity).HasMaxLength(100);
            entity.Property(e => e.EventId).HasColumnName("EventID");

            entity.HasOne(d => d.Event).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Schedules__Event__797309D9");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4B756D1316");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.DonorId).HasColumnName("DonorID");
            entity.Property(e => e.RecipientId).HasColumnName("RecipientID");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");

            entity.HasOne(d => d.Donor).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.DonorId)
                .HasConstraintName("FK__Transacti__Donor__52593CB8");

            entity.HasOne(d => d.Recipient).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.RecipientId)
                .HasConstraintName("FK__Transacti__Recip__534D60F1");

            entity.HasOne(d => d.Unit).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__UnitI__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

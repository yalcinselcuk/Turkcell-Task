using System;
using System.Collections.Generic;
using DemoDbFirstEF.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoDbFirstEF.Data;

public partial class HighSchoolContext : DbContext
{
    public HighSchoolContext()
    {
    }

    public HighSchoolContext(DbContextOptions<HighSchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepartmentsLesson> DepartmentsLessons { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentsLesson> StudentsLessons { get; set; }

    public virtual DbSet<StudentsTeacher> StudentsTeachers { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=YALCINSELCUK-AC;Integrated Security=True;Initial Catalog=HighSchool;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departme__3213E83FD224708F");

            entity.ToTable("departments");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Departmenname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("departmenname");
            entity.Property(e => e.Departmennumber).HasColumnName("departmennumber");
        });

        modelBuilder.Entity<DepartmentsLesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departme__3213E83F475C5821");

            entity.ToTable("departmentsLessons");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Departmentid).HasColumnName("departmentid");
            entity.Property(e => e.Lessonid).HasColumnName("lessonid");

            entity.HasOne(d => d.Department).WithMany(p => p.DepartmentsLessons)
                .HasForeignKey(d => d.Departmentid)
                .HasConstraintName("FK__departmen__depar__49C3F6B7");

            entity.HasOne(d => d.Lesson).WithMany(p => p.DepartmentsLessons)
                .HasForeignKey(d => d.Lessonid)
                .HasConstraintName("FK__departmen__lesso__4AB81AF0");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lessons__3213E83FAB9353A6");

            entity.ToTable("lessons");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Lessonname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lessonname");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3213E83F7780E70C");

            entity.ToTable("students");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Departmenid).HasColumnName("departmenid");
            entity.Property(e => e.Firstname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Schoolnumber).HasColumnName("schoolnumber");

            entity.HasOne(d => d.Departmen).WithMany(p => p.Students)
                .HasForeignKey(d => d.Departmenid)
                .HasConstraintName("FK__Students__depart__398D8EEE");
        });

        modelBuilder.Entity<StudentsLesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__students__3213E83F69F61D16");

            entity.ToTable("studentsLessons");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Lessonid).HasColumnName("lessonid");
            entity.Property(e => e.Studentid).HasColumnName("studentid");

            entity.HasOne(d => d.Lesson).WithMany(p => p.StudentsLessons)
                .HasForeignKey(d => d.Lessonid)
                .HasConstraintName("FK__studentsL__lesso__4316F928");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentsLessons)
                .HasForeignKey(d => d.Studentid)
                .HasConstraintName("FK__studentsL__stude__4222D4EF");
        });

        modelBuilder.Entity<StudentsTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__students__3213E83FCB87FC9F");

            entity.ToTable("studentsTeachers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Teacherid).HasColumnName("teacherid");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentsTeachers)
                .HasForeignKey(d => d.Studentid)
                .HasConstraintName("FK__studentsT__stude__45F365D3");

            entity.HasOne(d => d.Teacher).WithMany(p => p.StudentsTeachers)
                .HasForeignKey(d => d.Teacherid)
                .HasConstraintName("FK__studentsT__teach__46E78A0C");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__teachers__3213E83FD796F9BB");

            entity.ToTable("teachers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Departmenid).HasColumnName("departmenid");
            entity.Property(e => e.Lessonid).HasColumnName("lessonid");
            entity.Property(e => e.Teachername)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("teachername");
            entity.Property(e => e.Teachersurname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("teachersurname");

            entity.HasOne(d => d.Departmen).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.Departmenid)
                .HasConstraintName("FK__teachers__depart__3F466844");

            entity.HasOne(d => d.Lesson).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.Lessonid)
                .HasConstraintName("FK__teachers__lesson__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

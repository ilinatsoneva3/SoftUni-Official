namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;
    using System;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.Connection);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity
                    .Property(s => s.PhoneNumber)
                    .IsUnicode(false)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity
                    .Property(r => r.Url)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity
                    .Property(r => r.Content)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity
                    .HasKey(sc => new { sc.StudentId, sc.CourseId });                  
            });
        }

    }
}

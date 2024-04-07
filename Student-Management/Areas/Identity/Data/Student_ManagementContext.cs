using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student_Management.Models;

namespace Student_Management.Data
{
    public class Student_ManagementContext : IdentityDbContext<IdentityUser>
    {
        public Student_ManagementContext(DbContextOptions<Student_ManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Define relationships
            modelBuilder.Entity<Course>()
                .HasOne<Department>()
                .WithMany()
                .HasForeignKey(c => c.DepartmentId);

            modelBuilder.Entity<Course>()
                .HasOne<Classroom>()
                .WithMany()
                .HasForeignKey(c => c.ClassroomId);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Enable lazy loading
        //    optionsBuilder.UseLazyLoadingProxies();
        //}
    }
}

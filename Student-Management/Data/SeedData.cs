using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Student_Management.Models;

namespace Student_Management.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Student_ManagementContext(
                serviceProvider.GetRequiredService<DbContextOptions<Student_ManagementContext>>()))
            {
                // Seed Departments
                if (!context.Departments.Any())
                {
                    context.Departments.AddRange(
                        new Department
                        {
                            Name = "Computer Science",
                            Location = "Building A"
                        },
                        new Department
                        {
                            Name = "Mathematics",
                            Location = "Building B"
                        },
                        new Department
                        {
                            Name = "Physics",
                            Location = "Building C"
                        },
                        new Department
                        {
                            Name = "Biology",
                            Location = "Building D"
                        },
                        new Department
                        {
                            Name = "History",
                            Location = "Building E"
                        },
                        new Department
                        {
                            Name = "Literature",
                            Location = "Building F"
                        },
                        new Department
                        {
                            Name = "Chemistry",
                            Location = "Building G"
                        },
                        new Department
                        {
                            Name = "Psychology",
                            Location = "Building H"
                        },
                        new Department
                        {
                            Name = "Engineering",
                            Location = "Building I"
                        },
                        new Department
                        {
                            Name = "Business Administration",
                            Location = "Building J"
                        }
                    );
                    context.SaveChanges();
                }

                // Seed Classrooms
                if (!context.Classrooms.Any())
                {
                    context.Classrooms.AddRange(
                        new Classroom
                        {
                            ClassroomCode = "A101",
                            MaxSize = 30
                        },
                        new Classroom
                        {
                            ClassroomCode = "B201",
                            MaxSize = 25
                        },
                        new Classroom
                        {
                            ClassroomCode = "C301",
                            MaxSize = 40
                        },
                        new Classroom
                        {
                            ClassroomCode = "D401",
                            MaxSize = 35
                        },
                        new Classroom
                        {
                            ClassroomCode = "E501",
                            MaxSize = 20
                        },
                        new Classroom
                        {
                            ClassroomCode = "F601",
                            MaxSize = 28
                        },
                        new Classroom
                        {
                            ClassroomCode = "G701",
                            MaxSize = 32
                        },
                        new Classroom
                        {
                            ClassroomCode = "H801",
                            MaxSize = 22
                        },
                        new Classroom
                        {
                            ClassroomCode = "I901",
                            MaxSize = 26
                        },
                        new Classroom
                        {
                            ClassroomCode = "J1001",
                            MaxSize = 38
                        }
                    );
                    context.SaveChanges();
                }

                // Seed Courses
                if (!context.Courses.Any())
                {
                    context.Courses.AddRange(
                        new Course
                        {
                            Name = "Introduction to Programming",
                            Description = "Learn basics of programming",
                            Credit = 3,
                            DepartmentId = context.Departments.FirstOrDefault(d => d.Name == "Computer Science").DepartmentId,
                            DayOfWeek = DayOfWeek.Monday,
                            StartTime = new TimeSpan(9, 0, 0),
                            EndTime = new TimeSpan(11, 0, 0),
                            Status = "Active",
                            ClassroomId = context.Classrooms.FirstOrDefault(c => c.ClassroomCode == "A101").Id,
                            ClassSize = 20,
                            CourseCode = "CS101"
                        },
                        new Course
                        {
                            Name = "Calculus I",
                            Description = "Introductory calculus course",
                            Credit = 4,
                            DepartmentId = context.Departments.FirstOrDefault(d => d.Name == "Mathematics").DepartmentId,
                            DayOfWeek = DayOfWeek.Wednesday,
                            StartTime = new TimeSpan(13, 0, 0),
                            EndTime = new TimeSpan(15, 0, 0),
                            Status = "Active",
                            ClassroomId = context.Classrooms.FirstOrDefault(c => c.ClassroomCode == "B201").Id,
                            ClassSize = 25,
                            CourseCode = "MATH101"
                        },
                        new Course
                        {
                            Name = "General Physics",
                            Description = "Basic principles of physics",
                            Credit = 3,
                            DepartmentId = context.Departments.FirstOrDefault(d => d.Name == "Physics").DepartmentId,
                            DayOfWeek = DayOfWeek.Tuesday,
                            StartTime = new TimeSpan(10, 0, 0),
                            EndTime = new TimeSpan(12, 0, 0),
                            Status = "Active",
                            ClassroomId = context.Classrooms.FirstOrDefault(c => c.ClassroomCode == "C301").Id,
                            ClassSize = 30,
                            CourseCode = "PHY101"
                        },
                        new Course
                        {
                            Name = "Introduction to Biology",
                            Description = "Fundamentals of biology",
                            Credit = 3,
                            DepartmentId = context.Departments.FirstOrDefault(d => d.Name == "Biology").DepartmentId,
                            DayOfWeek = DayOfWeek.Thursday,
                            StartTime = new TimeSpan(14, 0, 0),
                            EndTime = new TimeSpan(16, 0, 0),
                            Status = "Active",
                            ClassroomId = context.Classrooms.FirstOrDefault(c => c.ClassroomCode == "D401").Id,
                            ClassSize = 35,
                            CourseCode = "BIO101"
                        }
                        // Add more courses here
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management.Data;
using Student_Management.Models;

namespace Student_Management.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CoursesController : Controller
    {
        private readonly Student_ManagementContext _context;

        public CoursesController(Student_ManagementContext context)
        {
            _context = context;
        }

        // GET: Admin/Courses
        public async Task<IActionResult> Index(string searchCategory, string searchString)
        {
            var courses = from c in _context.Courses
                          select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                switch (searchCategory)
                {
                    case "Name":
                        courses = courses.Where(c => c.Name.Contains(searchString));
                        break;
                    case "CourseCode":
                        courses = courses.Where(c => c.CourseCode.Contains(searchString));
                        break;
                }
            }

            return View(await courses.ToListAsync());
        }

        // GET: Admin/Courses/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Admin/Courses/Create
        public IActionResult Create()
        {
            PopulateClassroomsDropDownList();
            PopulateDepartmentsDropDownList();
            return View();
        }

        // POST: Admin/Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,Name,Description,Credit,DepartmentId,DayOfWeek,StartTime,EndTime,Status,ClassroomId,ClassSize,CourseCode")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Admin/Courses/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            PopulateClassroomsDropDownList();
            PopulateDepartmentsDropDownList();
            return View(course);
        }

        // POST: Admin/Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CourseId,Name,Description,Credit,DepartmentId,DayOfWeek,StartTime,EndTime,Status,ClassroomId,ClassSize,CourseCode")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Admin/Courses/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Admin/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(long id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentId = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentId", "Name", selectedDepartment);
        }

        private void PopulateClassroomsDropDownList(object selectedClassroom = null)
        {
            var classroomsQuery = from d in _context.Classrooms
                                  orderby d.Id
                                  select d;
            ViewBag.ClassroomId = new SelectList(classroomsQuery.AsNoTracking(), "Id", "ClassroomCode", selectedClassroom);
        }
    }
}

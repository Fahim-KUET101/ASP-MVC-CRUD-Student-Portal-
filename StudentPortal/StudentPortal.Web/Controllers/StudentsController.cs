using System;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace StudentPortal.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AplicationDbContext dbContext;
        public StudentsController(AplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewmodel)
        {
            var student = new Student
            {
                Name = viewmodel.Name,
                Description = viewmodel.Description,
                Phone = viewmodel.Phone,
                Subscribes = viewmodel.Subscribes
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);
            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Description = viewModel.Description;
                student.Phone = viewModel.Phone;
                student.Subscribes = viewModel.Subscribes;
                await dbContext.SaveChangesAsync();
                
            }

            return RedirectToAction("List", "Students");

        }
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (student is not null)
            {
                dbContext.Students.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");

        }
    }
}

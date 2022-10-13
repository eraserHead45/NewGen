using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewGen.Data;
using NewGen.Models;

namespace NewGen.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _Db;
        public EmployeeController(AppDbContext Db)
        {
            _Db = Db;
        }

        public IActionResult Index()
        {   
            IEnumerable<Employee> ObjEmployee = _Db.Employees;
            return View(ObjEmployee);
        }

        //GET
        [HttpGet]
        public IActionResult Add()
        {   
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Employee obj)
        {   
            if(obj.Name == obj.Email)
            {
                ModelState.AddModelError("Name","Email cannot exactly match the Name.");
            }
            if(ModelState.IsValid)
            {
                _Db.Employees.Add(obj);
                _Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Edit(int? Id)
        {   
            if(Id==null || Id==0)
            {
                return NotFound();
            }

            var employeeFromDb = _Db.Employees.Find(Id);

            if(employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }
         //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {   
            if(obj.Name == obj.Email)
            {
                ModelState.AddModelError("Name","Email cannot exactly match the Name.");
            }
            if(ModelState.IsValid)
            {
                _Db.Employees.Update(obj);
                _Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
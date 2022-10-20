using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewGen.Data;
using NewGen.Models;
using NewGen.Repository.IRepository;

namespace NewGen.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {   
            IEnumerable<Employee> ObjEmployee = _UnitOfWork.Employee.GetAll();
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
                _UnitOfWork.Employee.Add(obj);
                _UnitOfWork.Save();
                TempData["success"] = "New Employee Added Successfully";
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
 
            var employeeFromDb = _UnitOfWork.Employee.GetFirstOrDefault(u=>u.ID == Id);

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
                _UnitOfWork.Employee.Edit(obj);
                _UnitOfWork.Save();
                 TempData["success"] = "Employee Details Edited Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
         //GET
        public IActionResult Delete(int? Id)
        {
           if(Id==null || Id==0)
            {
                return NotFound();
            }

            var employeeFromDb = _UnitOfWork.Employee.GetFirstOrDefault(u=>u.ID == Id);

            if(employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb); 
        }
         //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {   
            var obj = _UnitOfWork.Employee.GetFirstOrDefault(u=>u.ID == Id);
            if(Id==null)
            {
                return NotFound();
            }

            _UnitOfWork.Employee.Remove(obj);
            _UnitOfWork.Save();
             TempData["success"] = "Employee Records Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
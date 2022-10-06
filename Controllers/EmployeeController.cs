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
    [Route("[controller]")]
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
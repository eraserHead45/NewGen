using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewGen.Data;
using NewGen.Models;
using NewGen.Repository.IRepository;

namespace NewGen.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private AppDbContext _db;
        public EmployeeRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Edit(Employee obj)
        {
            _db.Employees.Update(obj);
        }
    }
}
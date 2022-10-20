using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewGen.Data;
using NewGen.Repository.IRepository;

namespace NewGen.Repository
{
    public class UnitOfWork : IUnitOfWork
    {   
        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Employee = new EmployeeRepository(_db);
        }
        public IEmployeeRepository Employee{get; private set;}

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
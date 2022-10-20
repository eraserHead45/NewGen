using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewGen.Models;

namespace NewGen.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void Edit(Employee obj);
    }
}
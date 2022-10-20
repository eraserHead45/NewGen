using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewGen.Repository.IRepository
{
    public interface IUnitOfWork
    {   
        IEmployeeRepository Employee { get; }
        void Save();
    }
}
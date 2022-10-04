using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewGen.Models;

namespace NewGen.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base()
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
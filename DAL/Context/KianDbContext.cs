using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class KianDbContext:DbContext
    {
        public KianDbContext(DbContextOptions<KianDbContext> options) : base(options)
        {

        }

        public  DbSet<Employee> employees { get; set; }
    }
}

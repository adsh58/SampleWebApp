using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        //{

        //}
        public AppDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=SchoolDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                var employees = await Employees
                    .FromSqlRaw("SELECT * FROM Employee")
                    .ToListAsync();
                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }


    public class Employee
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public string Email { get; set; }
    }
}

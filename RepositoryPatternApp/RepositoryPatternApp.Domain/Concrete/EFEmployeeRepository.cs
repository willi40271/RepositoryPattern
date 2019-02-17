using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Abstract;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Concrete
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Employee> Employees
        {
            get { return context.Employees; }
        }

        public void Save(Employee employee)
        {
            if (employee.EmployeeID.Equals(0))
            {
                context.Employees.Add(employee);
            }
            else
            {
                Employee dbEntry = context.Employees.Find(employee.EmployeeID);
                if (dbEntry != null)
                {
                    dbEntry.Title = employee.Title;
                }
            }

            context.SaveChanges();
        }

        public Employee Delete(int id)
        {
            Employee dbEntry = context.Employees.Find(id);
            if (dbEntry != null)
            {
                context.Employees.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public IEnumerable<Employee> GetAll()
        {
            return context.Employees;
        }

        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(x => x.EmployeeID.Equals(id));
        }
    }
}
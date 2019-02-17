using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Abstract
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> Employees { get; }

        void Save(Employee employee);

        Employee Delete(int id);

        IEnumerable<Employee> GetAll();

        Employee GetById(int id);
    }
}
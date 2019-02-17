using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Abstract
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Customers { get; }

        void Save(Customer customer);

        Customer Delete(int id);

        IEnumerable<Customer> GetAll();

        Customer GetById(int id);
    }
}
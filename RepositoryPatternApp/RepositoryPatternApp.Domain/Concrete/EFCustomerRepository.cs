using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Abstract;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Concrete
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Customer> Customers
        {
            get { return context.Customers; }
        }

        public void Save(Customer customer)
        {
            if (customer.CustomerID.Equals(0))
            {
                context.Customers.Add(customer);
            }
            else
            {
                Customer dbEntry = context.Customers.Find(customer.CustomerID);
                if (dbEntry != null)
                {
                    dbEntry.ContactName = customer.ContactName;
                }
            }

            context.SaveChanges();
        }

        public Customer Delete(int id)
        {
            Customer dbEntry = context.Customers.Find(id);
            if (dbEntry != null)
            {
                context.Customers.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public IEnumerable<Customer> GetAll()
        {
            return context.Customers;
        }

        public Customer GetById(int id)
        {
            return context.Customers.FirstOrDefault(x => x.CustomerID.Equals(id));
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Abstract
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }

        void Save(Order order);

        Order Delete(int id);

        IEnumerable<Order> GetAll();

        Order GetById(int id);
    }
}
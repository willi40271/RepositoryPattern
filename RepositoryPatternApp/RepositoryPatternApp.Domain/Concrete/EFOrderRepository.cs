using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Abstract;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Order> Orders
        {
            get { return context.Orders; }
        }

        public void Save(Order order)
        {
            if (order.OrderID.Equals(0))
            {
                context.Orders.Add(order);
            }
            else
            {
                Order dbEntry = context.Orders.Find(order.OrderID);
                if (dbEntry != null)
                {
                    dbEntry.ShipName = order.ShipName;
                }
            }

            context.SaveChanges();
        }

        public Order Delete(int id)
        {
            Order dbEntry = context.Orders.Find(id);
            if (dbEntry != null)
            {
                context.Orders.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Orders;
        }

        public Order GetById(int id)
        {
            return context.Orders.FirstOrDefault(x => x.OrderID.Equals(id));
        }
    }
}
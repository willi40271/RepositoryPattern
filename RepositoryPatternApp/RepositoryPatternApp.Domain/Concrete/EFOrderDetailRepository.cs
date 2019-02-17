using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Abstract;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Concrete
{
    public class EFOrderDetailRepository : IOrderDetailRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<OrderDetail> OrderDetails
        {
            get { return context.OrderDetails; }
        }

        public void Save(OrderDetail orderDetail)
        {
            if (orderDetail.OrderID.Equals(0) && orderDetail.ProductID.Equals(0))
            {
                context.OrderDetails.Add(orderDetail);
            }
            else
            {
                OrderDetail dbEntry = context.OrderDetails.FirstOrDefault(x => x.OrderID.Equals(orderDetail.OrderID) && x.ProductID.Equals(orderDetail.ProductID));
                if (dbEntry != null)
                {
                    dbEntry.Quantity = orderDetail.Quantity;
                }
            }

            context.SaveChanges();
        }

        public OrderDetail Delete(int orderId, int productId)
        {
            OrderDetail dbEntry = context.OrderDetails.FirstOrDefault(x => x.OrderID.Equals(orderId) && x.ProductID.Equals(productId));
            if (dbEntry != null)
            {
                context.OrderDetails.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return context.OrderDetails;
        }

        public OrderDetail GetById(int orderId, int productId)
        {
            return context.OrderDetails.FirstOrDefault(x => x.OrderID.Equals(orderId) && x.ProductID.Equals(productId));
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Abstract
{
    public interface IOrderDetailRepository
    {
        IQueryable<OrderDetail> OrderDetails { get; }

        void Save(OrderDetail orderDetail);

        OrderDetail Delete(int orderId, int productId);

        IEnumerable<OrderDetail> GetAll();

        OrderDetail GetById(int orderId, int productId);
    }
}
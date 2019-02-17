using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        void Save(Product product);

        Product Delete(int id);

        IEnumerable<Product> GetAll();

        Product GetById(int id);
    }
}
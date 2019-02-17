using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Abstract;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }

        public void Save(Product product)
        {
            if (product.ProductID.Equals(0))
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.ProductName = product.ProductName;
                }
            }

            context.SaveChanges();
        }

        public Product Delete(int id)
        {
            Product dbEntry = context.Products.Find(id);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        public Product GetById(int id)
        {
            return context.Products.FirstOrDefault(x => x.ProductID.Equals(id));
        }
    }
}
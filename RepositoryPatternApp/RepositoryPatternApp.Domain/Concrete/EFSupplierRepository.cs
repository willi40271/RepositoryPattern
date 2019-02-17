using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Abstract;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Concrete
{
    public class EFSupplierRepository : ISupplierRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Supplier> Suppliers
        {
            get { return context.Suppliers; }
        }

        public void Save(Supplier supplier)
        {
            if (supplier.SupplierID.Equals(0))
            {
                context.Suppliers.Add(supplier);
            }
            else
            {
                Supplier dbEntry = context.Suppliers.Find(supplier.SupplierID);
                if (dbEntry != null)
                {
                    dbEntry.CompanyName = supplier.CompanyName;
                }
            }

            context.SaveChanges();
        }

        public Supplier Delete(int id)
        {
            Supplier dbEntry = context.Suppliers.Find(id);
            if (dbEntry != null)
            {
                context.Suppliers.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return context.Suppliers;
        }

        public Supplier GetById(int id)
        {
            return context.Suppliers.FirstOrDefault(x => x.SupplierID.Equals(id));
        }
    }
}
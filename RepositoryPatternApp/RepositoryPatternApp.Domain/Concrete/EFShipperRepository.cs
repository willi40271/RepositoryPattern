using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Abstract;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Concrete
{
    public class EFShipperRepository : IShipperRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Shipper> Shippers
        {
            get { return context.Shippers; }
        }

        public void Save(Shipper shipper)
        {
            if (shipper.ShipperID.Equals(0))
            {
                context.Shippers.Add(shipper);
            }
            else
            {
                Shipper dbEntry = context.Shippers.Find(shipper.ShipperID);
                if (dbEntry != null)
                {
                    dbEntry.CompanyName = shipper.CompanyName;
                }
            }

            context.SaveChanges();
        }

        public Shipper Delete(int id)
        {
            Shipper dbEntry = context.Shippers.Find(id);
            if (dbEntry != null)
            {
                context.Shippers.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public IEnumerable<Shipper> GetAll()
        {
            return context.Shippers;
        }

        public Shipper GetById(int id)
        {
            return context.Shippers.FirstOrDefault(x => x.ShipperID.Equals(id));
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Abstract;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Concrete
{
    public class EFTerritoryRepository : ITerritoryRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Territory> Territories
        {
            get { return context.Territories; }
        }

        public void Save(Territory territory)
        {
            if (territory.TerritoryID.Equals(0))
            {
                context.Territories.Add(territory);
            }
            else
            {
                Territory dbEntry = context.Territories.Find(territory.TerritoryID);
                if (dbEntry != null)
                {
                    dbEntry.TerritoryDescription = territory.TerritoryDescription;
                }
            }

            context.SaveChanges();
        }

        public Territory Delete(int id)
        {
            Territory dbEntry = context.Territories.Find(id);
            if (dbEntry != null)
            {
                context.Territories.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public IEnumerable<Territory> GetAll()
        {
            return context.Territories;
        }

        public Territory GetById(int id)
        {
            return context.Territories.FirstOrDefault(x => x.TerritoryID.Equals(id));
        }
    }
}
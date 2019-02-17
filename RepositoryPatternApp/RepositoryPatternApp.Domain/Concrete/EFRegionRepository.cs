using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Abstract;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Concrete
{
    public class EFRegionRepository : IRegionRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Region> Regions
        {
            get { return context.Regions; }
        }

        public void Save(Region region)
        {
            if (region.RegionID.Equals(0))
            {
                context.Regions.Add(region);
            }
            else
            {
                Region dbEntry = context.Regions.Find(region.RegionID);
                if (dbEntry != null)
                {
                    dbEntry.RegionDescription = region.RegionDescription;
                }
            }

            context.SaveChanges();
        }

        public Region Delete(int id)
        {
            Region dbEntry = context.Regions.Find(id);
            if (dbEntry != null)
            {
                context.Regions.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public IEnumerable<Region> GetAll()
        {
            return context.Regions;
        }

        public Region GetById(int id)
        {
            return context.Regions.FirstOrDefault(x => x.RegionID.Equals(id));
        }
    }
}
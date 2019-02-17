using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Abstract
{
    public interface IRegionRepository
    {
        IQueryable<Region> Regions { get; }

        void Save(Region region);

        Region Delete(int id);

        IEnumerable<Region> GetAll();

        Region GetById(int id);
    }
}
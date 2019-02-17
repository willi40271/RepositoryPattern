using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Abstract
{
    public interface IShipperRepository
    {
        IQueryable<Shipper> Shippers { get; }

        void Save(Shipper shipper);

        Shipper Delete(int id);

        IEnumerable<Shipper> GetAll();

        Shipper GetById(int id);
    }
}
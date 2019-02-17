using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Abstract
{
    public interface ISupplierRepository
    {
        IQueryable<Supplier> Suppliers { get; }

        void Save(Supplier supplier);

        Supplier Delete(int id);

        IEnumerable<Supplier> GetAll();

        Supplier GetById(int id);
    }
}
using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Abstract
{
    public interface ITerritoryRepository
    {
        IQueryable<Territory> Territories { get; }

        void Save(Territory territory);

        Territory Delete(int id);

        IEnumerable<Territory> GetAll();

        Territory GetById(int id);
    }
}
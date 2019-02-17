using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Abstract
{
    public interface IEmployeeTerritoryRepository
    {
        IQueryable<EmployeeTerritory> EmployeeTerritorys { get; }

        void Save(EmployeeTerritory employeeTerritory);

        EmployeeTerritory Delete(int employeeId, int territoryId);

        IEnumerable<EmployeeTerritory> GetAll();

        EmployeeTerritory GetById(int employeeId, int territoryId);
    }
}
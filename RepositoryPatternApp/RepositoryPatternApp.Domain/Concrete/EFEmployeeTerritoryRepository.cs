using System.Collections.Generic;
using System.Linq;
using RepositoryPatternApp.Domain.Abstract;
using RepositoryPatternApp.Domain.Entities;

namespace RepositoryPatternApp.Domain.Concrete
{
    public class EFEmployeeTerritoryRepository : IEmployeeTerritoryRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<EmployeeTerritory> EmployeeTerritorys
        {
            get { return context.EmployeeTerritories; }
        }

        public void Save(EmployeeTerritory employeeTerritory)
        {
            if (employeeTerritory.EmployeeID.Equals(0) && employeeTerritory.TerritoryID.Equals(0))
            {
                context.EmployeeTerritories.Add(employeeTerritory);
            }
            else
            {
                EmployeeTerritory dbEntry = context.EmployeeTerritories.FirstOrDefault(x => x.EmployeeID.Equals(employeeTerritory.EmployeeID) && x.TerritoryID.Equals(employeeTerritory.TerritoryID));
            }

            context.SaveChanges();
        }

        public EmployeeTerritory Delete(int employeeId, int territoryId)
        {
            EmployeeTerritory dbEntry = context.EmployeeTerritories.FirstOrDefault(x => x.EmployeeID.Equals(employeeId) && x.TerritoryID.Equals(territoryId));
            if (dbEntry != null)
            {
                context.EmployeeTerritories.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public IEnumerable<EmployeeTerritory> GetAll()
        {
            return context.EmployeeTerritories;
        }

        public EmployeeTerritory GetById(int employeeId, int territoryId)
        {
            return context.EmployeeTerritories.FirstOrDefault(x => x.EmployeeID.Equals(employeeId) && x.TerritoryID.Equals(territoryId));
        }
    }
}
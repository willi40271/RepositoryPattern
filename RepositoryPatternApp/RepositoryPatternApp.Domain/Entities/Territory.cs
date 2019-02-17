using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPatternApp.Domain.Entities
{
    [Table("Territories")]
    public class Territory
    {
        [Key]
        public int TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionID { get; set; }

        [ForeignKey("RegionID")]
        public virtual Region Region { get; set; }

        public virtual ICollection<EmployeeTerritory> EmployeeTerritorys { get; set; }
    }
}
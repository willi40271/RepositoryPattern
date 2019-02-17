using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPatternApp.Domain.Entities
{
    [Table("EmployeeTerritories")]
    public class EmployeeTerritory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column(Order = 0)]
        public int EmployeeID { get; set; }
        [Key, Column(Order = 1)]
        public int TerritoryID { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("TerritoryID")]
        public virtual Territory Territory { get; set; }
    }
}
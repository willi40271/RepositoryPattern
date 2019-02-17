using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoryPatternApp.WebUI.Models.Employee
{
    public class IndexViewModel
    {
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}
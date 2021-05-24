using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NorthwindEmployees.MyFeature.Pages
{
    public class EmployeesPageModel : PageModel
    {
        private Northwind db;

        public EmployeesPageModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public IEnumerable<Employee> Employees {get; set;}

        public void OnGet()
        {
            Employees = db.Employees.ToArray();
        }
    }
}

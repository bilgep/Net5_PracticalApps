using Company.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindWeb.Pages
{
    public class SuppliersModel: PageModel
    {
        private Northwind db;
        public SuppliersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<string> Suppliers {get; set;}
        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            // Suppliers = new[] {"Alpha Co", "Beta Limited", "Gamma Corp", "Bilge Ltd"};
            Suppliers = db.Suppliers.Select(s => s.CompanyName);
        }

        [BindProperty]
        public Supplier Supplier {get; set;}

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                db.Suppliers.Add(Supplier);
                
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            return Page();
        }
        


    }
}
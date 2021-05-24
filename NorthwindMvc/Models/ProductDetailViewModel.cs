
using Microsoft.AspNetCore.Mvc.RazorPages;
using Company.Shared;
using System.ComponentModel.DataAnnotations;

namespace NorthwindMvc.Models
{
    
    public class ProductDetailViewModel : PageModel
    {
        public Product TheProduct {get; set;}
        public Category TheCategory {get; set;}
    }
    
}
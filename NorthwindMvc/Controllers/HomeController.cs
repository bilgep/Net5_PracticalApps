using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindMvc.Models;
using Company.Shared;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Json;

namespace NorthwindMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly ILogger<HomeController> _logger;
        private Northwind db;
        public HomeController(ILogger<HomeController> logger, Northwind injectedContext, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            db = injectedContext;
            clientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeIndexViewModel
            {
                VisitorCount = new Random().Next(1, 1000),
                Categories = await db.Categories.ToListAsync(),
                Products = await db.Products.ToListAsync()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ProductDetail(int? id)
        {

            // if(!id.HasValue)
            // {
            //     return NotFound("Please pass a product id.");
            // }

            // var model = db.Products.SingleOrDefault(p => p.ProductID == id);

            // if(model == null)
            // {
            //     return NotFound("This product id doesn't exist.");
            // }

            // return View(model);

            if (!id.HasValue)
            {
                var stringToWrite = string.Empty;
                foreach (var item in ModelState.Values.SelectMany(a => a.Errors))
                {
                    stringToWrite += item.ErrorMessage + "\n";
                }
                return NotFound("Id not found.\n" + ModelState.Values.SelectMany(state => state.Errors).Select(error => error.ErrorMessage) + "\n" + stringToWrite);
            }

            var model = new ProductDetailViewModel();
            model.TheProduct = await db.Products.SingleOrDefaultAsync(p => p.ProductID == id);

            if (model.TheProduct != null)
            {
                var catId = model.TheProduct.CategoryId;
                if (catId.HasValue)
                {
                    model.TheCategory = await db.Categories.SingleOrDefaultAsync(c => c.CategoryID == model.TheProduct.CategoryId);
                }
            }
            else
            {
                var stringToWrite = string.Empty;
                foreach (var item in ModelState.Values.SelectMany(a => a.Errors))
                {
                    stringToWrite += item.ErrorMessage + "\n";
                }
                return NotFound("Id not found.\n" + ModelState.Values.SelectMany(state => state.Errors).Select(error => error.ErrorMessage) + "\n" + stringToWrite);
            }

            return View(model);
        }

        public IActionResult ProductsThatCostMoreThan(decimal? price)
        {
            if(!price.HasValue)
            {
                return NotFound("Price not found.");
            }

            var model = db.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => p.UnitPrice > price);

            if(model.Count() == 0)
            {
                return NotFound($"No products cost more than {price}.");
            }

            ViewData["MaxPrice"] = price.Value;

            return View(model);            
        }

        public async Task<IActionResult> Customers(string country)
        {
            string uri;
            if(string.IsNullOrEmpty(country))
            {
                ViewData["Title"] = "All customers worldwide";
                uri = "api/customers";
            }
            else
            {
                ViewData["Title"] = "Customers in " + country;
                uri = $"api/customers/?country={country}";
            }

            var client = clientFactory.CreateClient(name: "NorthwindService");
            var request = new HttpRequestMessage( method: HttpMethod.Get, requestUri: uri);
            HttpResponseMessage response = await client.SendAsync(request);

            var model = await response.Content.ReadFromJsonAsync<IEnumerable<Customer>>();
            return View(model);
        
        }



    }
}

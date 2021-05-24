using Microsoft.AspNetCore.Mvc;
using Company.Shared;
using NorthwindService.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController: ControllerBase
    {
        private ICustomerRepository repository;

        public CustomersController(ICustomerRepository repo) // Inject repository at construction time
        {
            repository = repo;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public async Task<IEnumerable<Customer>> GetCustomers(string country)
        {
            if(string.IsNullOrWhiteSpace(country))
            {
                return await repository.RetrieveAllAsync();
            }
            else
            {
                var result = await repository.RetrieveAllAsync();
                return result.Where(c => c.Country == country);
            }

        }

        // Get: api/customers/[id]
        [HttpGet("{id}", Name = nameof(GetCustomer))]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomer(string id)
        {
            Customer c = await repository.RetrieveAsync(id);
            if(c == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(c);
            }
        }

        // Post: api/customers
        [HttpPost]
        [ProducesResponseType(200 , Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody]Customer c)
        {
            if(c == null)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Problem at Create Action",
                    Status = StatusCodes.Status400BadRequest,
                    Instance = HttpContext.Request.Path,
                    Detail = "more details..."
                };
                return BadRequest();
            }
            
            if(!ModelState.IsValid)
            {   
                return BadRequest(ModelState);
            }

            Customer added = await repository.CreateAsync(c);
            return CreatedAtRoute(
                routeName: nameof(GetCustomer),
                routeValues: new { id = added.CustomerID.ToLower()},
                value: added
            );

        }

        // Put: api/customers/[id]
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(string id, [FromBody]Customer c)
        {
            id = id.ToUpper();
            c.CustomerID = c.CustomerID.ToUpper();
            if(c == null || c.CustomerID != id)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existing = await repository.RetrieveAsync(id);

            if(existing == null)
            {
                return NotFound();
            }

            await repository.UpdateAsync(id, c);
            return new NoContentResult(); // 204
        }

        // Delete: api/customers/[id]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(string id)
        {
            var existingCustomer = await repository.RetrieveAsync(id);
            if(existingCustomer == null)
            {
                return NotFound();
            }

            bool? deleted = await repository.DeleteAsync(id);

            if(deleted.HasValue && deleted.Value)
            {
                return new NoContentResult();
            }
            else
            {
                return BadRequest($"Failed to delete customer with id {id}");
            }
        }



    }
}
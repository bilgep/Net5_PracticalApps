using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Shared;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NorthwindService.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private static ConcurrentDictionary<string, Customer> customersCache;
        private Northwind db;

        public CustomerRepository(Northwind databaseContext)
        {
            db = databaseContext;

            if (customersCache == null)
            {
                customersCache = new ConcurrentDictionary<string, Customer>(db.Customers.ToDictionary(c => c.CustomerID));
            }
        }
        public async Task<Customer> CreateAsync(Customer c)
        {
            c.CustomerID = c.CustomerID.ToUpper();
            EntityEntry<Customer> added = await db.Customers.AddAsync(c);
            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return customersCache.AddOrUpdate(c.CustomerID, c, UpdateCache);
            }
            else
            {
                return null;
            }
        }


        public async Task<IEnumerable<Customer>> RetrieveAllAsync()
        {
            // getting values from cache for performance
            return await Task.Run<IEnumerable<Customer>>(
                () => customersCache.Values
            );
        }

        public async Task<Customer> RetrieveAsync(string id)
        {
            return await Task.Run(() =>
            {
                id = id.ToUpper();
                customersCache.TryGetValue(id, out Customer c);
                return c;
            });
        }

        private Customer UpdateCache(string id, Customer c)
        {
            Customer old;
            if (customersCache.TryGetValue(id, out old))
            {
                if (customersCache.TryUpdate(id, c, old))
                {
                    return c;
                }
            }
            return null;
        }
        public async Task<Customer> UpdateAsync(string id, Customer c)
        {
            id = id.ToUpper();
            c.CustomerID = c.CustomerID.ToUpper();
            db.Customers.Update(c);
            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                return UpdateCache(id, c);
            }
            else
            {
                return null;
            }


        }


        public async Task<bool?> DeleteAsync(string id)
        {
            id = id.ToUpper();
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            var affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return customersCache.TryRemove(id, out customer);
            }
            else
            {
                return null;
            }
        }
    }
}
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CustomersContextSeed
    {
        public static async Task SeedAsync(
            CustomersContext customersContext,
            ILoggerFactory loggerFactory,
            int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                //customersContext.Database.Migrate();

                if (!await customersContext.Customers.AnyAsync())
                {
                    var items = GetCustomers();
                    items.ToList().ForEach(x => x.SetPassword("password"));
                    await customersContext.Customers.AddRangeAsync(
                        items);
                    await customersContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;
                var log = loggerFactory.CreateLogger<CustomersContextSeed>();
                log.LogError(ex.Message);
                await SeedAsync(customersContext, loggerFactory, retryForAvailability);
                throw;
            }
        }

        static IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { FirstName ="Jameel", LastName ="Soto", Email = "jameel.soto@domain.com" },
                new Customer { FirstName ="Leonardo", LastName ="Wheeler", Email = "leonardo.wheeler@domain.com" },
                new Customer { FirstName ="Nylah", LastName ="Mcgrath", Email = "nylah.mcgrath@domain.com" },
                new Customer { FirstName ="Rhiannan", LastName ="Hogg", Email = "rhiannan.hogg@domain.com" },
                new Customer { FirstName ="Darragh", LastName ="Stewart", Email = "darragh.stewart@domain.com" },
                new Customer { FirstName ="Salim", LastName ="Higgins", Email = "salim.higgins@domain.com" },
                new Customer { FirstName ="Luke", LastName ="Major", Email = "luke.major@domain.com" },
                new Customer { FirstName ="Shola", LastName ="Moran", Email = "shola.moran@domain.com" },
                new Customer { FirstName ="Darla", LastName ="Mcghee", Email = "darla.mcghee@domain.com" },
                new Customer { FirstName ="Karen", LastName ="Pope", Email = "karen.pope@domain.com" }
            };

        }
    }
}

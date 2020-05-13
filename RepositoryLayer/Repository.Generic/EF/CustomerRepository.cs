using RepositoryLayer.DAL.EF;
using RepositoryLayer.Model;
using RepositoryLayer.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Generic.EF
{
    public class CustomerRepository : EFRepositoryBase<Customer>, ICustomerRepository
    {
        public decimal GetCustomerAllTimeShoppingTotal(int customerId)
        {
            return this.GetBy(customerId).Orders.Select(x => x.TotalPrice).ToList().Sum();
        }

        public IEnumerable<string> GetCustomerAllTimeBoughtProducts(int customerId)
        {
            return this.GetBy(customerId).Orders.SelectMany(x => x.LineItems).Select(x => x.Product).Distinct().ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.Contract
{
    public interface ICustomerRepository
    {
        decimal GetCustomerAllTimeShoppingTotal(int customerId);

        IEnumerable<string> GetCustomerAllTimeBoughtProducts(int customerId);

    }
}

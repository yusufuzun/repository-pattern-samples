using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using RepositoryLayer.DAL.Dapper;

namespace RepositoryLayer.Repository.Static
{
    public class CustomerRepository : RepositoryBase
    {
        public static decimal GetCustomerAllTimeShoppingTotal(int customerId)
        {
            return DbReadConnection.ExecStoredProcedure<decimal>("GetCustomerAllTimeExpense", new { customerId }).SingleOrDefault();
        }

        public static IEnumerable<string> GetCustomerAllTimeBoughtProducts(int customerId)
        {
            return DbReadConnection.ExecStoredProcedure<string>("GetCustomerAllTimeBoughtProducts", new { customerId });
        }
    }
}

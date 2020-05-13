using RepositoryLayer.Model;
using RepositoryLayer.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using RepositoryLayer.DAL.Dapper;

namespace RepositoryLayer.Repository.Plain.Dapper
{
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public decimal GetCustomerAllTimeShoppingTotal(int customerId)
        {
            return this.DbReadConnection.ExecStoredProcedure<decimal>("GetCustomerAllTimeExpense", new { customerId }).SingleOrDefault();
        }

        public IEnumerable<string> GetCustomerAllTimeBoughtProducts(int customerId)
        {
            return this.DbReadConnection.ExecStoredProcedure<string>("GetCustomerAllTimeBoughtProducts", new { customerId });
        }
    }
}

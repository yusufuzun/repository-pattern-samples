using RepositoryLayer.Core;
using RepositoryLayer.Generic.EF;
using RepositoryLayer.Model;
using RepositoryLayer.Repository.Contract;
using RepositoryLayer.Repository.Generic;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class GenericExample
    {
        public static void Init()
        {
            ObjectFactory.Initialize(config =>
            {
                config.Scan(scan =>
                {
                    scan.ExcludeNamespace("RepositoryLayer.Repository.Plain");
                    scan.ExcludeNamespace("RepositoryLayer.Repository.Static");
                    scan.WithDefaultConventions();
                    scan.AssemblyContainingType(typeof(IRepository));
                    scan.ConnectImplementationsToTypesClosing(typeof(IRepository<>));
                    scan.ConnectImplementationsToTypesClosing(typeof(RepositoryBase<,>));
                    scan.ConnectImplementationsToTypesClosing(typeof(EFRepositoryBase<>));
                });

                config.For<ICustomerRepository>().Use<CustomerRepository>();
                config.For<IRepository<Order>>().Use<EFRepositoryBase<Order>>();
            });
        }

        public static void ShowExample()
        {
            Console.WriteLine();
            Console.WriteLine("Generic Examples");
            OpenToClose<ICustomerRepository>("Customer");
            OpenToClose<IRepository<Customer>>("Customer");
            OpenToClose<IRepository<Order>>("Order");

            //Generic repository can let you get most closed concrete type in your selections. So you can get a repository even when you didn't implement anything about it.
        }

        private static void OpenToClose<TOpen>(string closedRepoName)
        {
            var repo = ObjectFactory.GetInstance<TOpen>();
            Console.WriteLine("{0} Repository type is {1} injected from {2}", closedRepoName, repo.GetType().Name, typeof(TOpen).Name);
        }
    }
}

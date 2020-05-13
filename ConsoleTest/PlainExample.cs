using RepositoryLayer.Core;
using RepositoryLayer.Repository.Contract;
using RepositoryLayer.Repository.Plain.Dapper;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{

    public class PlainExample
    {
        public static void Init()
        {
            ObjectFactory.Initialize(config =>
            {
                config.Scan(scan =>
                {
                    scan.ExcludeNamespace("RepositoryLayer.Repository.Generic");
                    scan.ExcludeNamespace("RepositoryLayer.Repository.Static");
                    scan.WithDefaultConventions();
                    scan.AssemblyContainingType(typeof(IRepository));
                });

                config.For<ICustomerRepository>().Use<CustomerRepository>();
            });
        }

        public static void ShowExample()
        {
            Console.WriteLine();
            Console.WriteLine("Plain Examples");
            OpenToClose<ICustomerRepository>("Customer");
            
            //you cannot ask for a concrete type of a base class. Because there is no generic base class. So it cannot resolve which one for which.
        }

        private static void OpenToClose<TOpen>(string closedRepoName)
        {
            var repo = ObjectFactory.GetInstance<TOpen>();
            Console.WriteLine("{0} Repository type is {1} injected from {2}", closedRepoName, repo.GetType().Name, typeof(TOpen).Name);
        }
    }
}

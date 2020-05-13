using RepositoryLayer.Repository.Static;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{

    public class StaticExample
    {
        public static void Init()
        {
            ObjectFactory.Initialize(config =>
            {
                config.Scan(scan =>
                {
                    scan.ExcludeNamespace("RepositoryLayer.Repository.Plain");
                    scan.ExcludeNamespace("RepositoryLayer.Repository.Generic");
                    scan.WithDefaultConventions();
                });

                config.For<CustomerRepository>().Use<CustomerRepository>();
            });
        }

        public static void ShowExample()
        {
            Console.WriteLine();
            Console.WriteLine("Static Examples");
            OpenToClose<CustomerRepository>("Customer");

            //static repositories are fully baked, so there is no interface or resolving from base class. Only returns class itself.
        }

        private static void OpenToClose<TOpen>(string closedRepoName)
        {
            var repo = ObjectFactory.GetInstance<TOpen>();
            Console.WriteLine("{0} Repository type is {1} injected from {2}", closedRepoName, repo.GetType().Name, typeof(TOpen).Name);
        }
    }
}

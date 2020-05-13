//-----------------------------------------------------------------------
//Notice
//Yusuf Uzun 
//Related Article Here:
//https://ysfuz.com/2014/08/03/thoughts-on-repository-patterns-and-implementation-techniques/
//-----------------------------------------------------------------------

using RepositoryLayer.Model;
using RepositoryLayer.Repository.Contract;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Examples about repository pattern styles. Not repository pattern itself.
            //So architecture may look little bit silly. Because I wanted to keep it simple as much as I can do.
            //This is why I put everything into one project and seperated them with folders.
            //All persistence connections are unreal, so if you try to use repository methods you get exception.

            //Generic Example
            GenericExample.Init();
            GenericExample.ShowExample();
        
            //Static Example
            StaticExample.Init();
            StaticExample.ShowExample();

            //Plain Example
            PlainExample.Init();
            PlainExample.ShowExample();
        }

    }


}

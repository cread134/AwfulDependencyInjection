using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    internal class TestObject
    {
        ExampleService exampleService;

        public TestObject() 
        {
            Console.WriteLine("Created test object");
            exampleService = DependencyService.Resolve<ExampleService>();
            Console.WriteLine(exampleService.Id);
        }
    }
}

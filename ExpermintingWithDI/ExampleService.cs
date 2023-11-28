using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    internal class ExampleService
    {

        public ExampleService() { 
            Id = Guid.NewGuid();
        }

        Guid id;
        public Guid Id { get => id; set => id = value; }
    }
}

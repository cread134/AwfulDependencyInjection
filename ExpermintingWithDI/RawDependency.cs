using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class RawDependency
    {
        protected RawDependency(Type dependencyType)
        { 
            Console.WriteLine("Created dependency of type " +  dependencyType.ToString());
        }

        public abstract T GetService<T>();

        public abstract void CreateService(Type generateType);

        public abstract void RegisterConstructor(params object[] constructorArguments);
    }
}

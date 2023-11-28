using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    internal class SingletonDependency : RawDependency
    {
        object? _instance;

        public SingletonDependency(Type dependencyType) : base(dependencyType)
        {

        }

        public override T GetService<T>()
        {
            return (T?)_instance ?? throw new InvalidOperationException("Not singleton instance was created");
        }

        object[]? _constructorArguments;

        public override void RegisterConstructor(params object[] constructorArguments)
        {
            Console.WriteLine(" added new constructor " + constructorArguments.Length);
            _constructorArguments = constructorArguments;
        }

        public override void CreateService(Type generateType)
        {
            Console.WriteLine("wants type " + generateType + "args of " + _constructorArguments);
            _instance = _constructorArguments == null ?
                Activator.CreateInstance(generateType)
                : Activator.CreateInstance(generateType, args:_constructorArguments);
        }
    }
}

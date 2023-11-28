using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core;
public class DependencyService
{
    private Dictionary<Type, RawDependency> _dependencyRegistry;

    private static DependencyService? _instance;

    public static DependencyService Instance 
    { 
        get 
        { 
            if(_instance == null)
            {
                _instance = new DependencyService();
            }
            return _instance; 
        } set => _instance = value; }

    public static DependencyService BuildContainer()
    {
        return new DependencyService();
    }

    public DependencyService() 
    {
        _dependencyRegistry = new Dictionary<Type, RawDependency>();
        Instance = this;
        Console.WriteLine("Initialised dependencyService");
    }

    public RawDependency? AddService<T>(ServiceType serviceType)
    {
        var rawType = typeof(T);
        if (_dependencyRegistry.ContainsKey(rawType))
        {
            throw new InvalidOperationException("Cannot add already existing service");
        }
        switch (serviceType)
        {
            case ServiceType.Singleton:
                var instance = new SingletonDependency(rawType);
                _dependencyRegistry.Add(rawType, instance);
                return instance;
            case ServiceType.Transient:
                return null;
        }
        return null;
    }

    public void RemoveService<T>() 
    { 
        if (_dependencyRegistry.ContainsKey(typeof(T)))
        {
            _dependencyRegistry.Remove(typeof(T));
        }
    }

    T ResolveCore<T>()
    {
        var rawType = typeof(T);
        if(_dependencyRegistry.ContainsKey(rawType))
        {
            return _dependencyRegistry[rawType].GetService<T>() ?? throw new InvalidOperationException("Could not resolve dependency");
        }
        throw new InvalidOperationException("No registered dependency for type");
    }

    public static T Resolve<T>()
    {
        return Instance.ResolveCore<T>();
    }

    public void GenerateDependencies()
    {
        foreach (var item in _dependencyRegistry.Keys)
        {
            _dependencyRegistry[item].CreateService(item);
        }
    }
}

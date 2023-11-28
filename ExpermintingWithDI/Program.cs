namespace Core;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Wow");
        var container = DependencyService.BuildContainer();

        container.AddService<ExampleService>(ServiceType.Singleton);
        container.AddService<ExampleConstructorService>(ServiceType.Singleton)?
            .RegisterConstructor(10);

        container.GenerateDependencies();

        new TestObject();
    }
}
using Microsoft.Extensions.DependencyInjection;
using ServiceCollectionClassDemo.Model;

namespace ServiceCollectionClassDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "DI-ServiceCollection Class";

            // Create and configure the service collection
            var services = new ServiceCollection();
            services.AddTransient<IXMLWriter, XMLWriter>();
            services.AddScoped<IJSONWriter, JSONWriter>();

            var provider = services.BuildServiceProvider();

            // Display menu
            Console.WriteLine("Dependency Injection Demo");
            Console.WriteLine("Mapping Interfaces to instance classes");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Please, select message format (1):XML | (2):JSON");

            var res = Console.ReadLine();
            if (res == "1")
            {
                var XMLInstance = provider.GetService<IXMLWriter>();
                XMLInstance.WriteXML();
            }
            else
            {
                var JSONInstance = provider.GetService<IJSONWriter>();
                JSONInstance.WriteJSON();
            }

            // Inspect registered services
            Console.WriteLine("\nRegistered XML Services:");
            var registeredXMLServices = provider.GetServices<IXMLWriter>();
            foreach (var svc in registeredXMLServices)
            {
                Console.WriteLine($"Service Name:{svc.ToString()}");
            }

            Console.WriteLine(new string('*', 20));

            Console.WriteLine("\nService Collection Properties:");
            foreach (var svc in services)
            {
                Console.WriteLine($"Type: {svc.ImplementationType} \n" +
                                $"Lifetime: {svc.Lifetime} \n" +
                                $"Service Type: {svc.ServiceType}");
            }

            Console.ReadLine();
        }
    }
}

using System;
using System.IO;
using Newtonsoft.Json;

namespace SingleResponsibilityPrincipleDemo.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" List of Books");
            Console.WriteLine("-----------------------------");
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data", "BookStore.json");
            var cadJSON = File.ReadAllText(filePath);
            var bookList = JsonConvert.DeserializeObject<Book[]>(cadJSON);
            foreach (var item in bookList)
            {
                Console.WriteLine($" {item.Title.PadRight(39, ' ')} " +
                                  $" {item.Author.PadRight(15, ' ')} " +
                                  $" {item.Price} ");
            }
            Console.Read();
        }
    }
}

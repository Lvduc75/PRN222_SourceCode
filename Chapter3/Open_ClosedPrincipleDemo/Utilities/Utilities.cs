using Newtonsoft.Json;
using SingleResponsibilityPrincipleDemo.Model;
using System.Collections.Generic;
using System.IO;

internal class Utilities
{
    static string ReadFile(string filename)
    {
        return File.ReadAllText(filename);
    }

    internal static List<Book> ReadData()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data", "BookStore1.json");
        var cadJSON = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<Book>>(cadJSON);
    }

    internal static List<Book> ReadDataExtra()
    {
        List<Book> books = ReadData();
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data", "BookStore2.json");
        var cadJSON = File.ReadAllText(filePath);
        books.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJSON));
        return books;
    }
}
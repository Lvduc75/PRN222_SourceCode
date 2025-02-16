namespace ConstructorInjectionPatternDemo.Model
{
    public interface IBookReader
    {
        void ReadBooks();
    }

    public class XMLBookReader : IBookReader
    {
        public void ReadBooks()
        {
            Console.WriteLine("Books read in XML format");
        }
    }
    public class JSONBookReader : IBookReader
    {
        public void ReadBooks()
        {
            Console.WriteLine("Books read in JSON format");
        }
    }
}

using System.Xml.XPath;

namespace PLINQDemonstration01
{
    class Program
    {
        public static void Main(string[] args)
        {
            var range = Enumerable.Range(1, 1_000_000); // Tạo một dãy số nguyên liên tiếp, bắt đầu từ một giá trị xác định và có số lượng
            // Here is Sequential version
            var resultList = range.Where(x => x % 3 == 0).ToList();
            Console.WriteLine($"Sequential: Total items are {resultList.Count}");
            // Here is Parallel version using .AsParallel method
            resultList = range.AsParallel().Where(x => x % 3 == 0).ToList();
            Console.WriteLine($"Parallel: Total items are {resultList.Count}");
            resultList = (from i in range.AsParallel()
                          where i % 3 == 0
                          select i).ToList();
            Console.WriteLine($"Parallel: Total items are {resultList.Count}");
            Console.ReadLine();
        }
    }
}

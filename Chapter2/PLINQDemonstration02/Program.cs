using System.Collections.Concurrent;
using System.Diagnostics;

namespace PLINQDemonstration02
{
    class Program
    {
        // IsPrime returns true if number is prime, else false
        private static bool IsPrime(int number)
        {
            bool result = true;
            if (number < 2) return false;
            for(var divisor = 2; divisor <= Math.Sqrt(number) && result == true; divisor++)
            {
                if (number % divisor == 0)
                {
                    result = false;
                }
            }
            return result;
        }
        // GetPrimeList returns Prime numbers by using sequential ForEach
        private static IList<int> GetPrimeList(IList<int> numbers) => numbers.Where(IsPrime).ToList();

        // GetPrimeListParallel returns Prime numbers by using Parallel.ForEach
        private static IList<int> GetPrimeListParallelWithParallel(IList<int> numbers)
        {
            var primeNumbers = new ConcurrentBag<int>();
            Parallel.ForEach(numbers, number =>
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            });
            return primeNumbers.ToList();
        }
        public static void Main(string[] args)
        {
            var limit = 2_000_000;
            var numbers = Enumerable.Range(0, limit).ToList();

            var watch = Stopwatch.StartNew();
            var primeNumbersFromForEach = GetPrimeList(numbers);
            watch.Stop();

            var watchForParallel = Stopwatch.StartNew();
            var primeNumbersFromParallelForEach = GetPrimeListParallelWithParallel(numbers);
            watchForParallel.Stop();

            Console.WriteLine($"Classical foreach loop | Total prime numbers :" +
                $"{primeNumbersFromForEach.Count} | Time Taken : " + 
                $"{watch.ElapsedMilliseconds} ms.");

            Console.WriteLine($"Parallel.foreach loop | Total prime numbers :" +
                $"{primeNumbersFromParallelForEach.Count} | Time Taken : " +
                $"{watchForParallel.ElapsedMilliseconds} ms.");
        }
        
    }
}

using System.Net;

namespace AsynchronousDemonstration01
{
    class Program
    {
        // Using Event-based Asynchronous Pattern (EAP)
        private static void DownloadAsynchronously()
        {
            var client = new WebClient();
            client.DownloadStringCompleted +=
                new DownloadStringCompletedEventHandler(DownloadComplete);
            client.DownloadStringAsync(new Uri("http://www.aspnet.com"));
        }
        private static void DownloadComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine("Some error has occured. ");
                return;
            }
            // Print result
            Console.WriteLine(e.Result);
            Console.WriteLine(new String('*', 30));
            Console.WriteLine("Download completed.");
        }
        // -----------------------------------------------------------------
        public static void Main(string[] args)
        {
            DownloadAsynchronously();
            Console.WriteLine("Main thread: Done");
            Console.WriteLine(new String('*', 30));
            Console.ReadLine();
        }
    }
}

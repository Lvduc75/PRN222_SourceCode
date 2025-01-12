using System;
using System.IO;
using System.Net;

namespace Sample1
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    demo1();
        //}
        static void demo1() {
            // Create a request for the URL
            WebRequest request = WebRequest.Create("http://www.contoso.com/default.html");
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine("Status: " + response.StatusDescription);
            Console.WriteLine(new String('*', 50));
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            Console.WriteLine(new String('*', 50));
            // Cleanup the streams and the respone.
            reader.Close();
            dataStream.Close();
            response.Close();
        }
        static readonly HttpClient client = new HttpClient();
        static async Task Main()
        {
            string uri = "http://www.contoso.com/";
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                string responseBoy = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBoy);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message: {0}", e.Message);
            }
        }
    }
}

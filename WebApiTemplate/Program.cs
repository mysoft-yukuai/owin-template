using Microsoft.Owin.Hosting;
using System;

namespace WebApiTemplate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string baseAddress = "http://localhost:8079/";
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("Server running at {0}", baseAddress);
                Console.ReadLine(); // Keep the console application running
            }
        }
    }
}

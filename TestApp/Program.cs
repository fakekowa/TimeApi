using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureTime;

namespace TestApp
{
    class Program
    {
        static Clock clock = new Clock();
        static async Task Main(string[] args)
        {
            bool auth = await Authenticate();
            if (auth)
            {
                Console.WriteLine(clock.GetTime());
            }
            else
                Console.WriteLine("Authenticate yourself");
            Console.ReadLine();
        }

        static async Task<bool> Authenticate()
        {
            bool auth = await clock.Authenticate("bobz", "bob");
            return auth;
        }
    }
}

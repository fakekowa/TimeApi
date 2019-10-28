using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthMe;

namespace TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var authService = new AuthService();
            //Uppgift 1 hämta ett klipp
            string token = await authService.Authenticate("bob", "bob");
            Console.WriteLine($"Your token is: {token}");
            //Uppgift 2 spela upp ett klipp i en webbrowser som startas av programmet
            PlayClip(token);
            //Uppgift 3 vänta på att det förra klippet spelats färdigt
            WaitForClip();

            //Uppgift 4 hämta ett nytt klipp
            PlayClip(token);

        }

        private static void WaitForClip()
        {
            var done = "N";
            do
            {
                Console.WriteLine("Is the clip done? Y/N");
                done = Console.ReadLine();
                if (done == "Y")
                {
                    break;
                }

            }
            while (done != "Y");
        }

        private static async void PlayClip(string token)
        {
            ProcessStartInfo psi = new ProcessStartInfo("chrome.exe");
            Console.WriteLine("Your funny clip is: ");
            psi.Arguments = await ClipService.FunnyClipService.GetClip(token);
            Process.Start(psi);
        }
    }
}

using AuthMe;
using System;
using Newtonsoft;
using System.Threading.Tasks;

namespace ClipService
{
    public class FunnyClipService
    {
        static Random random = new Random();
        static private string[] clips = new string[]{
            "https://www.youtube.com/watch?v=8b0BzaU62a8",
            "https://www.youtube.com/watch?v=zirIQPTHI2g",
            "https://www.youtube.com/watch?v=GiRnRomNOZU",
            "https://www.youtube.com/watch?v=mu1WQMC5bp0",
            "https://www.youtube.com/watch?v=ymNFyxvIdaM",
            "https://www.youtube.com/watch?v=DhqXla91vaE",
            "https://www.youtube.com/watch?v=WLmcmhKzg58",
            "https://www.youtube.com/watch?v=s-mOy8VUEBk",
            "https://www.youtube.com/watch?v=6zY6O6SOO8c",
            "https://www.youtube.com/watch?v=uhEpMJ3n_wU",
            "https://www.youtube.com/watch?v=O65Lx1053D0",
            "https://www.youtube.com/watch?v=5aLR-8c11ms",
            "https://www.youtube.com/watch?v=esVuKP7k974",
            "https://www.youtube.com/watch?v=JBC-9k3y1ew",
            "https://www.youtube.com/watch?v=dJB0BkJlbbw",
            "https://www.youtube.com/watch?v=Ezg4sr67OGA",
            "https://www.youtube.com/watch?v=g6h1IP7eYiU"
        };
        /// <summary>
        /// This method returns an URL string to a clip
        /// </summary>
        /// <param name="authToken">a valid AuthService token is required to operate</param>
        /// <returns>Returns a URL to a clip</returns>
        public static async Task<string> GetClip(string authToken)
        {
            try
            {
                AuthService authservice = new AuthService();
                var isValid = await authservice.IsValidToken(authToken);
                if (isValid)
                {
                    return clips[random.Next(0, clips.Length)];
                }
                else
                    throw new AuthenticationException("Your token is expired, please refresh your token", null);
            }
            catch
            {
                throw;
            }
        }
    }
}

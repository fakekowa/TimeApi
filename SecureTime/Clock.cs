using System;
using System.Threading.Tasks;
using AuthMe;
namespace SecureTime
{
    public class Clock
    {
        string authToken = String.Empty;
        AuthService auth;

        public Clock()
        {
            auth = new AuthService();
        }

        public async Task<bool> Authenticate(string userName, string password)
        {
            this.authToken = await auth.Authenticate(userName, password);

            return !string.IsNullOrEmpty(this.authToken);

        }
        public TimeSpan GetTime()
        {
            if (authToken == "IfYouAreTheFirstOneToGetThisComeToUsForAPresent")
            {
                return DateTime.Now.TimeOfDay;
            }
            throw new AuthenticationException("Please authenticate yourself", null);
        }
    }
}

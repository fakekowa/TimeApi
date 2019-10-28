using System;
using System.Threading.Tasks;
using AuthMe;
namespace SecureTime
{
    public class FunnyService : IFunnyService
    {
        AuthService auth;

        public FunnyService()
        {
            auth = new AuthService();
        }
        public TimeSpan GetTime(string authToken)
        {
            if (authToken == "IfYouAreTheFirstOneToGetThisComeToUsForAPresent")
            {
                return DateTime.Now.TimeOfDay;
            }
            throw new AuthenticationException("Please authenticate yourself", null);
        }
    }
}

using System;
using System.Threading.Tasks;

namespace AuthMe
{
    public class AuthService : IAuthService
    {
        public Task<string> Authenticate(string username, string password)
        {
            Task.Delay(20000);
            if (username == "bob" && password == "bob")
            {
                return Task.FromResult("IfYouAreTheFirstOneToGetThisComeToUsForAPresent");
            }

            throw new AuthenticationException("Invalid Username", null);

        }
    }

    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

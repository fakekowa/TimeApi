using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft;

namespace AuthMe
{
    public class AuthService : IAuthService
    {

        /// <summary>
        /// Returns an authentication token with an validity of 10 seconds
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> Authenticate(string username, string password)
        {
            Thread.Sleep(2000);
            if (username == "bob" && password == "bob")
            {
                var token = new AuthServiceToken(username, "IfYouAreTheFirstOneToGetThisComeToUsForAPresent");
                return Newtonsoft.Json.JsonConvert.SerializeObject(token).Base64Encode();
            }

            throw new AuthenticationException("Invalid Username", null);

        }

        /// <summary>
        /// Revives an expired authentication token
        /// </summary>
        /// <param name="encodedToken"></param>
        /// <returns></returns>
        public async Task<string> RefreshToken(string encodedToken)
        {
            try
            {
                Thread.Sleep(2000);
                var authToken = DecodeToken(encodedToken);
                authToken.Expires.AddSeconds(10);

                return Newtonsoft.Json.JsonConvert.SerializeObject(authToken).Base64Encode();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> IsValidToken(string authToken)
        {
            Thread.Sleep(2000);

            try
            {
                var decodedAuthToken = DecodeToken(authToken);
                if (decodedAuthToken.Expires > DateTime.Now)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }

            return false;
        }


        private static AuthServiceToken DecodeToken(string token)
        {
            var authTokenDecoded = token.Base64Decode();

            var authToken = Newtonsoft.Json.JsonConvert.DeserializeObject<AuthServiceToken>(authTokenDecoded);

            return authToken;
        }
    }

        public static class AuthHelper
        {
            /// <summary>
            /// Takes a string input and encodes it to a Base64 string
            /// </summary>
            /// <param name="input">The string to be encoded</param>
            /// <returns>An encoded string</returns>
            public static string Base64Encode(this string input)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(input);
                return System.Convert.ToBase64String(plainTextBytes);
            }
            /// <summary>
            /// Takes a string Base64 input and Decodes it to a Base64 string
            /// </summary>
            /// <param name="token">The base64encoded string to be decoded</param>
            /// <returns>An decoded string</returns>
            public static string Base64Decode(this string base64EncodedData)
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
        }

        public class AuthServiceToken
        {
            public AuthServiceToken(string userName, string hiddenMessage)
            {
                this.UserName = userName;
                this.HiddenMessage = hiddenMessage;
                this.Expires = DateTime.Now.AddSeconds(10);

            }
            public AuthServiceToken()
            {

            }
            public string UserName { get; set; }
            public DateTime Expires { get; set; }
            public string HiddenMessage { get; set; }
        }

        public class AuthenticationException : Exception
        {
            public AuthenticationException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
    }

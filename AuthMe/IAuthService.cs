using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthMe
{
    interface IAuthService
    {
        /// <summary>
        /// Returns an authentication token with an validity of 10 seconds
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<string> Authenticate(string username, string password);
        /// <summary>
        /// Revives an expired authentication token
        /// </summary>
        /// <param name="encodedToken"></param>
        /// <returns></returns>
        Task<string> RefreshToken(string encodedToken);

        /// <summary>
        /// Checks a tokens validity
        /// </summary>
        /// <param name="encodedToken">The token</param>
        /// <returns>A bool saying if the token is valid or not</returns>
        Task<bool> IsValidToken(string authToken);
    }
}

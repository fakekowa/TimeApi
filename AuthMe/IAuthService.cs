using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthMe
{
    interface IAuthService
    {
        //Complex calculation to make sure username and password are correct, extremely threadsafe
        Task<string> Authenticate(string username, string password);
    }
}

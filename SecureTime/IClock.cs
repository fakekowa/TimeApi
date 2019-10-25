using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecureTime
{
    interface IClock
    {
        Task<bool> Authenticate(string userName, string password);
        DateTime GetTime();
    }
}

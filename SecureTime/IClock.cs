using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecureTime
{
    interface IFunnyService
    {
        TimeSpan GetTime(string authToken);
    }
}

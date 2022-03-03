using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageAmericaAPI.Helpers
{
    public class HttpResponseException:Exception
    {
        public HttpResponseException(string message) : base(message)
        {
        }

    }
}

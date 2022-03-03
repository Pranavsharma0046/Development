using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageAmericaAPI.Helpers
{
    public class UnSucessFullException:Exception
    {
        public UnSucessFullException()
        {
        }

        public UnSucessFullException(string message) : base(message)
        {
        }
    }
}

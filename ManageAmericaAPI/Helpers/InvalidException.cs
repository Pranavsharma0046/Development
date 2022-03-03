using System;

namespace ManageAmericaAPI.Helpers
{
    public class InvalidException : Exception
    {
        public InvalidException(string message) : base(message)
        {

        }
    }
}

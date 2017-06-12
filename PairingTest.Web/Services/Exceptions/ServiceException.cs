using System;

namespace PairingTest.Web.Services.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string msg) : base(msg)
        {
        }
    }
}
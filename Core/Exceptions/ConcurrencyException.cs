using System;

namespace Core.Exceptions
{
    public class ConcurrencyException : Exception
    {
        public ConcurrencyException() : base("There was an concurrency error while saving, please refresh and try again")
        {
        }
    }
}

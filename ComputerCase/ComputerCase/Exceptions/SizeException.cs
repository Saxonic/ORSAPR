using System;

namespace ComputerCase.Exceptions
{
    public class SizeException : Exception
    {
        public SizeException()
        {
        }
        
        public SizeException(string message) : base(message)
        {
        }
        
        public SizeException(string message,Exception innerException) : base(message,innerException)
        {
        }
    }
}
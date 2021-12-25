using System;

namespace ComputerCase.Exceptions
{
    public class SizeDependencyException : Exception
    {
        public SizeDependencyException()
        {
        }
        
        public SizeDependencyException(string message) : base(message)
        {
        }
        
        public SizeDependencyException(string message,Exception innerException) : base(message,innerException)
        {
        }
    }
}
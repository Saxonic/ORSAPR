using System;

namespace ComputerCase.Exceptions
{
    /// <summary>
    /// Исключение при значении выходящем за диапазон допустимых значений
    /// </summary>
    public class OutOfBoundsException : Exception
    {
        public OutOfBoundsException()
        {
        }
        
        public OutOfBoundsException(string message) : base(message)
        {
        }
        
        public OutOfBoundsException(string message,Exception innerException) : base(message,innerException)
        {
        }
    }
}
using System;

namespace ComputerCase.Exceptions
{
    /// <summary>
    /// Исключение, герерируемое при значении выходящем за диапазон допустимых значений
    /// </summary>
    public class OutOfBoundsException : Exception
    {
        //TODO: XML
        public OutOfBoundsException(string message) : base(message)
        {
        }
    }
}
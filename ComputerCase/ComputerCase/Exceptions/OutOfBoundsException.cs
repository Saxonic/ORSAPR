using System;

namespace ComputerCase.Exceptions
{
    /// <summary>
    /// Исключение, герерируемое при значении выходящем за диапазон допустимых значений
    /// </summary>
    public class OutOfBoundsException : Exception
    {
        //TODO: XML
        /// <summary>
        /// Исключение, содержащее в себе пользовательское сообщение
        /// </summary>
        /// <param name="message"></param>
        public OutOfBoundsException(string message) : base(message)
        {
        }
    }
}
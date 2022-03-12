using System;

namespace ComputerCase.Exceptions
{
    /// <summary>
    /// Исключение, генерируемое при несоответсвии зависимых размеров
    /// </summary>
    public class SizeDependencyException : Exception
    {
        //TODO: XML
        /// <summary>
        /// Исключение, содержащее в себе пользовательское сообщение
        /// </summary>
        /// <param name="message"></param>
        public SizeDependencyException(string message) : base(message)
        {
        }
    }
}
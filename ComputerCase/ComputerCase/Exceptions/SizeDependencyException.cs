using System;

namespace ComputerCase.Exceptions
{
    /// <summary>
    /// Исключение, генерируемое при несоответсвии зависимых размеров
    /// </summary>
    public class SizeDependencyException : Exception
    {
        public SizeDependencyException(string message) : base(message)
        {
        }
    }
}
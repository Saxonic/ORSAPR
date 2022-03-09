namespace ComputerCase
{
    /// <summary>
    /// Сервисных класс, осуществляющий проверку переданных значений
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Сообщение при возникновении ошибки зависимых размеров со значениями: Высота, диаметр отверстий под
        /// верхние вентиляторы и их кол-во
        /// </summary>
        public static string HeightDependencyExceptionMessage = "Отверстия под вентиляторы с заданным размером " +
                                                                "не могут быть умещены на корпусе с указанной высотой";
        
        /// <summary>
        /// Сообщение при возникновении ошибки зависимых размеров со значениями: Длина, диаметр отверстий под
        /// передние вентиляторы и их кол-во
        /// </summary>
        public static string LengthDependencyExceptionMessage = "Отверстия под вентиляторы с заданным размером " +
                                                                "не могут быть умещены на корпусе с указанной длиной";

        /// <summary>
        /// Проверка, входит ли указанное число в заданный диапазон 
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Validate(double max, double min, double value)
        {
            return !(max < value) && !(min > value);
        }
    }
}
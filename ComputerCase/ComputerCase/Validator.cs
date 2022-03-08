namespace ComputerCase
{
    public static class Validator
    {
        public static string HeightDependencyExceptionMessage = "Отверстия под вентиляторы с заданным размером " +
                                                                "не могут быть умещены на корпусе с указанной длиной";

        public static string WidthDependencyExceptionMessage = "Отверстия под вентиляторы с заданным размером " +
                                                               "не могут быть умещены на корпусе с указанной высотой";

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
namespace ComputerCase
{
    public static class Validator
    {
        /// <summary>
        /// Проверка, входит ли указанное число в заданный диапазон 
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Validate(double max, double min, double value)
        {
            return !(max <= value) && !(min >= value);
        }
        
    }
}
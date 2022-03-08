namespace ComputerCase
{
    /// <summary>
    /// Интерфейс, содержащий методы необходимые для построения корпуса
    /// </summary>
    public interface IBuilderProgramAPI
    {
        /// <summary>
        /// Создать дно корпуса
        /// </summary>
        /// <param name="length">Длина корпуса</param>
        /// <param name="width">Ширина корпуса</param>
        public void CreateBottom(double length, double width);

        /// <summary>
        /// Создать стенки корпуса с отверстиями под вентиляторы
        /// </summary>
        /// <param name="length">Длина корпуса</param>
        /// <param name="width">Ширина корпуса</param>
        /// <param name="height">Высота корпуса</param>
        /// <param name="frontFansDiameter">Диаметр передних вентиляторов</param>
        public void CreateSides(double length, double width, double height, double frontFansDiameter);

        /// <summary>
        /// Создать крышу корпуса с отверстиями под вентиляторы
        /// </summary>
        /// <param name="width">Ширина корпуса</param>
        /// <param name="upperFansDiameter">Диаметр верхних вентиляторов</param>
        /// <param name="length">Длина корпуса</param>
        public void CreteRoof(double length, double width, double upperFansDiameter);
    }
}
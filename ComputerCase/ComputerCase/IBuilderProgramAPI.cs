namespace ComputerCase
{
    /// <summary>
    /// Интерфейс, содержащий методы необходимые для построения корпуса
    /// </summary>
    public interface IBuilderProgramAPI
    {
        /// <summary>
        /// Создать эскиз круга
        /// </summary>
        /// <param name="diameter">Диаметр</param>
        /// <param name="x">Центр круга по Х</param>
        /// <param name="y">Центр круга по Y</param>
        void CreateCircle(double diameter, double x, double y);

        /// <summary>
        /// Создать эскиз прямоугольника
        /// </summary>
        /// <param name="startDotX">начальная точка по X</param>
        /// <param name="startDotY">начальная точка по Y</param>
        /// <param name="endDotX">начальная точка по X</param>
        /// <param name="endDotY">начальная точка по Y</param>
        void CreateRectangle(double startDotX, double startDotY, double endDotX, double endDotY);

        /// <summary>
        /// Выдавить эскиз круга
        /// </summary>
        /// <param name="depth">Глубина выдавливания</param>
        void ExtrudeCutCircle(double depth);

        /// <summary>
        /// Построить выдавливанием из эскиза прямоугольника
        /// </summary>
        /// <param name="depth"></param>
        void ExtrudeRectangle(double depth);
    }
}
using System;
using ComputerCase;

namespace ApiFactory
{
    //TODO: RSDN
    /// <summary>
    /// Класс, предоставляющий реализацию интерфейса для построения
    /// корпуса в програме, соответствующей переданному ключу
    /// </summary>
    public static class BuilderApiFactory
    {
        /// <summary>
        /// Получить класс, необходимый для использования указанного API
        /// </summary>
        /// <param name="key">"Компас - 3D" - класс для работы с компас-3D.
        /// "Inventor" - класс для работы с Inventor</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IBuilderProgramAPI GetApi(BuilderProgramName key)
        {
            switch (key)
            {
                case BuilderProgramName.Kompas3D:
                    return new KompasAPI.KompasAPI();
                case BuilderProgramName.Inventor:
                    return new InventorAPI.InventorAPI();
                default:
                    throw new ArgumentException(
                        "Не удалось сгенерировать API по указанному ключу.");
            }
        }
    }
}
using System;
using ComputerCase;

namespace ApiFactory
{
    /// <summary>
    /// Класс, предоставляющий реализацию интерфейса для построения корпуса в програме, соответствующей переданному ключу
    /// </summary>
    public class BuilderApiFactory
    {
        /// <summary>
        /// Получить класс, необходимый для использования указанного API
        /// </summary>
        /// <param name="key">"Компас - 3D" - класс для работы с компас-3D.
        /// "Inventor" - класс для работы с Inventor</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IBuilderProgramAPI GetApi(string key)
        {
            switch (key)
            {
                case "Компас - 3D":
                    return new KompasAPI.KompasAPI();
                case "Inventor":
                    return new InventorAPI.InventorAPI();
                default:
                    throw new ArgumentException("Не удалось сгенерировать API по указанному ключу.");
            }
        }
    }
}
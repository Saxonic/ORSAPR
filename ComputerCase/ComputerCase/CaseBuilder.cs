namespace ComputerCase
{
    /// <summary>
    /// Класс, отвечающий за построение корпуса
    /// </summary>
    public class CaseBuilder
    {
        //TODO: XML
        private IBuilderProgramAPI _builderAPI;

        //TODO: XML
        public CaseBuilder(IBuilderProgramAPI builderApi)
        {
            _builderAPI = builderApi;
        }

        /// <summary>
        /// Создать компьютерный корпус с указанными параметрами
        /// </summary>
        /// <param name="caseParameters">параметры корпуса</param>
        public void CrateCase(CaseParameters caseParameters)
        {
            _builderAPI.OpenAPI();
            _builderAPI.CreateBottom(caseParameters.Length,caseParameters.Width);
            _builderAPI.CreateSides(caseParameters.Length,caseParameters.Width,caseParameters.Height,
                caseParameters.FrontFansDiameter,caseParameters.FrontFansCount);
            _builderAPI.CreteRoof(caseParameters.Length,caseParameters.Width,caseParameters.Height,
                caseParameters.UpperFansDiameter,caseParameters.UpperFansCount);
        }
    }
}
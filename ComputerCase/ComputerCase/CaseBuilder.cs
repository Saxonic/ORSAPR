namespace ComputerCase
{
    public class CaseBuilder
    {
        private IBuilderProgramAPI _builderAPI;

        public CaseBuilder(IBuilderProgramAPI builderApi)
        {
            _builderAPI = builderApi;
        }

        public void CrateCase(CaseParameters caseParameters)
        {
            _builderAPI.CreateBottom(caseParameters.Length,caseParameters.Width);
            _builderAPI.CreateSides(caseParameters.Length,caseParameters.Width,caseParameters.Height,
                caseParameters.FrontFansDiameter,caseParameters.FrontFansCount);
        }
    }
}
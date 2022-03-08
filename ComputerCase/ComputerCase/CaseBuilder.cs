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
            CreateBottom(0,0,20);
        }

        private void CreateBottom(double length, double width,double height)
        {
            _builderAPI.CreateRectangleSketch(0,0,20,20);
        }
    }
}
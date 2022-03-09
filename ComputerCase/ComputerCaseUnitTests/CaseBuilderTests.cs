using ComputerCase;
using NUnit.Framework;
using Moq;

namespace ComputerCaseUnitTests
{
    [TestFixture]
    public class CaseBuilderTests
    {
        [Test(Description = "Тест, проверяющий вызов методов, необходимых для построения корпуса")]
        public void CaseBuilderCreateCase_AllMethodsFromInterfaceCalled()
        {
            //arrange
            double height = 400;
            double width = 150;
            double length = 300;
            double frontFansDiameter = 50;
            double upperFansDiameter = 50;
            var upperFansCount = 1;
            var frontFansCount = 1;
            var motherboardType = MotherboardType.ATX;
            
            var builderProgramMock =new Mock<IBuilderProgramAPI>();
            var builder = new CaseBuilder(builderProgramMock.Object);
            var parameter = new CaseParameters
            {
                MotherboardType = motherboardType,
                FrontFansCount = frontFansCount,
                FrontFansDiameter = frontFansDiameter,
                Height = height,
                Length = length,
                Width = width,
                UpperFansCount = upperFansCount,
                UpperFansDiameter = upperFansDiameter
            };
            
            //act
            builder.CrateCase(parameter);
            
            //assert
            builderProgramMock.Verify(b=>b.CreateBottom(length,width),Times.Once);
            builderProgramMock.Verify(b=>b.CreateSides(length,width,height,
                frontFansDiameter,frontFansCount),Times.Once);
            builderProgramMock.Verify(b=>b.CreteRoof(length,width,height,
                upperFansDiameter,upperFansCount),Times.Once);
        }
    }
}
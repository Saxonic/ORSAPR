using ComputerCase;
using ComputerCase.Exceptions;
using NUnit.Framework;

namespace ComputerCaseUnitTests
{
    [TestFixture]
    public class CaseParametersTests
    {
        [Test(Description = "Позитивный тест сеттеров параметра")]
        public void CaseParametersSet_ValuesCorrect()
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
            
            //act
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

            //assert
            Assert.AreEqual(parameter.MotherboardType, motherboardType);
            Assert.AreEqual(parameter.FrontFansCount, frontFansCount);
            Assert.AreEqual(parameter.FrontFansDiameter, frontFansDiameter);
            Assert.AreEqual(parameter.Height, height);
            Assert.AreEqual(parameter.Length, length);
            Assert.AreEqual(parameter.Width, width);
            Assert.AreEqual(parameter.UpperFansCount, upperFansCount);
            Assert.AreEqual(parameter.UpperFansDiameter, upperFansDiameter);
        }

        [TestCase(10, Description = "Значение меньше допустимого")]
        [TestCase(1000, Description = "Значение больше допустимого")]
        [Test(Description = "Негативный тест на сеттер высоты")]
        public void CaseParametersHeightSet_OutOfBoundsExceptionThrown(double wrongValue)
        {
            var parameter = new CaseParameters();
            Assert.Throws<OutOfBoundsException>(() => { parameter.Height = wrongValue; });
        }

        [TestCase(10, Description = "Значение меньше допустимого")]
        [TestCase(1000, Description = "Значение больше допустимого")]
        [Test(Description = "Негативный тест на сеттер длины")]
        public void CaseParametersLengthSet_OutOfBoundsExceptionThrown(double wrongValue)
        {
            var parameter = new CaseParameters();
            Assert.Throws<OutOfBoundsException>(() => { parameter.Length = wrongValue; });
        }

        [TestCase(10, Description = "Значение меньше допустимого")]
        [TestCase(1000, Description = "Значение больше допустимого")]
        [Test(Description = "Негативный тест на сеттер ширины")]
        public void CaseParametersWidthSet_OutOfBoundsExceptionThrown(double wrongValue)
        {
            var parameter = new CaseParameters();
            Assert.Throws<OutOfBoundsException>(() => { parameter.Width = wrongValue; });
        }

        [TestCase(10, Description = "Значение меньше допустимого")]
        [TestCase(1000, Description = "Значение больше допустимого")]
        [Test(Description = "Негативный тест на сеттер диаметра отверстий под передние вентиляторы")]
        public void CaseParametersFrontFansDiameterSet_OutOfBoundsExceptionThrown(double wrongValue)
        {
            var parameter = new CaseParameters();
            Assert.Throws<OutOfBoundsException>(() => { parameter.FrontFansDiameter = wrongValue; });
        }

        [TestCase(10, Description = "Значение меньше допустимого")]
        [TestCase(1000, Description = "Значение больше допустимого")]
        [Test(Description = "Негативный тест на сеттер диаметра отверстий под верхние вентиляторы")]
        public void CaseParametersUpperFansDiameterSet_OutOfBoundsExceptionThrown(double wrongValue)
        {
            var parameter = new CaseParameters();
            Assert.Throws<OutOfBoundsException>(() => { parameter.UpperFansDiameter = wrongValue; });
        }

        [Test(Description = "Негативный тест на ошибку зависимых размеров: длины,ширины корпуса и диаметра отверстий")]
        public void CaseParametersUpperFansDiameterSet_SizeDependencyExceptionThrown()
        {
            var parameter = new CaseParameters
            {
                Width = 150,
                UpperFansDiameter = 140,
                UpperFansCount = 3
            };
            Assert.Throws<SizeDependencyException>(() => { parameter.Length = 300; });
        }

        [Test(Description = "Негативный тест на ошибку зависимых размеров: высоты корпуса и диаметра отверстий")]
        public void CaseParametersFrontFansDiameterSet_SizeDependencyExceptionThrown()
        {
            var parameter = new CaseParameters
            {
                Width = 150,
                FrontFansDiameter = 140,
                FrontFansCount = 3
            };
            Assert.Throws<SizeDependencyException>(() => { parameter.Height = 400; });
        }
    }
}
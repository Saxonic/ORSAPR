using ComputerCase;
using ComputerCase.Exceptions;
using NUnit.Framework;

namespace ComputerCaseUnitTests
{
    [TestFixture]
    public class CaseParametersTests
    {
        private const double CORRECT_HEIGHT = 400;
        private const double CORRECT_WIDTH = 150;
        private const double CORRECT_LENGTH = 300;
        private const double CORRECT_FRONT_FANS_DIAMETER = 50;
        private const double CORRECT_UPPER_FANS_DIAMETER = 50;
        private const int CORRECT_UPPER_FANS_COUNT = 1;
        private const int CORRECT_FRONT_FANS_COUNT = 1;
        private const MotherboardType CORRECT_MOTHERBOARD_TYPE = MotherboardType.ATX;
        
        
        [Test(Description = "Позитивный тест сеттеров параметра")]
        public void CaseParametersSet_ValuesCorrect()
        {
            var parameter = new CaseParameters
            {
                MotherboardType = CORRECT_MOTHERBOARD_TYPE,
                FrontFansCount = CORRECT_FRONT_FANS_COUNT,
                FrontFansDiameter = CORRECT_FRONT_FANS_DIAMETER,
                Height = CORRECT_HEIGHT,
                Length = CORRECT_LENGTH,
                Width = CORRECT_WIDTH,
                UpperFansCount = CORRECT_UPPER_FANS_COUNT,
                UpperFansDiameter = CORRECT_UPPER_FANS_DIAMETER
            };
            
            Assert.AreEqual(parameter.MotherboardType,CORRECT_MOTHERBOARD_TYPE);
            Assert.AreEqual(parameter.FrontFansCount,CORRECT_FRONT_FANS_COUNT);
            Assert.AreEqual(parameter.FrontFansDiameter,CORRECT_FRONT_FANS_DIAMETER);
            Assert.AreEqual(parameter.Height,CORRECT_HEIGHT);
            Assert.AreEqual(parameter.Length,CORRECT_LENGTH);
            Assert.AreEqual(parameter.Width,CORRECT_WIDTH);
            Assert.AreEqual(parameter.UpperFansCount,CORRECT_UPPER_FANS_COUNT);
            Assert.AreEqual(parameter.UpperFansDiameter,CORRECT_UPPER_FANS_DIAMETER);
        }

        [TestCase(10, Description = "Значение меньше допустимого")]
        [TestCase(1000, Description = "Значение больше допустимого")]
        [Test(Description = "Негативный тест на сеттер высоты")]
        public void CaseParametersHeightSet_OutOfBoundsExceptionThrown(double wrongValue)
        {
            var parameter = new CaseParameters();
            Assert.Throws<OutOfBoundsException>(() =>
            {
                parameter.Height = wrongValue;
            });
        }
        
        [TestCase(10, Description = "Значение меньше допустимого")]
        [TestCase(1000, Description = "Значение больше допустимого")]
        [Test(Description = "Негативный тест на сеттер длины")]
        public void CaseParametersLengthSet_OutOfBoundsExceptionThrown(double wrongValue)
        {
            var parameter = new CaseParameters();
            Assert.Throws<OutOfBoundsException>(() =>
            {
                parameter.Length = wrongValue;
            });
        }
        
        [TestCase(10, Description = "Значение меньше допустимого")]
        [TestCase(1000, Description = "Значение больше допустимого")]
        [Test(Description = "Негативный тест на сеттер ширины")]
        public void CaseParametersWidthSet_OutOfBoundsExceptionThrown(double wrongValue)
        {
            var parameter = new CaseParameters();
            Assert.Throws<OutOfBoundsException>(() =>
            {
                parameter.Width = wrongValue;
            });
        }
        
        [TestCase(10, Description = "Значение меньше допустимого")]
        [TestCase(1000, Description = "Значение больше допустимого")]
        [Test(Description = "Негативный тест на сеттер диаметра отверстий под передние вентиляторы")]
        public void CaseParametersFrontFansDiameterSet_OutOfBoundsExceptionThrown(double wrongValue)
        {
            var parameter = new CaseParameters();
            Assert.Throws<OutOfBoundsException>(() =>
            {
                parameter.FrontFansDiameter = wrongValue;
            });
        }
        
        [TestCase(10, Description = "Значение меньше допустимого")]
        [TestCase(1000, Description = "Значение больше допустимого")]
        [Test(Description = "Негативный тест на сеттер диаметра отверстий под верхние вентиляторы")]
        public void CaseParametersUpperFansDiameterSet_OutOfBoundsExceptionThrown(double wrongValue)
        {
            var parameter = new CaseParameters();
            Assert.Throws<OutOfBoundsException>(() =>
            {
                parameter.UpperFansDiameter = wrongValue;
            });
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
            Assert.Throws<SizeDependencyException>(() =>
            {
                parameter.Length = 300;
            });
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
            Assert.Throws<SizeDependencyException>(() =>
            {
                parameter.Height = 400;
            });
        }
    }
}
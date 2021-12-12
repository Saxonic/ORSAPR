using ComputerCase.Exceptions;

namespace ComputerCase
{
    public class CaseParameters
    {
        public const int SPACE_BETWEEN_FRONT_FANS = 15;
        public const int SPACE_BETWEEN_UPPER_FANS = 5;
        private const int ATX_PLATE_HEIGHT = 305;
        private const int PLATE_WIDTH = 244;
        private const int MICRO_ATX_PLATE_HEIGHT = 244;
        private const int ATX_POWER_SUPPLY_WIDTH = 140;
        
        private double _height;
        private double _length;
        private double _width;
        private double _frontFanRadius;
        private double _upperFanRadius;

        /// <summary>
        /// Высота корпуса
        /// </summary>
        public double Height
        {
            get => _height;
            set
            {
                var minValue = MotherboardType == MotherboardType.ATX ? ATX_PLATE_HEIGHT : MICRO_ATX_PLATE_HEIGHT;
                _height = Validator.Validate(500, minValue, value) 
                    ? value : throw new OutOfBoundsException($"Длина корпуса не может быть больше 500 или меньше {minValue} мм.");
            }
        }

        /// <summary>
        /// Длина корпуса
        /// </summary>
        public double Length
        {
            get => _length;
            set => _length = Validator.Validate(500, PLATE_WIDTH, value) 
                ? value : throw new OutOfBoundsException($"Длина корпуса не может быть больше 500 или меньше {PLATE_WIDTH} мм.");
        }

        /// <summary>
        /// Ширина корпуса
        /// </summary>
        public double Width
        {
            get => _width;
            set => _width = Validator.Validate(500, ATX_POWER_SUPPLY_WIDTH, value) 
                ? value : throw new OutOfBoundsException($"Ширина корпуса не может быть больше 500 или меньше {ATX_POWER_SUPPLY_WIDTH} мм.");
        }
        
        /// <summary>
        /// Радиус передних вентиляторов
        /// </summary>
        public double FrontFanRadius
        {
            get => _frontFanRadius;
            set
            {
                if (_height == default)
                {
                    _frontFanRadius = Validator.Validate(140, 40, value)
                        ? value : throw new OutOfBoundsException("Диаметр отверстий не может быть больше 140 или меньше 40 мм.");
                }
                else
                {
                    var fansLength = _frontFanRadius * FrontFansNumber +
                                     (SPACE_BETWEEN_FRONT_FANS * FrontFansNumber - 1);
                    _frontFanRadius = Validator.Validate(140, 40, value) &&
                                      Validator.Validate(_height,40,fansLength) 
                        ? value : throw new SizeException();
                }
            }
        }

        /// <summary>
        /// Радиус верхних вентиляторов
        /// </summary>
        public double UpperFanRadius
        {
            get => _upperFanRadius;
            set
            {
                if (_length == default)
                {
                    _upperFanRadius = Validator.Validate(140, 40, value) ? value : throw new OutOfBoundsException("Диаметр отверстий не может быть больше 140 или меньше 40 мм.");
                }
                else
                {
                    var fansLength = _upperFanRadius * UpperFansNumber +
                                     (SPACE_BETWEEN_UPPER_FANS * UpperFansNumber - 1);
                    _upperFanRadius = Validator.Validate(140, 40, value) &&
                                      Validator.Validate(_length,40,fansLength) 
                        ? value : throw new SizeException();
                }
            }
        }

        /// <summary>
        /// Количество верхних вентиляторов
        /// </summary>
        public int UpperFansNumber { get; set; }

        /// <summary>
        /// Количество передних вентиляторов
        /// </summary>
        public int FrontFansNumber { get; set; }
        
        public MotherboardType MotherboardType { get; set; }
    }
}
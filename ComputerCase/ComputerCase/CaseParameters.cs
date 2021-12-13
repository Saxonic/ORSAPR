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
        private double _frontFansDiameter;
        private double _upperFansDiameter;

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
                    ? value : throw new OutOfBoundsException($"Высота корпуса не может быть больше 500 или меньше {minValue} мм.");
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
        public double FrontFansDiameter
        {
            get => _frontFansDiameter;
            set
            {
                _frontFansDiameter = Validator.Validate(140, 40, value)
                        ? value : throw new OutOfBoundsException("Диаметр отверстий не может быть больше 140 или меньше 40 мм.");
                var fansLength = _frontFansDiameter * FrontFansCount +
                                 (SPACE_BETWEEN_FRONT_FANS * FrontFansCount - 1);
                    _frontFansDiameter = Validator.Validate(_height,40,fansLength) 
                        ? value : throw new SizeException("Отверстия под вентиляторы с заданным размером " +
                                                          "не могут быть умещены на корпусе с указанной шириной");
            }
        }

        /// <summary>
        /// Радиус верхних вентиляторов
        /// </summary>
        public double UpperFansDiameter
        {
            get => _upperFansDiameter;
            set
            {
                _upperFansDiameter = Validator.Validate(140, 40, value)
                        ? value : throw new OutOfBoundsException("Диаметр отверстий не может быть больше 140 или меньше 40 мм.");

                var fansLength = _upperFansDiameter * UpperFansCount +
                                 (SPACE_BETWEEN_UPPER_FANS * UpperFansCount - 1);
                    _upperFansDiameter = Validator.Validate(_length,40,fansLength) 
                        ? value : throw new SizeException("Отверстия под вентиляторы с заданным размером " +
                                                          "не могут быть умещены на корпусе с указанной длиной");
            }
        }

        /// <summary>
        /// Количество верхних вентиляторов
        /// </summary>
        public int UpperFansCount { get; set; } = 1;

        /// <summary>
        /// Количество передних вентиляторов
        /// </summary>
        public int FrontFansCount { get; set; } = 1;
        
        public MotherboardType MotherboardType { get; set; }
    }
}
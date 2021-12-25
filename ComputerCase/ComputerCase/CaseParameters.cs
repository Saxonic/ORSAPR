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
        private const int CASE_MAX_SIZE = 500;
        private const int MAX_FANS_SIZE = 140;
        private const int MIN_FANS_SIZE = 40;
        
        private double _height;
        private double _length;
        private double _width;
        private double _frontFansDiameter;
        private double _upperFansDiameter;
        private int _frontFansCount;
        private int _upperFansCount;


        /// <summary>
        /// Высота корпуса
        /// </summary>
        public double Height
        {
            get => _height;
            set
            {
                var minValue = MotherboardType == MotherboardType.ATX ? ATX_PLATE_HEIGHT : MICRO_ATX_PLATE_HEIGHT;
                if (!Validator.Validate(CASE_MAX_SIZE, minValue, value))
                {
                    throw new OutOfBoundsException($"Высота корпуса не может быть больше" +
                                                   $" {CASE_MAX_SIZE} или меньше {minValue} мм.");
                }
                checkFrontValues(value,_frontFansDiameter,_frontFansCount);
                _height = value;
            }
        }

        /// <summary>
        /// Длина корпуса
        /// </summary>
        public double Length
        {
            get => _length;
            set
            {
                if (!Validator.Validate(CASE_MAX_SIZE, PLATE_WIDTH, value))
                {
                    throw new OutOfBoundsException($"Длина корпуса не может быть больше" +
                                                   $" {CASE_MAX_SIZE} или меньше {PLATE_WIDTH} мм.");
                }
                checkUpperValues(value, _upperFansDiameter, _upperFansCount);
                _length = value;
            }
        }

        /// <summary>
        /// Ширина корпуса
        /// </summary>
        public double Width
        {
            get => _width;
            set => _width = Validator.Validate(CASE_MAX_SIZE, ATX_POWER_SUPPLY_WIDTH, value) 
                ? value : throw new OutOfBoundsException($"Ширина корпуса не может быть больше" +
                                                         $" {CASE_MAX_SIZE} или меньше {ATX_POWER_SUPPLY_WIDTH} мм.");
        }
        
        /// <summary>
        /// Радиус передних вентиляторов
        /// </summary>
        public double FrontFansDiameter
        {
            get => _frontFansDiameter;
            set
            {
                if (!Validator.Validate(MAX_FANS_SIZE, MIN_FANS_SIZE, value))
                {
                    throw new OutOfBoundsException("Диаметр отверстий не может быть больше" +
                                                   $" {MAX_FANS_SIZE} или меньше {MIN_FANS_SIZE} мм.");
                }
                checkFrontValues(_height, value, _frontFansCount);
                _frontFansDiameter = value;
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
                if (!Validator.Validate(MAX_FANS_SIZE, MIN_FANS_SIZE, value))
                {
                    throw new OutOfBoundsException("Диаметр отверстий не может быть больше" +
                                                   $" {MAX_FANS_SIZE} или меньше {MIN_FANS_SIZE} мм.");
                }
                checkUpperValues(_length,value,_upperFansCount);
                _upperFansDiameter = value;
            }
        }

        private void checkUpperValues(double length,double upperFansDiameter,int upperFansCount)
        {
            if (length != default && upperFansDiameter != default)
            {
                var fansLength = upperFansDiameter * upperFansCount +
                                 (SPACE_BETWEEN_UPPER_FANS * upperFansCount - 1);
                if (!Validator.Validate(length, MIN_FANS_SIZE, fansLength))
                {
                    throw new SizeDependencyException("Отверстия под вентиляторы с заданным размером " +
                                                      "не могут быть умещены на корпусе с указанной длиной");
                }
            }
        }

        private void checkFrontValues(double height, double frontFansDiameter, int frontFansCount)
        {
            if (height != default && frontFansDiameter != default)
            {
                var fansLength = frontFansDiameter * frontFansCount +
                                 (SPACE_BETWEEN_FRONT_FANS * frontFansCount - 1);
                if (!Validator.Validate(height, MIN_FANS_SIZE, fansLength))
                {
                    throw new SizeDependencyException("Отверстия под вентиляторы с заданным размером " +
                                                      "не могут быть умещены на корпусе с указанной высотой");
                }
            }
        }

        /// <summary>
        /// Количество верхних вентиляторов
        /// </summary>
        public int UpperFansCount
        {
            get => _upperFansCount;
            set
            {
                _upperFansCount = value;
                checkUpperValues(_length, _upperFansDiameter, _upperFansCount);
            }
        }

        /// <summary>
        /// Количество передних вентиляторов
        /// </summary>
        public int FrontFansCount
        {
            get => _frontFansCount;
            set
            {
                _frontFansCount = value;
                checkFrontValues(_height,_frontFansDiameter,_frontFansCount);
            }
        }

        public MotherboardType MotherboardType { get; set; }
    }
}
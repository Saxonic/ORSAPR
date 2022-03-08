using ComputerCase.Exceptions;

namespace ComputerCase
{
    public class CaseParameters
    {
        private const int SPACE_BETWEEN_FRONT_FANS = 15;
        private const int SPACE_BETWEEN_UPPER_FANS = 5;
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
        private MotherboardType _motherboardType;

        public delegate void TryValueChangedContainer();
        public event TryValueChangedContainer TryValueChange;


        /// <summary>
        /// Высота корпуса
        /// </summary>
        public double Height
        {
            get => _height;
            set
            {
                OnValueTryChange();
                var minValue = MotherboardType == MotherboardType.ATX ? ATX_PLATE_HEIGHT : MICRO_ATX_PLATE_HEIGHT;
                if (!Validator.Validate(CASE_MAX_SIZE, minValue, value))
                {
                    throw new OutOfBoundsException($"Высота корпуса не может быть больше" +
                                                   $" {CASE_MAX_SIZE} или меньше {minValue} мм.");
                }
                CheckFrontValues(value,_frontFansDiameter,_frontFansCount);
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
                OnValueTryChange();
                if (!Validator.Validate(CASE_MAX_SIZE, PLATE_WIDTH, value))
                {
                    throw new OutOfBoundsException($"Длина корпуса не может быть больше" +
                                                   $" {CASE_MAX_SIZE} или меньше {PLATE_WIDTH} мм.");
                }
                CheckUpperValues(value, _upperFansDiameter, _upperFansCount);
                _length = value;
            }
        }

        /// <summary>
        /// Ширина корпуса
        /// </summary>
        public double Width
        {
            get => _width;
            set
            {
                OnValueTryChange();
                if (!Validator.Validate(CASE_MAX_SIZE, ATX_POWER_SUPPLY_WIDTH, value))
                {
                    throw new OutOfBoundsException($"Ширина корпуса не может быть больше" +
                                                   $" {CASE_MAX_SIZE} или меньше {ATX_POWER_SUPPLY_WIDTH} мм.");
                }
                _width = value;
            }
        }
        
        /// <summary>
        /// Радиус передних вентиляторов
        /// </summary>
        public double FrontFansDiameter
        {
            get => _frontFansDiameter;
            set
            {
                OnValueTryChange();
                if (!Validator.Validate(MAX_FANS_SIZE, MIN_FANS_SIZE, value))
                {
                    throw new OutOfBoundsException("Диаметр отверстий не может быть больше" +
                                                   $" {MAX_FANS_SIZE} или меньше {MIN_FANS_SIZE} мм.");
                }
                CheckFrontValues(_height, value, _frontFansCount);
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
                OnValueTryChange();
                if (!Validator.Validate(MAX_FANS_SIZE, MIN_FANS_SIZE, value))
                {
                    throw new OutOfBoundsException("Диаметр отверстий не может быть больше" +
                                                   $" {MAX_FANS_SIZE} или меньше {MIN_FANS_SIZE} мм.");
                }
                CheckUpperValues(_length,value,_upperFansCount);
                _upperFansDiameter = value;
            }
        }

        private void CheckUpperValues(double length,double upperFansDiameter,int upperFansCount)
        {
            if (length == default || upperFansDiameter == default) return;
            var fansLength = upperFansDiameter * upperFansCount +
                             (SPACE_BETWEEN_UPPER_FANS * upperFansCount - 1);
            if (!Validator.Validate(length, MIN_FANS_SIZE, fansLength))
            {
                throw new SizeDependencyException(Validator.LengthDependencyExceptionMessage);
            }
        }

        private void CheckFrontValues(double height, double frontFansDiameter, int frontFansCount)
        {
            if (height == default || frontFansDiameter == default) return;
            var fansLength = frontFansDiameter * frontFansCount +
                             (SPACE_BETWEEN_FRONT_FANS * frontFansCount - 1);
            if (!Validator.Validate(height, MIN_FANS_SIZE, fansLength))
            {
                throw new SizeDependencyException(Validator.HeightDependencyExceptionMessage);
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
                OnValueTryChange();
                CheckUpperValues(_length, _upperFansDiameter, value);
                _upperFansCount = value;
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
                OnValueTryChange();
                CheckFrontValues(_height,_frontFansDiameter,value);
                _frontFansCount = value;
            }
        }

        public MotherboardType MotherboardType 
        { 
            get=>_motherboardType;
            set
            {
                OnValueTryChange();
                _motherboardType = value;
            }
        }

        protected virtual void OnValueTryChange()
        {
            TryValueChange?.Invoke();
        }
    }
}
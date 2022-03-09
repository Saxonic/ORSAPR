using ComputerCase.Exceptions;

namespace ComputerCase
{
    public class CaseParameters
    {
        #region Constraints

        /// <summary>
        /// Расстояние между передними вентиляторами
        /// </summary>
        private const int SPACE_BETWEEN_FRONT_FANS = 15;
        
        /// <summary>
        /// Расстояние между верхними вентиляторами
        /// </summary>
        private const int SPACE_BETWEEN_UPPER_FANS = 5;
        
        /// <summary>
        /// Минимальная высота корпуса с ATX платой
        /// </summary>
        private const int ATX_PLATE_CASE_MIN_HEIGHT = 391;
        
        /// <summary>
        /// Минимальная высота корпуса с micro-ATX платой
        /// </summary>
        private const int MICRO_ATX_PLATE_CASE_MIN_HEIGHT = 330;
        
        /// <summary>
        /// Ширина блока питания. Определяет минимальнудю ширину корпуса
        /// </summary>
        private const int ATX_POWER_SUPPLY_WIDTH = 140;
        
        /// <summary>
        /// Ширина материнской платы. Определяет минимальную длину корпуса
        /// </summary>
        private const int PLATE_WIDTH = 244;
        
        /// <summary>
        /// Максимальный размер высоты, длины и ширины корпуса
        /// </summary>
        private const int CASE_MAX_SIZE = 500;
        
        /// <summary>
        /// Максимальный диаметр отверстий под вентиляторы
        /// </summary>
        private const int MAX_FANS_SIZE = 140;
        
        /// <summary>
        /// Минимальный размер отверстий под вентиляторы
        /// </summary>
        private const int MIN_FANS_SIZE = 40;

        #endregion

        #region PrivateFields

        /// <summary>
        /// Высота корпуса
        /// </summary>
        private double _height;
        
        /// <summary>
        /// Длина корпуса
        /// </summary>
        private double _length;
        
        /// <summary>
        /// Ширина корпуса
        /// </summary>
        private double _width;
        
        /// <summary>
        /// Диаметер передних вентиляторов
        /// </summary>
        private double _frontFansDiameter;
        
        /// <summary>
        /// Диаметр верхних вентиляторов
        /// </summary>
        private double _upperFansDiameter;
        
        /// <summary>
        /// Кол-во передних вентиляторов
        /// </summary>
        private int _frontFansCount;
        
        /// <summary>
        /// Кол-во верхних вентиляторов
        /// </summary>
        private int _upperFansCount;
        
        /// <summary>
        /// Тип материнской платы
        /// </summary>
        private MotherboardType _motherboardType;

        #endregion
        

        /// <summary>
        /// Делегат попытки события попытки изменения данных
        /// </summary>
        public delegate void TryValueChangedContainer();
        
        /// <summary>
        /// Событие попытки изменения данных
        /// </summary>
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
                var minValue = MotherboardType == MotherboardType.ATX ? 
                    ATX_PLATE_CASE_MIN_HEIGHT : MICRO_ATX_PLATE_CASE_MIN_HEIGHT;
                if (!Validator.Validate(CASE_MAX_SIZE, minValue, value))
                {
                    throw new OutOfBoundsException("Высота корпуса не может быть больше" +
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

        /// <summary>
        /// Проверка зависимых значений длины, диаметра верхних вентиляторов и их кол-ва
        /// </summary>
        /// <param name="length">Длина корпуса</param>
        /// <param name="upperFansDiameter">Диаметр отверстий под вентиляторы</param>
        /// <param name="upperFansCount">Кол-во вентиляторов</param>
        /// <exception cref="SizeDependencyException"></exception>
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

        /// <summary>
        /// Проверка зависимых значений высоты, диаметра передних вентиляторов и их кол-ва
        /// </summary>
        /// <param name="height">Высота корпуса</param>
        /// <param name="frontFansDiameter">диаметр передних вентиляторов</param>
        /// <param name="frontFansCount">Кол-во передних вентиляторов</param>
        /// <exception cref="SizeDependencyException"></exception>
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

        /// <summary>
        /// Тип материнской платы
        /// </summary>
        public MotherboardType MotherboardType 
        { 
            get=>_motherboardType;
            set
            {
                OnValueTryChange();
                _motherboardType = value;
            }
        }

        /// <summary>
        /// Инвок события попытки изменения данных
        /// </summary>
        protected virtual void OnValueTryChange()
        {
            TryValueChange?.Invoke();
        }
    }
}
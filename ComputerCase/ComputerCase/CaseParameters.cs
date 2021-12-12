namespace ComputerCase
{
    public class CaseParameters
    {
        public const int SPACE_BETWEEN_FRONT_FANS = 15;
        public const int SPACE_BETWEEN_UPPER_FANS = 15;
        private const int ATX_PLATE_HEIGHT = 305;
        private const int ATX_PLATE_WIDTH = 244;
        private const int MICRO_ATX_PLATE_HEIGHT = 244;
        private const int MICRO_ATX_PLATE_WIDTH = 244;
        private const int ATX_POWER_SUPPLY_HEIGHT = 86;
        private const int MAX_FRONT_FANS_NUMBER = 3;
        private const int MAX_UPPER_FANS_NUMBER = 2;

        private double _height;
        private double _length;
        private double _width;
        private double _frontFanRadius;
        private double _upperFanRadius;
        private int _upperFansNumber;
        private int _frontFansNumber;

        /// <summary>
        /// Высота корпуса
        /// </summary>
        public double Height
        {
            get => _height;
            set => _height = value;
        }

        /// <summary>
        /// Длина корпуса
        /// </summary>
        public double Length
        {
            get => _length;
            set => _length = value;
        }

        /// <summary>
        /// Ширина корпуса
        /// </summary>
        public double Width
        {
            get => _width;
            set => _width = value;
        }
        
        /// <summary>
        /// Радиус передних вентиляторов
        /// </summary>
        public double FrontFanRadius
        {
            get => _frontFanRadius;
            set => _frontFanRadius = value;
        }

        /// <summary>
        /// Радиус верхних вентиляторов
        /// </summary>
        public double UpperFanRadius
        {
            get => _upperFanRadius;
            set => _upperFanRadius = value;
        }

        /// <summary>
        /// Количество верхних вентиляторов
        /// </summary>
        public int UpperFansNumber
        {
            get => _upperFansNumber;
            set => _upperFansNumber = value;
        }

        /// <summary>
        /// Количество передних вентиляторов
        /// </summary>
        public int FrontFansNumber
        {
            get => _frontFansNumber;
            set => _frontFansNumber = value;
        }
    }
}
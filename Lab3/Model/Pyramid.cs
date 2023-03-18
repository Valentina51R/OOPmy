
namespace Model
{
    public class Pyramid : IFigureBase
    {
        /// <summary>
        /// Площадь.
        /// </summary>
        private double _square;

        /// <summary>
        /// Высота.
        /// </summary>
        private double _height;

        /// <summary>
        /// Площадь пирамиды.
        /// </summary>
        public double Square
        {
            get
            {
                return _square;
            }
            set
            {
                _square = IFigureBase.CheckNumber(value);
            }
        }

        /// <summary>
        /// Высота пирамиды.
        /// </summary>
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = IFigureBase.CheckNumber(value);
            }
        }

        /// <summary>
        /// Объём пирамиды.
        /// </summary>
        public double Volume
        {
            get
            {
                double valume = (1.0 / 3.0) * Square * Height;
                return valume;
            }
        }

        public Pyramid(double height, double square)
        {
            Height = height;
            Square = square;
        }

        public Pyramid()
        { }

    }
}

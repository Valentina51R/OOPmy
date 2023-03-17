
namespace Model
{
    public class Pyramid : FigureBase
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
        public double Squar
        {
            get
            {
                return _square;
            }
            set
            {
                _square = CheckNumber(value);
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
                _height = CheckNumber(value);
            }
        }

        /// <summary>
        /// Объём пирамиды.
        /// </summary>
        public override double Volume
        {
            get
            {
                double valume = (1.0 / 3.0) * Squar * Height;
                return valume;
            }
        }

    }
}

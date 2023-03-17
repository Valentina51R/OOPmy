
namespace Model
{
    public class Parallelepiped : FigureBase
    {
        /// <summary>
        /// Высота.
        /// </summary>
        private double _height;

        /// <summary>
        /// Ширина.
        /// </summary>
        private double _width;

        /// <summary>
        /// Длина.
        /// </summary>
        private double _length;

        /// <summary>
        /// Высота параллелепипеда.
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
        /// Ширина параллелепипеда.
        /// </summary>
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = CheckNumber(value);
            }
        }

        /// <summary>
        /// Длина параллелепипеда.
        /// </summary>
        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = CheckNumber(value);
            }
        }


        /// <summary>
        /// Объём параллелепипеда
        /// </summary>
        public override double Volume
        {
            get
            {
                return Height * Width * Length;
            }
        }
    }
}

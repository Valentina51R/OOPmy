
namespace Model
{
    public class Parallelepiped : IFigureBase
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
                _height = IFigureBase.CheckNumber(value);
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
                _width = IFigureBase.CheckNumber(value);
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
                _length = IFigureBase.CheckNumber(value);
            }
        }


        /// <summary>
        /// Объём параллелепипеда
        /// </summary>
        public double Volume
        {
            get
            {
                return Height * Width * Length;
            }
        }

        public Parallelepiped(double height, double width, double length)
        {
            Height = height;
            Width = width;
            Length = length;
        }

        public Parallelepiped()
        { }

    }
}

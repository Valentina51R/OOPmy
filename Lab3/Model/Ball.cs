
namespace Model
{
    public class Ball : IFigureBase
    {
        /// <summary>
        /// Радиус.
        /// </summary>
        private double _radius;

        /// <summary>
        /// Радиус шара.
        /// </summary>
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = IFigureBase.CheckNumber(value);
            }
        }


        /// <summary>
        /// Расчёт объёма шара
        /// </summary>
        /// <returns>valume.</returns>
        public double Volume
        {
            get
            {
                return (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
            }
        }

        public Ball(double radius)
        {
            Radius = radius;
        }

        public Ball()
        { }
    }
}

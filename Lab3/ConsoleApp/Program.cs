using Model;

namespace ConsoleApp
{
    /// <summary>
    /// Основная программа.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Основная программа.
        /// </summary>
        private static void Main()
        {
            Ball ball1 = new Ball();
            Pyramid pyramid1 = new Pyramid();
            Parallelepiped parallelepiped1 = new Parallelepiped();


            // TODO: Ограничение на ввод положительного числа.
            while (true)
            {
                try
                {
                    Console.Write("Введите радиус шара: ");
                    ball1.Radiuc = double.Parse(Console.ReadLine());
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }

            Console.WriteLine("Объём шара: " + ball1.Volume + "\n");


            Console.Write("Введите высоту пирамиды: ");
            pyramid1.Height = double.Parse(Console.ReadLine());


            Console.Write("Введите площадь основания пирамиды: ");
            pyramid1.Squar = double.Parse(Console.ReadLine());

            Console.WriteLine($"Объём пирамиды: {pyramid1.Volume}");

            Console.Write("Введите высоту параллелепипеда: ");
            parallelepiped1.Height = double.Parse(Console.ReadLine());

            Console.Write("Введите ширину параллелепипеда: ");
            parallelepiped1.Width = double.Parse(Console.ReadLine());

            Console.Write("Введите длину параллелепипеда: ");
            parallelepiped1.Length = double.Parse(Console.ReadLine());

            Console.WriteLine($"Объём пирамиды: {parallelepiped1.Volume}");

        }
    }
}

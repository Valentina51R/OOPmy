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

            AddFigure();

            // TODO: Ограничение на ввод положительного числа.
            //while (true)
            //{
            //    try
            //    {
            //        Console.Write("Введите радиус шара: ");
            //        double radius = double.Parse(Console.ReadLine());
            //        figure = new Ball(radius);
            //        break;
            //    }
            //    catch (ArgumentException ex)
            //    {
            //        Console.WriteLine($"{ex.Message}");
            //    }
            //}

            //Console.WriteLine("Объём шара: " + figure.Volume + "\n");
            //_ = Console.ReadKey();


            //while (true)
            //{
            //    try
            //    {
            //        Console.Write("Введите высоту пирамиды: ");
            //        double height = double.Parse(Console.ReadLine());
            //        Console.Write("Введите площадь основания пирамиды: ");
            //        double square = double.Parse(Console.ReadLine());
            //        figure = new Pyramid(height, square);
            //        break;
            //    }
            //    catch (ArgumentException ex)
            //    {
            //        Console.WriteLine($"{ex.Message}");
            //    }
            //}

            //Console.WriteLine($"Объём пирамиды: {figure.Volume}" + "\n");
            //_ = Console.ReadKey();

            //while (true)
            //{
            //    try
            //    {
            //        Console.Write("Введите высоту параллелепипеда: ");
            //        double height = double.Parse(Console.ReadLine());

            //        Console.Write("Введите ширину параллелепипеда: ");
            //        double width = double.Parse(Console.ReadLine());

            //        Console.Write("Введите длину параллелепипеда: ");
            //        double length = double.Parse(Console.ReadLine());
            //        figure = new Parallelepiped(height, width, length);
            //        break;
            //    }
            //    catch (ArgumentException ex)
            //    {
            //        Console.WriteLine($"{ex.Message}");
            //    }
            //}

            //Console.WriteLine($"Объём параллелепипеда: {figure.Volume}" + "\n");

        }

        private static void AddFigure()
        {
            IFigureBase figure = new Ball();

            Action actionStart = new Action(() =>
            {
                Console.Write($"1 - шар,\n" +
                    $"2 - пирамиды,\n3 - параллелепипед." +
                    $"\nРасчёт объёма фигуры:");

                int who = int.Parse(Console.ReadLine());

                switch (who)
                {
                    case 1:
                        {
                            figure = new Ball();
                            break;
                        }

                    case 2:
                        {
                            figure = new Pyramid();
                            break;
                        }
                    case 3:
                        {
                            figure = new Parallelepiped();
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException("Введите корректно." +
                                " \n1 - шар,\n 2 - пирамиды, \n 3 - параллелепипед.");
                            break;
                        }
                }
            });

            var actionBall = new List<(Action, string)>
            {
                (new Action(() =>
                {
                    Console.Write("Введите радиус шара: ");
                    Ball ball1 = (Ball)figure;
                    ball1.Radius = double.Parse(Console.ReadLine());

                    //bool result = double.TryParse(Console.ReadLine(),
                    //    out double ball1.Radius);
                    //if(result != true)
                    //{
                    //    throw new ArgumentException("Введите число!");
                    //}

                }), "шар"),
                (new Action(() =>
                {
                    Ball ball1 = (Ball)figure;
                    Console.WriteLine("Объём шара: " + ball1.Volume + "\n");
                    _ = Console.ReadKey();
                }), "шар")
            };

            var actionPyramid = new List<(Action, string)>
            {
                (new Action(() =>
                {
                    Pyramid pyramid = (Pyramid)figure;
                    Console.Write("Введите высоту пирамиды: ");
                    pyramid.Height = double.Parse(Console.ReadLine());

                }), "пирамида"),
                (new Action(() =>
                {
                    Pyramid pyramid = (Pyramid)figure;
                    Console.Write("Введите площадь основания пирамиды: ");
                    pyramid.Square = double.Parse(Console.ReadLine());

                }), "пирамида"),
                (new Action(() =>
                {

                    Console.WriteLine($"Объём пирамиды: {figure.Volume}" + "\n");
                    _ = Console.ReadKey();

                }), "пирамида")
            };

            var actionParallelepiped = new List<(Action, string)>
            {
                (new Action(() =>
                {
                    Parallelepiped parallelepiped = (Parallelepiped)figure;
                    Console.Write("Введите высоту параллелепипеда: ");
                    parallelepiped.Height = double.Parse(Console.ReadLine());
                }), "Высота параллелепипеда"),
                (new Action(() =>
                {
                    Parallelepiped parallelepiped = (Parallelepiped)figure;
                    Console.Write("Введите ширину параллелепипеда: ");
                    parallelepiped.Width = double.Parse(Console.ReadLine());
                }), "Ширина параллелепипеда"),
                (new Action(() =>
                {
                    Parallelepiped parallelepiped = (Parallelepiped)figure;
                    Console.Write("Введите длину параллелепипеда: ");
                    parallelepiped.Length = double.Parse(Console.ReadLine());
                }), "Длина параллелепипеда"),
                (new Action(() =>
                {
                    Console.WriteLine($"Объём параллелепипеда:" +
                        $" {figure.Volume}" + "\n");
                    _ = Console.ReadKey();

                }), "Параллелепипед")
            };

            // Выбор фигуры
            ActionHandler(actionStart, "Фигура");

            switch (figure)
            {
                case Ball:
                    {
                        foreach (var action in actionBall)
                        {
                            ActionHandler(action.Item1, action.Item2);
                        }
                        break;
                    }

                case Pyramid:
                    {
                        foreach (var action in actionPyramid)
                        {
                            ActionHandler(action.Item1, action.Item2);
                        }
                        break;
                    }
                case Parallelepiped:
                    {
                        foreach (var action in actionParallelepiped)
                        {
                            ActionHandler(action.Item1, action.Item2);
                        }
                        break;
                    }
                default:
                    break;
            }
        }


        private static void ActionHandler(Action action, string propertyName)
        {

            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (ArgumentException exception)
                {

                    Console.WriteLine($"Incorrect {propertyName}. " +
                            $"Error: {exception.Message}");

                }
            }
        }

    }
}

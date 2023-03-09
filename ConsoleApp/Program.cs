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
            Console.WriteLine("Каждый новый шаг выполняется по нажатию" +
                " любой клавиши клавиатуры.\nНажмите любую клавишу.");
            _ = Console.ReadKey();

            // а.Создание программно двух списков персон,
            // в каждом из которых будет по три человека.
            Console.WriteLine("\n\t\tСоздание программно списка" +
                " персон, состоящего из семи человек.");
            _ = Console.ReadKey();

            PersonList personlist = new PersonList();

            for (int i = 0; i < 7; i++)
            {
                personlist.Add(RandomPerson.GetRandomAdultOrChild());
            }

            // b. Вывод содержимое каждого списка на экран
            Console.WriteLine("\n\t\tВывод списков на экран.");
            _ = Console.ReadKey();

            // Печать исходного списка
            Console.WriteLine("Список:");
            ConsolePerson.Print(personlist);

            Console.WriteLine("\n\tОпределение" +
                " типа четвёртого человека в списке.\n");

            Person person = personlist.FindByIndex(3);


            switch (person)
            {
                case Adult adult:
                    {
                        Console.WriteLine("This is an adult!");
                        Console.WriteLine(adult.PersonalityType());
                        break;
                    }

                case Child child:
                    {
                        Console.WriteLine("It's a child!");
                        Console.WriteLine(child.Hobby());
                        break;
                    }
                default:
                    break;
            }
        }
    }
}

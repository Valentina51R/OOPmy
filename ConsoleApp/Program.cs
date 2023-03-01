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
            Console.WriteLine("\n\t\tСоздание программно двух списков" +
                " персон, в каждом из которых будет по три человека.");
            _ = Console.ReadKey();


            PersonList personlist1 = new PersonList();
            PersonList personlist2 = new PersonList();


            // Создание исходного списка 1
            personlist1.Add(RandomPerson.GetRandomPerson());
            personlist1.Add(RandomPerson.GetRandomPerson());
            personlist1.Add(RandomPerson.GetRandomPerson());

            // Создание исходного списка 2
            personlist2.Add(RandomPerson.GetRandomPerson());
            personlist2.Add(RandomPerson.GetRandomPerson());
            personlist2.Add(RandomPerson.GetRandomPerson());

            // b. Вывод содержимое каждого списка на экран
            Console.WriteLine("\n\t\tВывод списков на экран.");
            _ = Console.ReadKey();

            // Печать исходного списка 1
            Console.WriteLine("Список №1:");
            ConsolePerson.Print(personlist1);

            // Печать исходного списка 2
            Console.WriteLine("\nСписок №2:");
            ConsolePerson.Print(personlist2);

            // c. Добавление нового человека в список 1
            Console.WriteLine("\n\t\tДобавление человека в список №1.");
            _ = Console.ReadKey();
            personlist1.Add(ConsolePerson.InputPersonByConsole());

            // Печать списка 1
            Console.WriteLine("\nСписок №1 с добавлением:");
            ConsolePerson.Print(personlist1);

            // d.Скопируйте второго человека из первого списка
            // в конец второго списка.
            // Покажите, что один и тот же человек
            // находится в обоих списках.
            Console.WriteLine();
            Console.WriteLine("\n\t\tКопирование 2-ого человека из" +
                " первого списка в конец второго списка.");
            _ = Console.ReadKey();
            try
            {
                personlist2.Add(personlist1.FindByIndex(1));
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }

            Console.WriteLine("\nСписок №1:");
            ConsolePerson.Print(personlist1);

            Console.WriteLine("\nСписок №2:");
            ConsolePerson.Print(personlist2);

            // e.Удалите второго человека из первого списка. Покажите, что
            // удаление человека из первого списка
            // не привело к уничтожениютэтого же человека во втором списке.
            Console.WriteLine("\n\t\tУдаление второго человека" +
                " из первого списка.");
            _ = Console.ReadKey();
            try
            {
                personlist1.DeleteByIndex(1);
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }

            Console.WriteLine("\nСписок №1:");
            ConsolePerson.Print(personlist1);

            Console.WriteLine("\nСписок №2:");
            ConsolePerson.Print(personlist2);

            // f.Очистите второй список.
            Console.WriteLine("\n\t\tОчищение второго списка.");
            _ = Console.ReadKey();
            personlist2.DeleteAll();

            Console.WriteLine("\nСписок №1:");
            ConsolePerson.Print(personlist1);

            Console.WriteLine("\nСписок №2:");
            ConsolePerson.Print(personlist2);

            _ = Console.ReadKey();
        }
    }
}

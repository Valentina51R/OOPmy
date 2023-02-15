using Model;

namespace ConsoleApp
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Печать списка.
        /// </summary>
        /// <param name="people"> Список.</param>
        public static void Print(PersonList people)
        {
            int count = people.CountList();

            for (int i = 0; i < count; i++)
            {
                Person pers = people.FindByIndex(i);
                Console.WriteLine(pers.GetInfo());
            }
        }

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
            Print(personlist1);

            // Печать исходного списка 2
            Console.WriteLine("\nСписок №2:");
            Print(personlist2);

            // c. Добавление нового человека в список 1
            Console.WriteLine("\n\t\tДобавление человека в список №1.");
            _ = Console.ReadKey();

            Console.Write("Введите имя человека: ");
            string name = Person.CheckNameSurname(Console.ReadLine());

            Console.Write("Введите фамилию человека: ");
            string surname = Person.CheckNameSurname(Console.ReadLine());

            Console.Write("Введите возраст человека: ");
            ushort age;

            // Проверка на ввод числа.
            while (!ushort.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Введён некорректный возвраст," +
                                      " введите положительное число!");
            }

            Console.Write("Введите пол человека: ");
            Console.Write("Введите пол человека: ");
            Gender gender;

            while (true)
            {
                string gender1 = Console.ReadLine();
                if (gender1 == "ж" || gender1 == "w")
                {
                    gender = Gender.Female;
                    break;
                }
                else if (gender1 == "м" || gender1 == "m")
                {
                    gender = Gender.Male;
                    break;
                }
                else
                {
                    Console.WriteLine("Введён некорректный пол," +
                        " введите м или ж!");
                }
            }

            while (true)
            {
                try
                {
                    personlist1.AddPerson(name, surname, age, gender);
                }

                catch (ArgumentException ex)
                {
                    // TODO: Вынести в консоль
                    Console.WriteLine("Ошибка! " + ex.Message);
                }
            }

            // Печать списка 1
            Console.WriteLine("\nСписок №1 с добавлением:");
            Print(personlist1);

            // d.Скопируйте второго человека из первого списка
            // в конец второго списка.
            // Покажите, что один и тот же человек
            // находится в обоих списках.
            Console.WriteLine();
            Console.WriteLine("\n\t\tКопирование 2-ого человека из первого" +
                " списка в конец второго списка.");
            _ = Console.ReadKey();
            personlist2.Add(personlist1.FindByIndex(1));

            Console.WriteLine("\nСписок №1:");
            Print(personlist1);

            Console.WriteLine("\nСписок №2:");
            Print(personlist2);

            // e.Удалите второго человека из первого списка. Покажите, что
            // удаление человека из первого списка не привело к уничтожению
            // этого же человека во втором списке.
            Console.WriteLine("\n\t\tУдаление второго человека" +
                " из первого списка.");
            _ = Console.ReadKey();
            personlist1.DeleteByIndex(1);

            Console.WriteLine("\nСписок №1:");
            Print(personlist1);

            Console.WriteLine("\nСписок №2:");
            Print(personlist2);

            // f.Очистите второй список.
            Console.WriteLine("\n\t\tОчищение второго списка.");
            _ = Console.ReadKey();
            personlist2.DeleteAll();

            Console.WriteLine("\nСписок №1:");
            Print(personlist1);

            Console.WriteLine("\nСписок №2:");
            Print(personlist2);

            _ = Console.ReadKey();
        }
    }
}

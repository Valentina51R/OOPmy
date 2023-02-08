using Model;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConsoleApp
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Каждый новый шаг выполняется по нажатию" +
                " любой клавиши клавиатуры.\nНажмите любую клавишу.");
            Console.ReadKey();
            // а.Создание программно двух списков персон,
            // в каждом из которых будет по три человека.
            Console.WriteLine("\n\t\tСоздание программно двух списков" +
                " персон, в каждом из которых будет по три человека.");
            Console.ReadKey();

            List<Person> people1 = new List<Person>();
            List<Person> people2 = new List<Person>();

            PersonList prlist = new PersonList();

            // Создание исходного списка 1
            people1.Add(new Person("Иван", "Иванов", 28, Gender.Male));
            people1.Add(new Person("Пётр", "Петров", 35, Gender.Male));
            people1.Add(new Person("Василий", "Вавильев", 15, Gender.Male));

            // Создание исходного списка 2
            people2.Add(new Person("Ирина", "Ирисова", 28, Gender.Female));
            people2.Add(new Person("Анна", "Ананасова", 29, Gender.Female));
            people2.Add(new Person("Ольга", "Овечкина", 89, Gender.Female));


            // b. Вывод содержимое каждого списка на экран
            Console.WriteLine("\n\t\tВывод списков на экран.");
            Console.ReadKey();

            // Печать исходного списка 1
            Console.WriteLine("Список №1:");
            prlist.Print(people1);

            // Печать исходного списка 2
            Console.WriteLine("\nСписок №2:");
            prlist.Print(people2);

            // c. Добавление нового человека в список 1
            Console.WriteLine("\n\t\tДобавление человека в список №1.");
            Console.ReadKey();
            prlist.AddPerson(people1);
            /*
            Person person = new Person("Ivanov", "Ivanov", 20, Gender.Male);
            people1.Add(person.GetRandomPerson());
            */
            // Печать списка 1
            Console.WriteLine("\nСписок №1 с добавлением:");
            prlist.Print(people1);

            // d.Скопируйте второго человека из первого списка
            // в конец второго списка.
            // Покажите, что один и тот же человек
            // находится в обоих списках.
            Console.WriteLine();
            Console.WriteLine("\n\t\tКопирование 2-ого человека из первого" +
                " списка в конец второго списка.");
            Console.ReadKey();
            people2.Add(prlist.FindByIndex(people1, 1));

            Console.WriteLine("\nСписок №1:");
            prlist.Print(people1);

            Console.WriteLine("\nСписок №2:");
            prlist.Print(people2);

            // e.Удалите второго человека из первого списка. Покажите, что
            // удаление человека из первого списка не привело к уничтожению
            // этого же человека во втором списке.
            Console.WriteLine("\n\t\tУдаление второго человека" +
                " из первого списка.");
            Console.ReadKey();
            prlist.DeleteByIndex(people1, 1);

            Console.WriteLine("\nСписок №1:");
            prlist.Print(people1);

            Console.WriteLine("\nСписок №2:");
            prlist.Print(people2);

            // f.Очистите второй список.
            Console.WriteLine("\n\t\tОчищение второго списка.");
            Console.ReadKey();
            prlist.DeleteAll(people2);

            Console.WriteLine("\nСписок №1:");
            prlist.Print(people1);

            Console.WriteLine("\nСписок №2:");
            prlist.Print(people2);

            Console.ReadKey();
        }
    }
}
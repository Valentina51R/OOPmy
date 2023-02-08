using Model;
using System;

namespace ConsoleApp
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            
            // Создание двух списков.
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

            // Печать исходного списка 1
            Console.WriteLine("Список №1:");
            prlist.Print(people1);

            // Печать исходного списка 2
            Console.WriteLine("\nСписок №2:");
            prlist.Print(people2);


            // Добавление нового человека в список 1
            Console.WriteLine("\nДобавление человека в список №1:");
            prlist.AddPerson(people1);

            // Печать списка 1
            Console.WriteLine("Список №1 с добавлением:");
            prlist.Print(people1);

            Console.ReadKey();
        }
    }
}
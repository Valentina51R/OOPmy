using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    public class PersonList
    {
        /// <summary>
        /// Добавление элемента.
        /// </summary>
        /// <param name="people"></param>
        public void AddPerson(List<Person> people)
        {
            Console.Write("Введите имя человека: ");
            string name;
            // Только буквы
            Regex regex = new Regex(@"[а-я,А-Я,A-z,a-z]+\b");

            while (true)
            {
                name = Console.ReadLine();
                while (!regex.IsMatch(name))
                {
                    Console.WriteLine("Не удалось распознать имя" +
                                       ", введите снова!");
                }

                break;
            }


            Console.Write("Введите фамилию человека: ");
            string surname;
            while (true)
            {
                surname = Console.ReadLine();
                while (!regex.IsMatch(surname))
                {
                    Console.WriteLine("Не удалось распознать фамилию" +
                                       ", введите снова!");
                }

                break;
            }

            Console.Write("Введите возраст человека: ");
            ushort age;

            // Равносильно "пока не true"
            while (!ushort.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Введён некорректный возвраст, введите число!");
            }

            Console.Write("Введите пол человека: ");
            Gender gender;

            while (true)
            {
                string gender1 = Console.ReadLine();
                if (gender1 == "ж")
                {
                    gender = Gender.Female;
                    break;
                }
                else if (gender1 == "м")
                {
                    gender = Gender.Male;
                    break;
                }
                else
                {
                    Console.WriteLine("Введён некорректный пол, введите м или ж!");
                }
            }


            while (true)
            {
                try
                {
                    people.Add(new Person(name, surname, age, gender));
                    return;
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка! " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Удаление всего списка.
        /// </summary>
        /// <param name="people"></param>
        public void DeleteAll(List<Person> people)
        {
            people.Clear();
        }

        /// <summary>
        /// Удалять элементы по индексу.
        /// </summary>
        /// <param name="people"></param>
        /// <param name="index"></param>
        public void DeleteByIndex(List<Person> people, int index)
        {
            people.RemoveAt(index);
        }

        /// <summary>
        /// Удалить выбранный элемент списка.
        /// По фамилии.
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public int DeleteOnes(List<Person> people)
        {
            Console.Write("Удаление человека из списка: ");
            Console.Write("Введите фамилию человека: ");
            string surname = Console.ReadLine();

            // Удаляет элементы из списка по условию
            // и возвращает кол-во удалений.
            int count = people.RemoveAll(s => s.Surname == surname);
            return count;
        }

        /// <summary>
        /// Искать элемент по указанному индексу.
        /// </summary>
        /// <param name="people"></param>
        /// <param name="index"></param>
        public void FindByIndex(List<Person> people, int index)
        {
            int countIndex = people.Count - 1;

            if (countIndex < index)
            {
                Console.WriteLine("Элемента с таким индексам нет в списке." +
                    $"Введите индекс от 0 до {countIndex}.");
            }
            else
            {
                Console.WriteLine($"Элемент с индексом {index}: ");
                Console.WriteLine(people[index].GetInfo());
            }
        }

        /// <summary>
        /// Вернуть индекс элемента при
        /// наличии его в списке.
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public int FindIndex(List<Person> people)
        {
            Console.Write("Удаление человека из списка: ");
            Console.Write("Введите фамилию человека: ");
            string surname = Console.ReadLine();

            int index = people.FindIndex(s => s.Surname == surname);
            return index;
        }

        /// <summary>
        /// Колличество элементов всписке.
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public int ListCount(List<Person> people)
        {
            int count = people.Count;
            return count;
        }

        public void Print(List<Person> people)
        {
            foreach (Person p in people)
            {
                Console.WriteLine(p.GetInfo());
            }
        }
    }
}

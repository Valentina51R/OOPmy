using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Model
{
    public class PersonList
    {
        /// <summary>
        /// Проверка ввода имени и фамилии.
        /// Замена регистра первой буквы.
        /// </summary>
        /// <returns></returns>
        public string NameSurname()
        {
            // Только буквы
            Regex regex = new Regex(@"[а-я,А-Я,A-z,a-z]+[-][а-я,А-Я,A-z,a-z]+\b|[а-я,А-Я,A-z,a-z]+\b");

            // TODO: исключить поторение кода.
            while (true)
            {
                string surnameOrName = Console.ReadLine();

                while (!regex.IsMatch(surnameOrName))
                {
                    Console.WriteLine("Не удалось распознать имя/фамилию" +
                                       ", введите снова!");
                }

                //TODO: заглавные буквы и во второй части двйной фамилии
                surnameOrName = surnameOrName[0].ToString().ToUpper() + surnameOrName.Substring(1);

                Regex regex1 = new Regex(@"[-]");
                if (regex1.IsMatch(surnameOrName))
                {
                    string[] words = surnameOrName.Split(new char[] { '-' });
                    string word1 = words[0];
                    string word2 = words[1];
                    word1 = word1[0].ToString().ToUpper() + word1.Substring(1);
                    word2 = word2[0].ToString().ToUpper() + word2.Substring(1);
                    surnameOrName = word1 + "-" + word2;
                }

                return surnameOrName;
                break;
            }

        }

        /// <summary>
        /// Добавление элемента.
        /// </summary>
        /// <param name="people"></param>
        public void AddPerson(List<Person> people)
        {
            
            Console.Write("Введите имя человека: ");
            string name = NameSurname();
            
            Console.Write("Введите фамилию человека: ");
            string surname = NameSurname();
            
            Console.Write("Введите возраст человека: ");
            ushort age;

            // Равносильно "пока не true"
            // Проверка на ввод числа.
            while (!ushort.TryParse(Console.ReadLine(), out age))
            {
                 Console.WriteLine("Введён некорректный возвраст," +
                                       " введите положительное число!");   
            }

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
                    people.Add(new Person(name, surname, age, gender));
                    return;
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка! " + ex.Message);
                }
            }

            // Чтобы не повторялосась одна и та же функция в Person и PersonList
            /*
            Person personNew = Person.GetRandomPerson();
            people.Add(personNew.AddPersonInPerson());
            return;
            */
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
            // Проверка индекса
            people.RemoveAt(index);
        }

        // TODO: этот метод не используется в программе
        /// <summary>
        /// Удалить выбранный элемент списка.
        /// По фамилии.
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public int DeleteBySurname(List<Person> people)
        {
            Console.Write("Удаление человека из списка.");
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
        public Person FindByIndex(List<Person> people, int index)
        {
            int countIndex = people.Count - 1;

            if (countIndex < index)
            {
                Console.WriteLine("Элемента с таким индексам нет в списке." +
                    $"Введите индекс от 0 до {countIndex}.");
                return people[countIndex];
            }
            else
            {
                //Console.WriteLine($"Элемент с индексом {index}: ");
                //Console.WriteLine(people[index].GetInfo());
                return people[index];
            }
        }

        // TODO: этот метод не используется в программе
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

        // TODO: этот метод не используется в программе
        /// <summary>
        /// Колличество элементов в списке.
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public int ListCount(List<Person> people)
        {
            int count = people.Count;
            return count;
        }

        /// <summary>
        /// Печать списка.
        /// </summary>
        /// <param name="people"> Список.</param>
        public void Print(List<Person> people)
        {
            foreach (Person p in people)
            {
                Console.WriteLine(p.GetInfo());
            }
        }
    }
}

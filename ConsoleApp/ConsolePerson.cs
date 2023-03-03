using Model;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    /// <summary>
    /// Класс для добавления и печати
    /// персоны через консоль.
    /// </summary>
    public static class ConsolePerson
    {
        /// <summary>
        /// Печать списка.
        /// </summary>
        /// <param name="people"> Список.</param>
        public static void Print(PersonList people)
        {
            int count = people.CountElementsList();

            for (int i = 0; i < count; i++)
            {
                Person pers = people.FindByIndex(i);
                Console.WriteLine($"\nPerson №{i + 1}:");
                Console.WriteLine(pers.GetInfo());
            }
        }

        /// <summary>
        /// Метод проверяет введёные пользовелелем слова.
        /// Можно вводить буквы и тире.
        /// </summary>
        /// <param name="word"></param>
        /// <returns>слово.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string CheckNames(string word)
        {
            Regex wordsAndHyphens = new Regex(@"^[A-z,А-я,-]+$");

            if (!wordsAndHyphens.IsMatch(word))
            {
                throw new ArgumentException("Не удалось распознать" +
                    " имя/фамилию, введите ещё раз!" +
                    "\n(разрешено вводить только буквы и дефис)");
            }
            else
            {
                return word;
            }
        }

        /// <summary>
        /// Добавление персоны через консоль.
        /// </summary>
        /// <returns> Новая персона.</returns>
        public static Person InputPersonByConsole()
        {
            Person newperson = new Person();

            var actionList = new List<(Action, string)>
            {
                (new Action(() =>
                {
                    Console.Write($"\nВведите имя человека: ");
                    string name = CheckNames(Console.ReadLine());
                    newperson.Name = Person.CheckNameSurname(name);
                }), "name"),
                (new Action(() =>
                {
                    Console.Write($"Введите фамилию человека: ");
                    string surname = CheckNames(Console.ReadLine());
                    newperson.Surname = Person.CheckNameSurname(surname);
                }), "surname"),
                (new Action(() =>
                {
                    Console.Write($"Введите возраст человека:");
                    bool result = ushort.TryParse(Console.ReadLine(),
                        out ushort age);
                    if(result != true)
                    {
                        throw new ArgumentException("Возраст должен быть" +
                            " положительным, введите ещё раз!");
                    }
                    newperson.Age = age;
                }), "age"),
                (new Action(() =>
                {
                    Console.Write($"Введите пол человека:");
                    string gender1 = Console.ReadLine();
                    if (gender1 == "ж" || gender1 == "w")
                    {
                        newperson.Gender = Gender.Female;
                    }
                    else if (gender1 == "м" || gender1 == "m")
                    {
                        newperson.Gender = Gender.Male;
                    }
                    else
                    {
                        throw new ArgumentException("Введён некорректный" +
                            " пол, введите м(m) или ж(w)!");
                    }
                }), "gender")
            };

            foreach (var action in actionList)
            {
                ActionHandler(action.Item1, action.Item2);
            }

            return newperson;
        }

        /// <summary>
        /// Получение значений введеных ползователем.
        /// Задание параметров.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="propertyName"></param>
        private static void ActionHandler(Action action, string propertyName)
        {

            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception exception)
                {
                    if (exception.GetType() == typeof(ArgumentException)
                        || exception.GetType() == typeof(FormatException))
                    {
                        Console.WriteLine($"Incorrect {propertyName}. " +
                            $"Error: {exception.Message}");
                    }
                    else
                    {
                        throw exception;
                    }
                }
            }
        }
    }
}

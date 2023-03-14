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
                switch (people.FindByIndex(i))
                {
                    case Adult adult:
                        {
                            Console.WriteLine($"\nPerson №{i + 1}:");
                            Console.WriteLine(adult.GetInfo());
                            break;
                        }

                    case Child child:
                        {
                            Console.WriteLine($"\nPerson №{i + 1}:");
                            Console.WriteLine(child.GetInfo());
                            break;
                        }
                    default:
                        break;
                }
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
        public static PersonBase InputPersonByConsole()
        {

            // TODO: дать пользователю выбор кого вводить ребёнка или взрослого

            PersonBase newperson = new Adult();

            Action actionStart = new Action(() =>
            {
                Console.Write($"Если хотите ввести взрослого напишите - 1, " +
                                  $"если ребёнка - 2: ");
                // По умолчанию - Взрослый
                int who = int.Parse(Console.ReadLine());

                switch (who)
                {
                    case 1:
                        {
                            newperson = new Adult();
                            break;
                        }

                    case 2:
                        {
                            newperson = new Child();
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException("Введите для взрослого - 1, для ребёнка - 2: ");
                            break;
                        }
                }
            });


            var actionList = new List<(Action, string)>
            {
                (new Action(() =>
                {
                    Console.Write($"\nВведите имя человека: ");
                    string name = CheckNames(Console.ReadLine());
                    newperson.Name = PersonBase.CheckNameSurname(name);
                }), "name"),
                (new Action(() =>
                {
                    Console.Write($"Введите фамилию человека: ");
                    string surname = CheckNames(Console.ReadLine());
                    newperson.Surname = PersonBase.CheckNameSurname(surname);
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

            var actionlistAdult = new List<(Action, string)>
            {
                (new Action(() =>
                {
                    Console.Write($"Введите номер паспорта (9 цифр):");
                    bool result = uint.TryParse(Console.ReadLine(),
                        out uint passport);
                    Adult newpersonAdult = (Adult)newperson;
                    if(result != true)
                    {
                        throw new ArgumentException("Номер паспорта введён некорректно," +
                            " вводите только цифры!");
                    }
                    newpersonAdult.Рassport = passport;
                }), "passport"),
                (new Action(() =>
                {
                    Adult newpersonAdult = (Adult)newperson;
                    Console.Write("Введите место работы: ");
                    newpersonAdult.Job = Console.ReadLine();
                }), "job"),
                (new Action(() =>
                {
                    Adult newpersonAdult = (Adult)newperson;
                    Console.Write($"Семейное положение " +
                        $"(0 - одинок, 1 - состоит в браке): ");
                    ushort maritalstatus1 = ushort.Parse(Console.ReadLine());
                    switch (maritalstatus1)
                    {
                        case 1:
                            {
                                newpersonAdult.MaritalStatus = MaritalStatus.Married;
                                Console.WriteLine("Информация о партнёре поднимается из архива автоматически.");
                                _ = Console.ReadKey();
                                if (newpersonAdult.Gender == Gender.Male)
                                {
                                    newpersonAdult.Partner = RandomPerson.GetRandomAdult
                                    (MaritalStatus.Married, newpersonAdult, "wemen");
                                }
                                else
                                {
                                    newpersonAdult.Partner = RandomPerson.GetRandomAdult
                                    (MaritalStatus.Married, newpersonAdult, "men");
                                }
                                break;
                            }
                        case 0:
                            {
                                newpersonAdult.MaritalStatus = MaritalStatus.Single;
                                break;
                            }
                        default:
                            {
                                throw new ArgumentException
                                ("Введите 1 - в браке, 0 - одинок: ");
                                break;
                            }
                    }
                }), "maritalstatus")
            };

            var actionlistChild = new List<(Action, string)>
            {
                (new Action(() =>
                {
                    Child newpersonChild = (Child)newperson;
                    Console.Write("У ребёнка есть информация о матери?" +
                        " (1 - есть (будет поднята из архива), 0 - нет информации):");
                    ushort haveOrNot = ushort.Parse(Console.ReadLine());
                    switch (haveOrNot)
                    {
                        case 1:
                            {
                                newpersonChild.Mother = RandomPerson.GetRandomAdult
                                (MaritalStatus.Married, newpersonChild.Father, "wemen");
                                break;
                            }
                        case 0:
                            {
                                break;
                            }
                        default:
                            {
                                throw new ArgumentException
                                ("Введите 1 - есть есть информация о матери" +
                                ", 0 - нет информации.");
                                break;
                            }
                    }
                }), "Mother"),
                (new Action(() =>
                {
                    Child newpersonChild = (Child)newperson;
                    Console.Write("У ребёнка есть информация об отце?" +
                        " (1 - есть (будет поднята из архива), 0 - нет информации):");
                    ushort  haveOrNot = ushort.Parse(Console.ReadLine());
                    switch (haveOrNot)
                    {
                        case 1:
                            {
                                newpersonChild.Father = RandomPerson.GetRandomAdult
                                (MaritalStatus.Married, newpersonChild.Mother, "men");
                                break;
                            }
                        case 0:
                            {
                                break;
                            }
                        default:
                            {
                                throw new ArgumentException
                                ("Введите 1 - есть информация об отце," +
                                " 0 - нет информации.");
                                break;
                            }
                    }
                }), "Father"),
                (new Action(() =>
                {
                    Child newpersonChild = (Child)newperson;
                    Console.Write($"Ребёнок посещает в школу/садик? (1 - да, 0 - нет)");
                    switch (ushort.Parse(Console.ReadLine()))
                    {
                        case 1:
                            {
                                if (newpersonChild.Age < 8)
                                {
                                    Console.Write("Введите наименование детского сада: ");
                                    newpersonChild.Institution = "Детский сад \"" + Console.ReadLine() + "\"";
                                }
                                else
                                {
                                    Console.Write("Введите наименование школы: ");
                                    newpersonChild.Institution = "Школа \"" + Console.ReadLine() + "\"";
                                }
                                break;
                            }
                        case 0:
                            {
                                break;
                            }
                        default:
                            {
                                throw new ArgumentException
                                ("Введите 1 - посещает школу/сад, 0 - нет.");
                                break;
                            }
                    }
                }), "Institution")

            };

            // Выбор взрослого или ребёнка
            ActionHandler(actionStart, "Adult or Child");

            // Заполнение персоны
            foreach (var action in actionList)
            {
                ActionHandler(action.Item1, action.Item2);
            }

            // Заполнение взрослого или ребёнка
            switch (newperson)
            {
                case Adult:
                    {
                        foreach (var action in actionlistAdult)
                        {
                            ActionHandler(action.Item1, action.Item2);
                        }
                        break;
                    }

                case Child:
                    {
                        foreach (var action in actionlistChild)
                        {
                            ActionHandler(action.Item1, action.Item2);
                        }
                        break;
                    }
                default:
                    break;
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

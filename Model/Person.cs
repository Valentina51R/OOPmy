using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Класс персоны.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Имя.
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст.
        /// </summary>
        private int _age;

        /// <summary>
        /// Пол.
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Задание имени.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = ConvertToRightRegister
                    (CheckString(value, nameof(Name)));
                if (_surname != null)
                {
                    CheckLanguage(_name, _surname);
                }
            }
        }

        /// <summary>
        /// Задание фамилии.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = ConvertToRightRegister
                    (CheckString(value, nameof(Surname)));
                if (_name != null)
                {
                    CheckLanguage(_name, _surname);
                }
            }
        }

        /// <summary>
        /// Задание возраста.
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                //TODO: duplication
                if (value > 150 || value == 0)
                {
                    //TODO: duplication
                    throw new ArgumentException($"Введён некорректный возвраст, " +
                        $"введите возраст от 1 до 150 лет!");
                }
                else
                {
                    _age = value;
                }
            }
        }

        /// <summary>
        /// Задание гендера.
        /// </summary>
        public Gender Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }

        }

        /// <summary>
        /// Проверка на пустую строку.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="propertiname"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        private string CheckString(string value, string propertiname)
        {
            if (value == null)
            {
                throw new System.ArgumentNullException($"{propertiname} is not be null!");
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new System.ArgumentException($"{propertiname} is not be emptu!");
            }
            return value;
        }


        /// <summary>
        /// Метод возвращает информацию о человеке в виде строки.
        /// </summary>
        /// <returns>Информацию о человеке в воиде строки.</returns>
        public string GetInfo()
        {
            return $"Perconname: {_name}, Sername: {_surname}," +
                $" Age: {_age}, Gender: {_gender}";
        }

        /// <summary>
        /// Конструктор 1.
        /// </summary>
        public Person()
        { }

        /// <summary>
        /// Конструктор 2.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        public Person(string name, string surname, int age, Gender gender)
        {
            _name = name;
            _surname = surname;
            _age = age;
            _gender = gender;
        }

        /// <summary>
        /// Проверка на ввод имени или фамилии на одном языке.
        /// Возможность ввода двойного имени и фамилии.
        /// </summary>
        /// <param name="nameOrSurname"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public static string CheckNameSurname(string nameOrSurname)
        {
            string regex = @"(^[А-я]+(-[А-я])?[А-я]*$)|(^[A-z]+(-[A-z])?[A-z]*$)";
            Regex nameLanguage = new Regex(regex);

            if (!nameLanguage.IsMatch(nameOrSurname))
            {
                throw new FormatException("Введёное слово не распознано." +
                    " Введите еще раз!");
            }
            return nameOrSurname;
        }

        /// <summary>
        /// Преобразование регистра первой буквы.
        /// </summary>
        /// <returns></returns>
        public static string ConvertToRightRegister(string surnameOrName)
        {
            surnameOrName = surnameOrName[0].ToString().ToUpper()
                        + surnameOrName.Substring(1);

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
        }

        /// <summary>
        /// Сравнение языка имени и фамилии.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <exception cref="ArgumentException"></exception>
        public void CheckLanguage(string name, string surname)
        {
            int nameLang = DefineLanguage(name);
            int surnameLang = DefineLanguage(surname);
            if (nameLang != surnameLang)
            {
                throw new ArgumentException("Язык имени и фамилии должен совпадать.");
            }
        }

        //TODO: enumeration
        /// <summary>
        /// Проверка на язык.
        /// 0 - английский.
        /// 1 - русский.
        /// 2 - ошибка.
        /// </summary>
        /// //TODO: RSDN
        /// <param name="str"></param>
        /// <returns> 1, 2 или 3.</returns>
        public static int DefineLanguage(string str)
        {
            Regex latin = new Regex(@"[a-zA-Z]");
            Regex cyrillic = new Regex(@"[а-яА-Я]");

            if (latin.IsMatch(str))
            {
                return 0;
            }
            else if (cyrillic.IsMatch(str))
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}

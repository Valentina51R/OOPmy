using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Класс персоны.
    /// </summary>
    public abstract class PersonBase
    {
        /// <summary>
        /// Имя.
        /// </summary>
        protected string _name;

        /// <summary>
        /// Фамилия.
        /// </summary>
        protected string _surname;

        /// <summary>
        /// Возраст.
        /// </summary>
        protected int _age;

        /// <summary>
        /// Пол.
        /// </summary>
        protected Gender _gender;

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
        public abstract int Age { get; set; }


        /// <summary>
        /// Задание гендера.
        /// </summary>
        public Gender Gender { get; set; }


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
                throw new System.ArgumentNullException($"{propertiname} " +
                    $"is not be null!");
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new System.ArgumentException($"{propertiname} " +
                    $"is not be emptu!");
            }
            return value;
        }


        /// <summary>
        /// Метод возвращает информацию о человеке в виде строки.
        /// Это абстрактный метoд, доступен для переопределения.
        /// </summary>
        /// <returns>Информацию о человеке в виде строки.</returns>
        public virtual string GetInfo()
        {
            return $"Name: {Name} {Surname}," +
               $" Age: {Age}, Gender: {Gender}, ";
        }


        /// <summary>
        /// Конструктор 1.
        /// </summary>
        public PersonBase()
        { }

        /// <summary>
        /// Конструктор 2.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        public PersonBase(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
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
            string doubleNameSurname = @"(^[А-я]+(-[А-я])?[А-я]*$)" +
                "|(^[A-z]+(-[A-z])?[A-z]*$)";
            Regex nameLanguage = new Regex(doubleNameSurname);

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
        private static string ConvertToRightRegister(string surnameOrName)
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
        /// Сравнения языка имени и фамилии.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <exception cref="ArgumentException"></exception>
        private void CheckLanguage(string name, string surname)
        {
            Languege nameLang = DefineLanguage(name);
            Languege surnameLang = DefineLanguage(surname);
            if (nameLang != surnameLang)
            {
                throw new ArgumentException("Язык имени и фамилии" +
                    " должен совпадать.");
            }
        }

        /// <summary>
        /// Проверка на язык.
        /// </summary>
        /// <param name="str"></param>
        /// <returns> Languege.</returns>
        private Languege DefineLanguage(string word)
        {
            Regex latin = new Regex(@"[a-zA-Z]");
            Regex cyrillic = new Regex(@"[а-яА-Я]");

            if (latin.IsMatch(word))
            {
                return Languege.Latin;
            }
            else if (cyrillic.IsMatch(word))
            {
                return Languege.Сyrillic;
            }
            else
            {
                throw new ArgumentException("Язык не распознан.\n" +
                    "Разрешено вводить только символы кирицицы и латиницы.");
            }
        }
    }
}

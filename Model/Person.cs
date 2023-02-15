
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
                _name = CheckString(value, nameof(Name));
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
                _surname = CheckString(value, nameof(Surname));
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
                if (value < 0)
                {
                    // TODO: вынести в консоль
                    throw new Exception($"Введён некорректный возвраст, " +
                        $"введите положительное число!");
                }
            }
        }

        /// <summary>
        /// Задание гендера.
        /// </summary>
        public Gender Gender { get; set; }

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
        /// Метод для ловли ошибок.
        /// </summary>
        /// <param name="name"> имя.</param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <exception cref="System.ArgumentException"></exception>
        public Person(string name, string surname, int age, Gender gender)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("Name is not be null!");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new System.ArgumentException("Name is not be emptu!");
            }

            _name = name;
            _surname = surname;
            _age = age;
            _gender = gender;
        }


        /// <summary>
        /// Проверка ввода имени и фамилии.
        /// Замена регистра первой буквы.
        /// </summary>
        /// <returns></returns>
        public static string CheckNameSurname(string surnameOrName)
        {
            // Только буквы
            Regex regex = new Regex(@"[а-я,А-Я,A-z,a-z]+[-]
                   [а-я,А-Я,A-z,a-z]+\b|[а-я,А-Я,A-z,a-z]+\b");

            while (true)
            {

                while (!regex.IsMatch(surnameOrName))
                {
                    // TODO: вынести в консоль
                    throw new Exception("Не удалось распознать имя/фамилию");
                    // Console.WriteLine("Не удалось распознать имя/фамилию" +
                    //                    ", введите снова!");
                }
                break;
            }

            //TODO: заглавные буквы и во второй части двйной фамилии
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
    }
}

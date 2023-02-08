using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Model
{
    /// <summary>
    /// Класс персоны.
    /// </summary>
    public class Person
    {
        public string GetName()
        {
            return _name;
        }

        private string _name;
        private string _surname;
        private int _age;
        private Gender _gender;

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

        public int Age { get; set; }

        public Gender Gender { get; set; }

        private string CheckString(string value, string propertiname)
        {
            if (value == null)
            {
                throw new System.ArgumentNullException($"{propertiname} is not be null!");
            }
            if (value == string.Empty)
            {
                throw new System.ArgumentException($"{propertiname} is not be emptu!");
            }
            return value;
        }


        /// <summary>
        /// Метод возвращает информацию о человеке в воиде строки.
        /// </summary>
        /// <returns>Информацию о человеке в воиде строки.</returns>
        public string GetInfo()
        {
            return $"Perconname: {_name}, Sername: {_surname}," +
                $" Age: {_age}, Gender: {_gender}";
        }

        /// <summary>
        /// Увеличиваем возвраст человека.
        /// </summary>
        public void CelebrateHappyBirthday()
        {
            _age++;
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
        /// Вывод персоны на экран.
        /// </summary>
        /// <param name="people"> Список.</param>
        public void PrintPerson()
        {
            Console.WriteLine(GetInfo());
        }

        /// <summary>
        /// Создание рандомного человека
        /// </summary>
        /// <returns></returns>
        public static Person GetRandomPerson()
        {
            string[] menName = { "Иван", "Пётр", "Игорь", "Михаил",
                "Александр", "Вячеслав", "Анатолий", "Дмитрий" };
            string[] wemenName = { "Инна", "Полина", "Мария", "Алиса",
                "Томара", "Екатерина", "Анна", "Римма" };

            string[] menSurname = { "Иванов", "Пётров", "Пупкин", "Мишуткин",
                "Абрикосов", "Веников", "Сомин", "Котов" };
            string[] wemenSurname = { "Романова", "Поликарпова", "Маринина",
                "Алъенок", "Тришина", "Норкина", "Васильева", "Приходько" };

            Random rnd = new Random();

            Gender gender = (Gender)rnd.Next(2);
            int age = rnd.Next(1, 100);
            string name;
            string surname;

            if (gender == Gender.Male)
            {
                name = menName[new Random().Next(1, menName.Length)];
                surname = menSurname[new Random().Next(1, menSurname.Length)];
            }
            else
            {
                name = wemenName[new Random().Next(1, wemenName.Length)];
                surname = wemenSurname[new Random().Next(1, wemenSurname.Length)];
            }

            Person p = new Person(name, surname, age, gender);
            return p;
        }
    }
}

using System.Text.RegularExpressions;

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
        public string Name { get;}

        private string _name;

        private string _surname;

        private int _age;

        private Gender _gender;


        /// <summary>
        /// 
        /// </summary>
        public Person Parter;

        /// <summary>
        /// Метод возвращает информацию о человеке в воиде строки.
        /// </summary>
        /// <returns>Информацию о человеке в воиде строки.</returns>
        public string GetInfo()
        {
            return $"\nPerconname: {_name}, Sername: {_surname}, Age: {_age}.\n"
                + $"Percon parter {Parter?.GetInfo()}";
        }

        /// <summary>
        /// Увеличиваем возвраст человека.
        /// </summary>
        public void CelebrateHappyBirthday()
        {
            _age++;
        }
        
        // Изменения в ветке feature

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
            if (name == string.Empty)
            {
                throw new System.ArgumentException("Name is not be emptu!");
            }

            _name = name;
            _surname = surname;
            _age = age;
            _gender = gender;
        }

    }
}

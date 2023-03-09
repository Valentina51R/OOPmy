
namespace Model
{
    /// <summary>
    /// Класс для описания ребёнка
    /// </summary>
    public class Child : Person
    {
        /// <summary>
        /// Минимальный возраст ребёнка
        /// </summary>
        public const int MinChildAge = 1;

        /// <summary>
        /// Максимальный возраст ребёнка
        /// </summary>
        public const int MaxChildAge = 18;

        /// <summary>
        /// Мать.
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Отец.
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Садик / шкала.
        /// </summary>
        private string _institution;

        /// <summary>
        /// Ввод возраста ребёнка.
        /// </summary>
        public override int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value > MaxChildAge && value < MinChildAge)
                {
                    throw new ArgumentException($"Введён некорректный" +
                        $" возвраст ребёнка, введите возраст" +
                        $" от {MinChildAge} до {MaxChildAge} лет!");
                }
                else
                {
                    _age = value;
                }
            }
        }

        /// <summary>
        /// Задание матери.
        /// </summary>
        public Adult Mother
        {
            get
            {
                return _mother;
            }
            set
            {
                _mother = value;
            }
        }

        /// <summary>
        /// Задание отца.
        /// </summary>
        public Adult Fathert
        {
            get
            {
                return _father;
            }
            set
            {
                _father = value;
            }
        }

        /// <summary>
        /// Задание детсада/школы.
        /// </summary>
        public string Institution
        {
            get
            {
                return _institution;
            }
            set
            {
                _institution = value;
            }
        }

        /// <summary>
        /// Метод получения информации
        /// </summary>
        /// <returns></returns>
        public override string GetInfo()
        {
            string personInfo = $"Name: {_name} {_surname}," +
                $" Age: {_age}, Gender: {_gender}, ";
            // TODO:дублирование проверки матери и отца
            if (Mother != null)
            {
                personInfo += $"\nMother: {Mother.Name} " +
                    $"{Mother.Surname}, ";
            }
            else
            {
                personInfo += "\nNo information about the mother. ";
            }

            if (Fathert != null)
            {
                personInfo += $" Fathert: {Fathert.Name} " +
                    $"{Fathert.Surname}, ";
            }
            else
            {
                personInfo += " No information about the fathert. ";
            }
            personInfo += "Place of study: ";
            if (string.IsNullOrEmpty(Institution))
            {
                personInfo += "The child is not registered in kindergarten or school.";
            }
            else
            {
                personInfo += Institution;
            }

            return personInfo;
        }

        public string Hobby()
        {
            string[] hobbys = {
                "swimming", "tennis", "music",
                "football", "drawing" };

            string type = hobbys[new Random().Next(1, hobbys.Length)];

            return $"The child is engaged in {type}.";
        }

    }
}

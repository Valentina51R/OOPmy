
using System.Xml.Linq;

namespace Model
{
    /// <summary>
    /// Класс для описания ребёнка
    /// </summary>
    public class Child : PersonBase
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
        public Adult Father
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
        /// Проверка есть ли родитель.
        /// </summary>
        /// <param name="perent"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private string CheckParents(Adult perent, string name = "Mother")
        {
            if (perent != null)
            {
                return $"\n{name}: {perent.Name} " +
                    $"{perent.Surname}, ";
            }
            else
            {
                return $"\nNo information about the {name}. ";
            }
        }

        /// <summary>
        /// Метод получения информации
        /// </summary>
        /// <returns></returns>
        public override string GetInfo()
        {
            string personInfo = base.GetInfo();

            personInfo += CheckParents(Mother, "Mother");
            personInfo += CheckParents(Father, "Father");

            personInfo += "\nPlace of study: ";
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

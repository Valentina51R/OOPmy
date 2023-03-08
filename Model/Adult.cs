

namespace Model
{
    /// <summary>
    /// Класс для описания взрослого человека
    /// </summary>
    public class Adult : Person
    {
        /// <summary>
        /// Минимальный возраст взрослого
        /// </summary>
        public const int MinAdultAge = 18;

        /// <summary>
        /// Максимальный возраст взрослого
        /// </summary>
        public const int MaxAdultAge = 150;

        /// <summary>
        /// Паспорт.
        /// </summary>
        private string _passport;

        /// <summary>
        /// Семеное положениея.
        /// </summary>
        private MaritalStatus _maritalstatus;

        /// <summary>
        /// супруг
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Место работы.
        /// </summary>
        private string _job;

        /// <summary>
        /// Задание паспорта
        /// </summary>
        public string Рassport
        {
            get
            {
                return _passport;
            }
            set
            {
                _passport = value;
            }
        }

        /// <summary>
        /// Задание семейного положения.
        /// </summary>
        public MaritalStatus MaritalStatus
        {
            get
            {
                return _maritalstatus;
            }
            set
            {
                _maritalstatus = value;
            }
        }

        /// <summary>
        /// Задание паспорта
        /// </summary>
        public Adult Partner
        {
            get
            {
                return _partner;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(
                        $"Партнёр не задан. Этот человек одинок.");
                }
                if (MaritalStatus == MaritalStatus.Married &&
                    value.MaritalStatus == MaritalStatus.Married)
                {
                    _partner = value;
                }
                else
                {
                    throw new ArgumentException(
                        "Что-то пошло не так." +
                        "Проверти семеное положение партнёров!");
                }
                _partner = value;
            }
        }

        /// <summary>
        /// Задание места работы.
        /// </summary>
        public string Job
        {
            get
            {
                return _job;
            }
            set
            {
                _job = value;
            }
        }

        /// <summary>
        /// Ввод возраста взрослого человека.
        /// </summary>
        public override int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;

                if (value > MaxAdultAge && value < MinAdultAge)
                {
                    throw new ArgumentException($"Введён некорректный" +
                        $" возвраст взрослого, введите возраст" +
                        $" от {MinAdultAge} до {MaxAdultAge} лет!");
                }
                else
                {
                    _age = value;
                }
            }
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Adult() : base()
        {

        }

        /// <summary>
        /// Метод получения информации
        /// </summary>
        /// <returns></returns>
        public override string GetInfo()
        {
            string personInfo = base.GetInfo();
            personInfo +=
                    $"\nPassport data: {Рassport}, " +
                    $"Marital status: {MaritalStatus}, ";
            if (MaritalStatus == MaritalStatus.Married)
            {
                personInfo += $"Spouse: {Partner.Name} " +
                    $"{Partner.Surname}, ";
            }
            personInfo += "Job: ";
            if (string.IsNullOrEmpty(Job))
            {
                personInfo += "Unemployed. ";
            }
            else
            {
                personInfo += Job;
            }
            return personInfo;
        }

        /// <summary>
        /// Метод для определния типа личности.
        /// </summary>
        /// <returns></returns>
        public string PersonalityType()
        {
            string[] persontype = {
                "sanguine", "choleric",
                "phlegmatic", "melancholic" };

            string type = persontype[new Random().Next(1, persontype.Length)];

            return $"This adult has a personality type: {type}";
        }

        /*
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="passport"></param>
        /// <param name="maritalstatus"></param>
        /// <param name="partner"></param>
        /// <param name="job"></param>
        public Adult(string passport, MaritalStatus maritalstatus, Adult partner, string job) : base(name, surname, age, gender)
        {
            _passport = passport;
            _maritalstatus = maritalstatus;
            _partner = partner;
            _job = job;
        }
        */
    }
}

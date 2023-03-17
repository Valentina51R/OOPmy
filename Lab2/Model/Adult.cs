

namespace Model
{
    /// <summary>
    /// Класс для описания взрослого человека
    /// </summary>
    public class Adult : PersonBase
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
        /// Минимальный номер паспорта
        /// </summary>
        public const int MinPassportNumber = 100000000;

        /// <summary>
        /// Максимальный номер паспорта
        /// </summary>
        public const int MaxPassportNumber = 999999999;

        /// <summary>
        /// Паспорт.
        /// </summary>
        private uint _passport;

        /// <summary>
        /// супруг
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Задание паспорта
        /// </summary>
        public uint Рassport
        {
            get
            {
                return _passport;
            }
            set
            {
                if (value > MaxPassportNumber || value < MinPassportNumber)
                {
                    throw new ArgumentException($"Введён некорректный" +
                        $" номер паспорта, введите " +
                        $" от {MinPassportNumber} до {MaxPassportNumber}!");
                }
                else
                {
                    _passport = value;
                }
            }
        }

        /// <summary>
        /// Задание семейного положения.
        /// </summary>
        public MaritalStatus MaritalStatus { get; set; }


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
            }
        }

        /// <summary>
        /// Задание места работы.
        /// </summary>
        public string Job { get; set; }


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

                if (value > MaxAdultAge || value < MinAdultAge)
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
                    $"\nMarital status: {MaritalStatus}, ";
            if (MaritalStatus == MaritalStatus.Married)
            {
                personInfo += $"Spouse: {Partner.Name} " +
                    $"{Partner.Surname}, ";
            }
            personInfo += "\nJob: ";
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
        /// Метод для определния типа существа.
        /// </summary>
        /// <returns></returns>
        public string MythologicalCreature()
        {
            string[] essence = {
                "vampire", "werewolf",
                "human", "witch" };

            string type = essence[new Random().Next(1, essence.Length)];

            return $"The {Name} {Surname} is a {type}";
        }

    }
}

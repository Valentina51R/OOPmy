
namespace Model
{
    /// <summary>
    /// Класс для создания
    /// рандомного человека.
    /// </summary>
    public class RandomPerson
    {
        /// <summary>
        /// Рандом.
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Массив строк мужских имён
        /// </summary>
        private static string[] _menName = { "Емельян", "Пётр", "Игорь", "Михаил",
                "Александр", "Вячеслав", "Анатолий", "Дмитрий" };
        private static string[] _emenName = { "Damon", "Jeremy", "Matt", "Tyler",
                "Klaus", "Stefan", "Richard", "Kol" };

        /// <summary>
        /// Массив строк женских имён
        /// </summary>
        private static string[] _wemenName = { "Инна", "Полина", "Мария", "Алиса",
                "Томара", "Екатерина", "Анна", "Римма" };
        private static string[] _ewemenName = { "Elena", "Katherine", "Jenna", "Bonnie",
                "Caroline", "Vicki", "Rebekah", "Lexi" };

        /// <summary>
        /// Массив строк мужских фамилий
        /// </summary>
        private static string[] _menSurname = { "Иванов", "Петров", "Пупкин", "Мишуткин",
                "Абрикосов", "Веников", "Сомин", "Котов" };
        private static string[] _surname = { "Bennet", "Gilbert", "Pierce", "Salvatore",
                "Sommers", "Forbes", "Donovan", "Lockwood" };

        /// <summary>
        /// Массив строк женских фамилий
        /// </summary>
        private static string[] _wemenSurname = { "Романова", "Поликарпова", "Маринина",
                "Алъенок", "Тришина", "Норкина", "Васильева", "Приходько" };

        public static Person GetRandomAdultOrChild()
        {
            var who = _random.Next(0, 2);
            if (who > 0)
            {
                return GetRandomChild();
            }
            else
            {
                return GetRandomAdult();
            }
        }

        // TODO: попытка задания нужного гендера
        /// <summary>
        /// Создание рандомного человека
        /// </summary>
        /// <returns></returns>
        public static void GetRandomPerson(Person person, bool yourchoice = false, Gender genderr = Gender.Male)
        {
            Gender genderPerson = (Gender)_random.Next(2);

            if (yourchoice == false)
            {
                person.Gender = genderPerson;
            }
            else
            {
                person.Gender = genderr;
            }
            // TODO: разделить на взрослого и ребенка
            person.Age = _random.Next(1, 100);
            string name;
            string surname;

            if (genderPerson == Gender.Male)
            {
                person.Name = _emenName[_random.Next(1, _emenName.Length)];
                person.Surname = _surname[_random.Next(1, _surname.Length)];
            }
            else
            {
                person.Name = _ewemenName[_random.Next(1, _ewemenName.Length)];
                person.Surname = _surname[_random.Next(1, _surname.Length)];
            }

        }

        /// <summary>
        /// Создание рандомного взрослого
        /// </summary>
        /// <returns></returns>
        public static Adult GetRandomAdult(MaritalStatus status = MaritalStatus.Single, Adult partner = null)
        {
            Adult randomAdult = new Adult();
            GetRandomPerson(randomAdult);

            randomAdult.Age = _random.Next(Adult.MinAdultAge, Adult.MaxAdultAge);

            MaritalStatus maritalstatus = (MaritalStatus)_random.Next(2);
            randomAdult.MaritalStatus = maritalstatus;

            if (maritalstatus == MaritalStatus.Married)
            {
                //TODO: должен быть партнёр противоположного пола
                if (randomAdult.Gender == Gender.Male)
                {
                    randomAdult.Partner = GetRandomAdult(MaritalStatus.Married, randomAdult);
                }
                else
                {
                    randomAdult.Partner = GetRandomAdult(MaritalStatus.Married, randomAdult);
                }
            }
            else
            {
                randomAdult.MaritalStatus = status;
                //randomAdult.Partner = partner;
            }
            string[] job = { "СО", "РусГидро", "Сбербанк",
                "КрасФарма", "НорНикель", "РосБанк" };

            randomAdult.Job = job[_random.Next(0, job.Length)];

            var passport = _random.Next(100000000, 999999999).ToString();
            randomAdult.Рassport = passport;

            return randomAdult;
        }

        public static Child GetRandomChild()
        {
            Child randomChild = new Child();
            GetRandomPerson(randomChild);

            randomChild.Age = _random.Next(Child.MinChildAge, Child.MaxChildAge);

            var mother = _random.Next(0, 2);

            if (mother > 0)
            {
                // TODO: только женщина
                randomChild.Mother = GetRandomAdult();
            }

            var fathert = _random.Next(0, 2);

            if (fathert > 0)
            {
                // TODO: только мужчина
                randomChild.Fathert = GetRandomAdult();
            }

            string[] kindergarten = {
                "Kindergarten \"Rucheek\"", "Kindergarten \"Dandelion\"",
                "Kindergarten \"Sunny\"", "Kindergarten \"Cucumbers\"" };

            string[] school = {
                "Forks High School", "The Cambridge School of Weston",
                "Mystic Falls High School", "Beacon Hills High School" };

            var hasInstitution = _random.Next(0, 2);

            if (hasInstitution > 0)
            {
                if (randomChild.Age < 8)
                {
                    randomChild.Institution = kindergarten[_random.Next(1, kindergarten.Length)];
                }
                else
                {
                    randomChild.Institution = school[_random.Next(1, school.Length)];
                }
            }

            return randomChild;
        }
    }
}

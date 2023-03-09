
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
        private static string[] _menNames = { "Damon", "Jeremy", "Matt", "Tyler",
                "Klaus", "Stefan", "Richard", "Kol" };

        /// <summary>
        /// Массив строк женских имён
        /// </summary>
        private static string[] _wemenNames = { "Elena", "Katherine", "Jenna", "Bonnie",
                "Caroline", "Vicki", "Rebekah", "Lexi" };

        /// <summary>
        /// Массив строк фамилий
        /// </summary>
        private static string[] _surnames = { "Bennet", "Gilbert", "Pierce", "Salvatore",
                "Sommers", "Forbes", "Donovan", "Lockwood" };


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
        public static void GetRandomPerson(Person person, string yourchoice = "rand")
        {
            //Gender genderPerson = (Gender)_random.Next(2);

            if (yourchoice == "men")
            {
                person.Gender = Gender.Male;
            }
            else if (yourchoice == "wemen")
            {
                person.Gender = Gender.Female;
            }
            else
            {
                person.Gender = (Gender)_random.Next(2);
            }
            // TODO: разделить на взрослого и ребенка
            person.Age = _random.Next(1, 100);
            string name;
            string surname;

            if (person.Gender == Gender.Male)
            {
                person.Name = _menNames[_random.Next(1, _menNames.Length)];
                person.Surname = _surnames[_random.Next(1, _surnames.Length)];
            }
            else
            {
                person.Name = _wemenNames[_random.Next(1, _wemenNames.Length)];
                person.Surname = _surnames[_random.Next(1, _surnames.Length)];
            }

        }

        /// <summary>
        /// Создание рандомного взрослого
        /// </summary>
        /// <returns></returns>
        public static Adult GetRandomAdult(MaritalStatus status
            = MaritalStatus.Single, Adult partner = null, string yourchoice = "rand")
        {
            Adult randomAdult = new Adult();
            GetRandomPerson(randomAdult, yourchoice);

            randomAdult.Age = _random.Next(Adult.MinAdultAge, Adult.MaxAdultAge);

            MaritalStatus maritalstatus = (MaritalStatus)_random.Next(2);
            randomAdult.MaritalStatus = maritalstatus;

            if (maritalstatus == MaritalStatus.Married)
            {
                //TODO: должен быть партнёр противоположного пола
                if (randomAdult.Gender == Gender.Male)
                {
                    randomAdult.Partner = GetRandomAdult(MaritalStatus.Married, randomAdult, "wemen");
                }
                else
                {
                    randomAdult.Partner = GetRandomAdult(MaritalStatus.Married, randomAdult, "men");
                }
            }
            else
            {
                randomAdult.MaritalStatus = status;
                //randomAdult.Partner = partner;
            }
            string[] job = { "СО", "РусГидро", "Сбербанк",
                "КрасФарма", "НорНикель", "РосБанк" };

            var getjob = _random.Next(0, 4);

            if (getjob > 0)
            {
                randomAdult.Job = job[_random.Next(0, job.Length)];
            }

            var passport = _random.Next(100000000, 999999999).ToString();
            randomAdult.Рassport = passport;

            return randomAdult;
        }

        public static Child GetRandomChild()
        {
            Child randomChild = new Child();
            GetRandomPerson(randomChild);

            randomChild.Age = _random.Next(Child.MinChildAge, Child.MaxChildAge);

            var mother = _random.Next(0, 4);

            if (mother > 0)
            {
                // TODO: только женщина
                randomChild.Mother = GetRandomAdult(MaritalStatus.Married, randomChild.Fathert, "wemen");
            }

            var fathert = _random.Next(0, 4);

            if (fathert > 0)
            {
                // TODO: только мужчина
                randomChild.Fathert = GetRandomAdult(MaritalStatus.Married, randomChild.Mother, "men");
            }

            string[] kindergarten = {
                "Kindergarten \"Rucheek\"", "Kindergarten \"Dandelion\"",
                "Kindergarten \"Sunny\"", "Kindergarten \"Cucumbers\"" };

            string[] school = {
                "Forks High School", "The Cambridge School of Weston",
                "Mystic Falls High School", "Beacon Hills High School" };

            var hasInstitution = _random.Next(0, 4);

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

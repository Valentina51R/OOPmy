
namespace Model
{
    public class RandomPerson
    {
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

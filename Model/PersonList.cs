
namespace Model
{
    /// <summary>
    /// Лист персоны.
    /// </summary>
    public class PersonList
    {
        private List<Person> _people = new List<Person>();

        /// <summary>
        /// Добавление элемента.
        /// </summary>
        /// <param name="people"></param>
        public void Add(Person person)
        {
            _people.Add(person);
            return;
        }

        /// <summary>
        /// Добавление элемента.
        /// </summary>
        /// <param name="people"></param>
        public void AddPerson(string name, string surname, ushort age, Gender gender)
        {
            _people.Add(new Person(name, surname, age, gender));
            /*
            while (true)
            {
                try
                {
                    _people.Add(new Person(name, surname, age, gender));
                    return;
                }

                catch (ArgumentException ex)
                {
                    // TODO: Вынести в консоль
                    Console.WriteLine("Ошибка! " + ex.Message);
                }
            }
            */
        }

        /// <summary>
        /// Удаление всего списка.
        /// </summary>
        /// <param name="people"></param>
        public void DeleteAll()
        {
            _people.Clear();
        }

        /// <summary>
        /// Удалять элементы по индексу.
        /// </summary>
        /// <param name="people"></param>
        /// <param name="index"></param>
        public void DeleteByIndex(int index)
        {
            // Проверка индекса
            _people.RemoveAt(index);
        }

        // TODO: этот метод не используется в программе
        /// <summary>
        /// Удалить выбранный элемент списка.
        /// По фамилии.
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public int DeleteBySurname(string surname)
        {

            // Удаляет элементы из списка по условию
            // и возвращает кол-во удалений.
            int count = _people.RemoveAll(s => s.Surname == surname);
            return count;
        }

        /// <summary>
        /// Искать элемент по указанному индексу.
        /// </summary>
        /// <param name="people"></param>
        /// <param name="index"></param>
        public Person FindByIndex(int index)
        {
            int countIndex = _people.Count - 1;

            if (countIndex < index)
            {
                throw new Exception("Элемента с таким индексам нет в списке");
                return _people[countIndex];
            }
            else
            {
                return _people[index];
            }
        }

        /// <summary>
        /// Вернуть индекс элемента при
        /// наличии его в списке.
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public int FindIndex(string surname)
        {
            int index = _people.FindIndex(s => s.Surname == surname);
            return index;
        }

        /// <summary>
        /// Колличество элементов в списке.
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public int CountList()
        {
            return _people.Count;
        }
    }
}

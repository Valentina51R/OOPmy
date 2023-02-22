
namespace Model
{
    /// <summary>
    /// Лист персоны.
    /// </summary>
    public class PersonList
    {
        //TODO: XML
        private List<Person> _people = new List<Person>();

        /// <summary>
        /// Добавление элемента.
        /// </summary>
        /// <param name="people"></param>
        public void Add(Person person)
        {
            _people.Add(person);
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
            int countIndex = _people.Count - 1;

            if (countIndex < index)
            {
                throw new IndexOutOfRangeException($"Элемента с индексом" +
                    $" {index} нет в списке");
            }
            else
            {
                _people.RemoveAt(index);
            }
        }

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
                throw new IndexOutOfRangeException("Элемента с индексом " +
                    "{index} нет в списке");
            }
            else
            {
                return _people[index];
            }
        }

        /// <summary>
        /// Вернуть индекс элемента (по фамилии) при
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
        public int CountElementsList()
        {
            return _people.Count;
        }
    }
}

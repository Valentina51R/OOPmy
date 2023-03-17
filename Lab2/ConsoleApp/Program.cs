using Model;

namespace ConsoleApp
{
    /// <summary>
    /// Основная программа.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Основная программа.
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("Each new step is performed by" +
                " pressing any keyboard key.\nPress any key.");
            _ = Console.ReadKey();

            // а.Создание программно двух списков персон,
            // в каждом из которых будет по три человека.
            Console.WriteLine("\n\t\tCreating programmatically" +
                " a list of persons consisting of seven people.");
            _ = Console.ReadKey();

            PersonList personlist = new PersonList();

            for (int i = 0; i < 7; i++)
            {
                personlist.Add(RandomPerson.GetRandomAnyPerson());
            }

            // Печать исходного списка
            Console.WriteLine("List of people:");
            ConsolePerson.Print(personlist);

            Console.WriteLine("\n\tThe fourth person on the list.\n");
            _ = Console.ReadKey();

            PersonBase person = personlist.FindByIndex(3);

            switch (person)
            {
                case Adult:
                    {
                        Adult adult = (Adult)person;
                        Console.WriteLine("This is an adult!");
                        Console.WriteLine(adult.MythologicalCreature());
                        break;
                    }

                case Child:
                    {
                        Child child = (Child)person;
                        Console.WriteLine("It's a child!");
                        Console.WriteLine(child.Dishes());
                        break;
                    }
                default:
                    break;
            }

            Console.WriteLine("\n\t\tSomething interesting!!!" +
                "\n\t\tCreating a new person.");
            _ = Console.ReadKey();

            PersonBase newperson = ConsolePerson.InputPersonByConsole();

            Console.WriteLine("\nA new person: ");
            Console.WriteLine(newperson.GetInfo());
        }
    }
}

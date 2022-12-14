using Model;
using System;

namespace ConsoleApp
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person percon = new Person(null, "Ivanov", 20, Gender.Male);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            

            Person partner = new Person("Anastasha", "Ivanova", 40, Gender.Female);

            //percon.Parter = partner;
            /*
            for(int i = 0; i < 20; i++)
            {
                percon.CelebrateHappyBirthday();
            }
            */
            // Console.WriteLine(percon.GetInfo());
            Console.ReadKey();
        }
    }
}
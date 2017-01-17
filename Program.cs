using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingCreative_OOP
{
    class Program
    {
        static bool addPerson = true;
        static string name;
        static List<Person> people = new List<Person>();
        static Person currentPerson;

        static void Main(string[] args)
        {
            while (addPerson)
            {
                GetPeople();
            }

            Console.Clear();
            Console.WriteLine("Here is your list: \n");
            DisplayPeople();

            Console.WriteLine("\n Who would you like to see info on? ");
            string personName = Console.ReadLine();
            currentPerson = people.Find(x => x.name == personName);

            Console.Clear();
            Console.WriteLine(currentPerson.name + "\n");
            currentPerson.DisplayHobbies();
            Console.WriteLine("\n" + currentPerson.age +
                "\n" + currentPerson.ReturnDOB());

        }

        /********************************************************************
         * GetPeople()                                                      *
         *   Method that gets people and adds them as an instance of Person *
         *   and to a list of Person objects                                *
         ********************************************************************/
        static void GetPeople()
        {
            string yN;
            bool valid = true;

            do
            {
                Console.WriteLine("Please enter a name: ");
                name = Console.ReadLine();

                if (name.All(char.IsLetter))
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.WriteLine($"{name} is not valid. Try again. ");
                }

            } while (!valid);

            Person person = new Person(name);
            people.Add(person);

            do
            {
                Console.WriteLine("\n Add another? (Y/N)");
                yN = Console.ReadLine().ToLower();

                if (yN != "y" && yN != "n")
                {
                    valid = false;
                    Console.WriteLine($"{yN} is not a valid response. Try Again. ");
                }
                else
                {
                    valid = true;
                    Console.WriteLine("\n");
                }

            } while (!valid);

            addPerson = yN == "y" ? true : false;
        }

        /********************************************************************
         * DisplayPeople()                                                  *
         *   Method that displays contents of people<>                      *
         ********************************************************************/
        static void DisplayPeople()
        {
            foreach (var person in people)
            {
                Console.Write(string.Join(", ", person) + "\n");
            }
        }

    }
}


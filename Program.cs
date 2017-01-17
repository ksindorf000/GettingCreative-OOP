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

        static void Main(string[] args)
        {
            while (addPerson)
            {
                GetPersonList();
            }

        }

        /********************************************************************
         * GetPersonList()                                                  *
         *   Method that gets people and adds them as an instance of Person *
         ********************************************************************/
        static void GetPersonList()
        {
            string yN;
            bool valid = true;

            do
            {
                Console.WriteLine("Please enter the name of an acquaintance: ");
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

    }
}


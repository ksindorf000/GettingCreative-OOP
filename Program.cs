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
        static int qId;
        static bool socialize = true;

        /********************************************************************
         * Main()                                                           *
         ********************************************************************/
        static void Main(string[] args)
        {

            while (addPerson)
            {
                GetPeople();
            }

            while (socialize)
            {
                Console.Clear();
                DisplayPeople();

                GetCurrentPerson();
                Console.Clear();

                DisplayDetails();
                ProcessInteraction();

                socialize = ShallWeCOntinue();                
            }

            Console.Clear();
            DisplayFinals();
        }

        /********************************************************************
         * ShallWeContinue()                                                *
         *   Method that asks the user whether or not they would like to    *
         *   continue socializing                                           *
         ********************************************************************/
        private static bool ShallWeCOntinue()
        {
            Console.WriteLine("Would you like to continue socializing? (Y/N)");
            string yN = Console.ReadLine().ToLower();
            socialize = yN == "y" ? true : false;
            return socialize;
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
                name = Console.ReadLine().ToUpper();

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
            Console.WriteLine("Here is your list of people: \n");

            foreach (var person in people)
            {
                Console.Write(string.Join(", ", person) + "\n");
            }
        }

        /********************************************************************
        * GetCurrentPerson()                                               *
        *   Method that gets and validates current Person based on name    *
        ********************************************************************/
        static void GetCurrentPerson()
        {
            bool valid = true;
            string personName;

            do
            {
                Console.WriteLine("\n Who would you like to interact with? ");
                personName = Console.ReadLine().ToUpper();

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

            currentPerson = people.Find(x => x.name == personName);
        }

        /********************************************************************
         * DisplayDetails()                                                 *
         *   Method that displays details for the requested Person          *
         ********************************************************************/
        static void DisplayDetails()
        {
            Console.Clear();
            Console.WriteLine(currentPerson.name + "\n");

            currentPerson.DisplayHobbies();

            Console.WriteLine("\n" +
                currentPerson.age + "\n" +
                currentPerson.ReturnDOB());
        }

        /********************************************************************
         * ProcessInteraction()                                             *
         *   Method that generates questions for the selected person,       *
         *   displays available questions for selection, calculates and     *
         *   displays friend points for selected person                     *
         ********************************************************************/
        static void ProcessInteraction()
        {
            Console.WriteLine("\n");
            Questions.CreateQuestions(currentPerson);
            Questions.DisplayQuestions();
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine($"What question would you like to ask {currentPerson} (#): ");
                valid = int.TryParse(Console.ReadLine(), out qId);
            }

            string question = Questions.DisplaySingleQuestion(qId);
            int friendPts = Questions.GetFriendPtValue(qId);
            int totalPts = currentPerson.FriendPointCalc(friendPts);

            Console.Clear();
            Console.WriteLine($"You asked {currentPerson} \"{question}\" and gained {friendPts} friend points. ");
            Console.WriteLine($"You have accrued {totalPts} friend points through interaction with {currentPerson}!");
        }

        /********************************************************************
         * DisplayFinals()                                                  *
         *   Method that displays all People and their final friend points  *
         ********************************************************************/
        static void DisplayFinals()
        {
            foreach (var person in people.ToList())
            {
                Console.WriteLine($"{person.name}: {person.friendPts}");
            }

        }

    }
}


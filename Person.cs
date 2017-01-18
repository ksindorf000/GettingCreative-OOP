using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingCreative_OOP
{
    enum State
    {
        MortalEnemy,
        Frienemy,
        Acquaintance,
        Friend,
        CloseFriend
    }

    class Person
    {

        public string name;
        private int friendPts;
        private DateTime birthday;
        public DateTime today = DateTime.Today;
        private Random gen = new Random();
        public int age;
        private List<string> hobbies = new List<string>();
        private Dictionary<int, Questions> questions = new Dictionary<int, Questions>();


        /********************************************************************
         * Constructor                                                      *
         *   Sets name, friendPoints, birthday and age                      *
         ********************************************************************/
        public Person(string _name)
        {
            name = _name;
            friendPts = 0;
            birthday = genBirthday();
            age = today.Year - birthday.Year;
            GenHobbies();
        }


        /********************************************************************
         * Override ToString()                                              *
         ********************************************************************/
        public override string ToString()
        {
            return name;
        }


        /********************************************************************
         * genBirthday()                                                    *
         *   Method that generates a random date between 1960 and 1996 and  *
         *   returns it (to be used as birthdate                            *
         ********************************************************************/
        public DateTime genBirthday()
        {
            DateTime end = new DateTime(1996, 1, 1);
            DateTime start = new DateTime(1960, 1, 1);

            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }

        /********************************************************************
         * GenHobbies()                                                     *
         *   Method that pulls 4 random hobbies from a txt file and adds    *
         *   them to a list of hobbies for the person                       *
         ********************************************************************/
        public void GenHobbies()
        {
            string[] hobbyArray = File.ReadAllLines(@"..\..\hobbies.txt");
            var rhg = new Random();

            for (int i = 0; i < 5; i++)
            {
                int randomNum = rhg.Next(hobbyArray.Length);
                hobbies.Add(hobbyArray[randomNum]);
            }
        }

        /********************************************************************
         * DisplayHobbies()                                                 *
         ********************************************************************/
        public void DisplayHobbies()
        {
            hobbies.ForEach(Console.WriteLine);
        }

        /********************************************************************
         * ReturnDOB()                                                      *
         ********************************************************************/
        public string ReturnDOB()
        {
            return birthday.ToShortDateString();
        }

        /********************************************************************
         * CreateQuestions()                                                *
         *   Method that creates customized questions for the current person*
         ********************************************************************/
        private void CreateQuestions(Person currentPerson)
        {
            Questions q1 = new Questions("How about this weather?", 0);
            Questions q2 = new Questions($"So what do you like about {currentPerson.hobbies[0]}?", 1);
            Questions q3 = new Questions($"Would you like to hang out and talk about {currentPerson.hobbies[1]} later?", 2);
            Questions q4 = new Questions($"You like {currentPerson.hobbies[2]}?! Why?", -1);
            Questions q5 = new Questions($"Your name is {currentPerson.name}? Bet you gave your parents hell for that one!", -2);

            questions.Add(1, q1);
            questions.Add(2, q2);
            questions.Add(3, q3);
            questions.Add(4, q4);
            questions.Add(5, q5);
        }

        /********************************************************************
         * DisplayQuestions()                                               *
         *   Method that displays questions for the current person          *
         ********************************************************************/
        private void DisplayQuestions()
        {
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine(questions);
            }
        }


    }

}


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
        public int friendPts;
        private DateTime birthday;
        public DateTime today = DateTime.Today;
        private Random gen = new Random();
        public int age;
        internal List<string> hobbies = new List<string>();

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
         * FriendPointCalc()                                          *
         *   Method that adds points from given question to given person's   *
         *   total points                                                    *
         ********************************************************************/
        public int FriendPointCalc(int addPts)
        {
            friendPts += addPts;
            return friendPts;
        }

    }

}


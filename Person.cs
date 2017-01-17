using System;
using System.Collections.Generic;
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
        public DateTime birthday;
        private List<string> interests = new List<string>();

        public Person(string _name)
        {
            name = _name;
            friendPts = 0;
        }

        public override string ToString()
        {
            return name;
        }

        private void Birthday()
        {


        }




    }
}

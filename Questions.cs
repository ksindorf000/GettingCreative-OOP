using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingCreative_OOP
{
    class Questions
    {
        private string text;
        private int value;
        public static Dictionary<int, dynamic> questions = new Dictionary<int, dynamic>();

        /********************************************************************
         * Constructor()                                                    *
         ********************************************************************/
        public Questions(string _text, int _value)
        {
            text = _text;
            value = _value;
        }

        /********************************************************************
         * CreateQuestions()                                                *
         *   Method that creates customized questions for the current person*
         ********************************************************************/
        public static void CreateQuestions(Person currentPerson)
        {
            questions.Clear();

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
        public static void DisplayQuestions()
        {
            foreach (var question in questions.Keys.ToArray())
            {
                var qText = questions[question].text;
                Console.WriteLine($"{question}) {qText}");
            }
        }

        /********************************************************************
         * DisplaySingleQuestion()                                          *
         *   Method that displays the text of a question based on id        *
         ********************************************************************/
        public static string DisplaySingleQuestion(int qId)
        {
            questions.Keys.ToArray();
            var qText = questions[qId].text;
            return qText;
        }

        /********************************************************************
         * GetFriendPtValue()                                               *
         *   Method that returns the friend point value for a given question*
         ********************************************************************/
        public static int GetFriendPtValue(int qId)
        {
            questions.Keys.ToArray();
            var qPts = questions[qId].value;
            return qPts;
        }
    }
}

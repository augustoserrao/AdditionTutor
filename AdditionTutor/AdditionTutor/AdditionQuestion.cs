using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionTutor
{
    class AdditionQuestion
    {
        const string PLUS_SIGN = "+";
        const string EQUALS_SIGN = "=";
        const string CORRECT = "Correct";
        const string INCORRECT = "Incorrect";
        const string ARROW = "->";
        const string RESULT_STRING = "-> Result should be:";

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public int UserAnswer { get; set; }
        public int CorrectAnswer { get; }
        public bool Result { get; }

        public AdditionQuestion(int firstNumber, int secondNumber, int userAnswer)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            UserAnswer = userAnswer;
            CorrectAnswer = firstNumber + secondNumber;
            Result = CorrectAnswer == UserAnswer ? true : false;
        }

        public AdditionQuestion(string question)
        {
            string[] auxString;
            
            auxString = question.Split(';');
            FirstNumber = int.Parse(auxString[0]);
            SecondNumber = int.Parse(auxString[1]);
            UserAnswer = int.Parse(auxString[2]);
            CorrectAnswer = int.Parse(auxString[4]);

            Result = auxString[3] == CORRECT;
        }

        public override string ToString()
        {
            string result = Result ? CORRECT : INCORRECT;
            return $"{FirstNumber};{SecondNumber};{UserAnswer};{result};{CorrectAnswer}\n";
        }

        public string ToBeautifulString()
        {
            string result = Result ? CORRECT : INCORRECT;
            return $"{FirstNumber} + {SecondNumber} = {UserAnswer} -> {result} -> Result should be: {CorrectAnswer}\n";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdditionTutor
{
    class AdditionTutorVM : INotifyPropertyChanged
    {
        const int NUMBER_MAX_VALUE = 500;
        const int NUMBER_MIN_VALUE = 100;
        const int RANDOM_GENERATION_CORRECTION = 1;

        public enum VerificationCodeList
        {
            RESULT_IDLE,
            RESULT_WRONG,
            RESULT_OK,
            RESULT_ERROR_INVALID_ENTRY
        }

        // Binded variables
        int firstNumber;
        int secondNumber;
        int userResult = 0;
        int rightAnswers = 0;
        int wrongAnswers = 0;
        float scorePercentage;
        VerificationCodeList verificationCode = VerificationCodeList.RESULT_IDLE;

        public int FirstNumber
        {
            get { return firstNumber; }
            set { firstNumber = value; _propertyChanged(); }
        }

        public int SecondNumber
        {
            get { return secondNumber; }
            set { secondNumber = value; _propertyChanged(); }
        }

        public int UserResult
        {
            get { return userResult; }
            set { userResult = value; _propertyChanged(); }
        }

        public int RightAnswers
        {
            get { return rightAnswers; }
            set { rightAnswers = value; _propertyChanged(); }
        }

        public int WrongAnswers
        {
            get { return wrongAnswers; }
            set { wrongAnswers = value; _propertyChanged(); }
        }

        public float ScorePercentage
        {
            get { return scorePercentage; }
            set { scorePercentage = value; _propertyChanged(); }
        }

        public VerificationCodeList VerificationCode
        {
            get { return verificationCode; }
            set { verificationCode = value; _propertyChanged(); }
        }

        // VM constructor
        public AdditionTutorVM()
        {
            _generateRandomNumbers();
        }

        public void VerifyResult()
        {
            // Verify if value was entered correctly
            if (UserResult == 0)
            {
                VerificationCode = VerificationCodeList.RESULT_ERROR_INVALID_ENTRY;
            }
            else
            {
                AdditionQuestion addQuestion = new AdditionQuestion(FirstNumber, SecondNumber, UserResult);

                if (addQuestion.Result)
                {
                    VerificationCode = VerificationCodeList.RESULT_OK;
                }
                else
                {
                    VerificationCode = VerificationCodeList.RESULT_WRONG;
                }

                HistoryFile histfile = new HistoryFile();
                histfile.AddItem(addQuestion);
            }
        }

        // Reset binded variables
        public void Reset()
        {
            UserResult = 0;
            VerificationCode = VerificationCodeList.RESULT_IDLE;
            _generateRandomNumbers();
        }
        
        // Get all questions history and populate result in RightAnswers, WrongAnswers, ans ScorePercentage
        public void GetScore()
        {
            HistoryFile histfile = new HistoryFile();

            RightAnswers = 0;
            WrongAnswers = 0;

            foreach (AdditionQuestion question in histfile.GetAllItens())
            {
                if (question.Result)
                    RightAnswers++;
                else
                    WrongAnswers++;
            }

            ScorePercentage = (float)RightAnswers / (RightAnswers + WrongAnswers);
        }

        private void _generateRandomNumbers()
        {
            Random r = new Random();
            FirstNumber = r.Next(NUMBER_MIN_VALUE, NUMBER_MAX_VALUE + RANDOM_GENERATION_CORRECTION);
            SecondNumber = r.Next(NUMBER_MIN_VALUE, NUMBER_MAX_VALUE + RANDOM_GENERATION_CORRECTION);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void _propertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

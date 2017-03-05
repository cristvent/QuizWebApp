using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLibrary
{
    public class QuizRepository
    {
        private List<QuizQuestion> _questionList = new List<QuizQuestion>();
        private static List<string> _questionTypeList = new List<string>();
        private static Random _randy = new Random();
        private static int nextId = 0;

        public QuizRepository()
        {
            LoadSample();
            LoadTypes();
        }

        public List<string> GetQuestionTypes()
        {
            return _questionTypeList;
        }

        public List<QuizQuestion> GetQuestions()
        {
            return _questionList;
        }

        public List<QuizQuestion> GetQuestions(int maxNumberOfQuestions)
        {
            // Holder list to fill and return. Length based on maxNumberOfQuestions
            List<QuizQuestion> returnList = new List<QuizQuestion>();

            // Fill holder list and fill based on the index position of the random number in the main question list
            for (int i = 0; i < maxNumberOfQuestions; i++)
            {
                int myRandomNumber = _randy.Next(0, _questionList.Count);
                returnList.Add(_questionList[myRandomNumber]);
            }

            // Return the new filled list
            return returnList;
        }

        public QuizQuestion GetQuestionById(int id)
        {
            return _questionList.Find(question => question.Id == id);
        }

        public void UpdateQuestionById(QuizQuestion updateQuestion)
        {
            _questionList.RemoveAll(question => question.Id == updateQuestion.Id);
            _questionList.Add(updateQuestion);
        }

        public QuizQuestion GetQuestion()
        {
            return GetQuestions(1)[0];
        }

        public void AddQuestion(QuizQuestion newQuestion)
        {
            newQuestion.Id = nextId++;
            _questionList.Add(newQuestion);
        }

        public void DeleteQuestion(int id)
        {
            _questionList.RemoveAll(question => question.Id == id);
        }

        public void LoadSample()
        {
            QuizQuestion newQuestion = new QuizQuestion()
            {
                Category = "Geography",
                QuestionType = "Multiple Choice",
                Content = "What state are we in right now?",
                Answers = new List<QuizAnswer>
                {
                    new QuizAnswer{
                        Id = 1,
                        Content = "California",
                        IsCorrect = false
                    },
                    new QuizAnswer{
                        Id = 2,
                        Content = "Texas",
                        IsCorrect = false
                    },
                    new QuizAnswer
                    {
                        Id = 3,
                        Content = "Georgia",
                        IsCorrect = true
                    },
                    new QuizAnswer
                    {
                        Id = 4,
                        Content = "Florida",
                        IsCorrect = false
                    }
                }

            };

            AddQuestion(newQuestion);
        }

        public void LoadTypes()
        {
            _questionTypeList.Add("Multiple Choice");
            _questionTypeList.Add("True/False");
        }

    }
}

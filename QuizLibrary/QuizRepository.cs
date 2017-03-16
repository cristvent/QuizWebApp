using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLibrary
{
    public class QuizRepository
    {
        private List<Question> _questionList = new List<Question>();
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

        public List<Question> GetQuestions()
        {
            return _questionList;
        }

        public List<Question> GetQuestions(int maxNumberOfQuestions)
        {
            // Holder list to fill and return. Length based on maxNumberOfQuestions
            List<Question> returnList = new List<Question>();

            // Fill holder list and fill based on the index position of the random number in the main question list
            for (int i = 0; i < maxNumberOfQuestions; i++)
            {
                int myRandomNumber = _randy.Next(0, _questionList.Count);
                returnList.Add(_questionList[myRandomNumber]);
            }

            // Return the new filled list
            return returnList;
        }

        public Question GetQuestionById(int id)
        {
            return _questionList.Find(question => question.QuestionId == id);
        }

        public void UpdateQuestionById(Question updateQuestion)
        {
            _questionList.RemoveAll(question => question.QuestionId == updateQuestion.QuestionId);
            _questionList.Add(updateQuestion);
        }

        public Question GetQuestion()
        {
            return GetQuestions(1)[0];
        }

        public void AddQuestion(Question newQuestion)
        {
            newQuestion.QuestionId = nextId++;
            _questionList.Add(newQuestion);
        }

        public void DeleteQuestion(int id)
        {
            _questionList.RemoveAll(question => question.QuestionId == id);
        }

        public void LoadSample()
        {
            Question newQuestion = new Question()
            {
                Category = "Geography",
                Content = "What state are we in right now?",
                Answers = new List<Answer>
                {
                    new Answer{
                        AnswerId = 1,
                        Content = "California",
                        IsCorrect = false
                    },
                    new Answer{
                        AnswerId = 2,
                        Content = "Texas",
                        IsCorrect = false
                    },
                    new Answer
                    {
                        AnswerId = 3,
                        Content = "Georgia",
                        IsCorrect = true
                    },
                    new Answer
                    {
                        AnswerId = 4,
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

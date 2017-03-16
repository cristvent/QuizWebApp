using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizLibrary;

namespace QuizLibrary
{
    public class QuizStorageInMemory : IQuizStorage
    {
        public List<Quiz> _quizStorage = new List<Quiz>();
        int quizCounter = 1;

        public QuizStorageInMemory()
        {
            LoadQuizSample();
        }

        public List<Quiz> GetQuizAll()
        {
            return _quizStorage;
        }

        public Quiz GetQuizById(int id)
        {
            return _quizStorage.Find(quiz => quiz.QuizId == id);
        }

        public void AddQuiz(Quiz newQuiz)
        {
            newQuiz.QuizId = quizCounter++;
            _quizStorage.Add(newQuiz);
        }

        public void EditQuiz(int id, Quiz quizChanged)
        {
            int num = _quizStorage.IndexOf(GetQuizById(id));
            _quizStorage[num] = quizChanged;
        }

        public void DeleteContent(int id)
        {
            _quizStorage.Remove(GetQuizById(id));
        }

        public void LoadQuizSample()
        {
            Quiz newQuiz = new Quiz()
            {
                Title = "Objects and Classes",
                Topic = "Javascript",
                Active = false,
                Questions = new List<Question>
                {
                   new Question
                   {
                       QuestionId = 1,
                       QuizId = 1,
                       Content = "What is your name?",
                       Answers = new List<Answer>
                       {
                           new Answer {
                               AnswerId = 1,
                               QuestionId = 1,
                               Content = "Wilmer",
                               IsCorrect = false
                           },
                           new Answer
                           {
                               AnswerId = 2,
                               QuestionId = 1,
                              Content = "Bob",
                              IsCorrect = false
                           },
                           new Answer
                           {
                               AnswerId = 3,
                               QuestionId = 1,
                               Content = "Ricky",
                               IsCorrect = false
                           },
                           new Answer
                           {
                               AnswerId = 4,
                               QuestionId = 1,
                               Content = "Cristian",
                               IsCorrect = true
                           }
                       }
                   },

                   new Question
                   {
                       QuestionId = 2,
                       QuizId = 1,
                       Content = "What state are we located in?",
                       Answers = new List<Answer>
                       {
                           new Answer {
                               AnswerId = 1,
                               QuestionId = 2,
                               Content = "Florida",
                               IsCorrect = false
                           },
                           new Answer
                           {
                               AnswerId = 2,
                               QuestionId = 2,
                              Content = "Kansas",
                              IsCorrect = false
                           },
                           new Answer
                           {
                               AnswerId = 3,
                               QuestionId = 2,
                               Content = "Georgia",
                               IsCorrect = true
                           },
                           new Answer
                           {
                               AnswerId = 4,
                               QuestionId = 2,
                               Content = "Texas",
                               IsCorrect = false
                           }
                       }
                   }
                }
            };
            AddQuiz(newQuiz);

            using (var db = new QuizDbContext())
            {
                //Quiz quizOne = new Quiz
                //{
                //    Title = "Random Test Questions",
                //    Topic = "Testing",
                //    Questions = new List<Question>
                //    {
                //        new Question {
                //        Content = "What area are we located in?",
                //        Answers = new List<Answer> {
                //        new Answer { Content = "Norcross" , IsCorrect = false},
                //        new Answer { Content = "Dalton" , IsCorrect = false },
                //        new Answer { Content = "Lilburn", IsCorrect = true },
                //        new Answer { Content = "Kenessaw", IsCorrect = false }
                //        }
                //        }
                //    }
                //};

                //db.QuizTable.Add(quizOne);
                //db.SaveChanges();

                var quizList = from quiz in db.QuizTable
                               select quiz;

                foreach (var item in quizList)
                {
                    AddQuiz(item);
                }

            }
        }

    }
}

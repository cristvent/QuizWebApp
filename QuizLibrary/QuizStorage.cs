using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizLibrary;

namespace QuizLibrary
{
    public class QuizStorage
    {
        public List<Quiz> _quizStorage = new List<Quiz>();
        int quizCounter = 0;

        public QuizStorage()
        {
            LoadQuizSample();
        }

        public List<Quiz> GetQuizAll()
        {
            return _quizStorage;
        }

        public Quiz GetQuizById(int id)
        {
            return _quizStorage.Find(quiz => quiz.Id == id);
        }

        public void AddQuiz(Quiz newQuiz)
        {
            newQuiz.Id = quizCounter++;
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
                Questions = new List<QuizQuestion>
                {
                   new QuizQuestion
                   {
                       Id = 0,
                       Content = "What is your name?",
                       Answers = new List<QuizAnswer>
                       {
                           new QuizAnswer {
                               Id = 0,
                               Content = "Wilmer",
                               IsCorrect = false
                           },
                           new QuizAnswer
                           {
                               Id = 1,
                              Content = "Bob",
                              IsCorrect = false
                           },
                           new QuizAnswer
                           {
                               Id = 2,
                               Content = "Ricky",
                               IsCorrect = false
                           },
                           new QuizAnswer
                           {
                               Id = 3,
                               Content = "Cristian",
                               IsCorrect = true
                           }
                       }
                   },

                   new QuizQuestion
                   {
                       Id = 1,
                       Content = "What state are we located in?",
                       Answers = new List<QuizAnswer>
                       {
                           new QuizAnswer {
                               Id = 0,
                               Content = "Florida",
                               IsCorrect = false
                           },
                           new QuizAnswer
                           {
                               Id = 1,
                              Content = "Kansas",
                              IsCorrect = false
                           },
                           new QuizAnswer
                           {
                               Id = 2,
                               Content = "Georgia",
                               IsCorrect = true
                           },
                           new QuizAnswer
                           {
                               Id = 3,
                               Content = "Texas",
                               IsCorrect = false
                           }
                       }
                   }
                }
            };
            AddQuiz(newQuiz);
        }


    }
}

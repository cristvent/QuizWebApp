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
            _quizStorage[id] = quizChanged;
        }

        public void LoadQuizSample()
        {
            Quiz newQuiz = new Quiz()
            {
                Title = "Objects and Classes",
                Topic = "Javascript",
                Active = false
            };

            Quiz newQuiz2 = new Quiz()
            {
                Title = "Evolution",
                Topic = "Biology",
                Active = true
            };

            AddQuiz(newQuiz);
            AddQuiz(newQuiz2);
        }

        
    }
}

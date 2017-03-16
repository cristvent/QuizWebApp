using System.Collections.Generic;

namespace QuizLibrary
{
    public interface IQuizStorage
    {
        void AddQuiz(Quiz newQuiz);
        void DeleteContent(int id);
        void EditQuiz(int id, Quiz quizChanged);
        List<Quiz> GetQuizAll();
        Quiz GetQuizById(int id);
    }
}
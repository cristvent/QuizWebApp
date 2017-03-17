using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QuizLibrary
{
    public class QuizStorageToDatabase : IQuizStorage
    {
        public void AddQuiz(Quiz newQuiz)
        {
            throw new NotImplementedException();
        }

        public void DeleteContent(int id)
        {
            throw new NotImplementedException();
        }

        public void EditQuiz(int id, Quiz quizNew)
        {
            using (var db = new QuizDbContext())
            {
                foreach (var item in quizNew.Questions)
                {
                    if (item.QuestionId == 0)
                    {
                        db.QuestionTable.Add(item);
                    }
                    else
                    {
                        foreach (var answer in item.Answers)
                        {
                            if (answer.AnswerId == 0)
                            {
                                db.AnswerTable.Add(answer);
                            }
                            else
                            {
                                db.Entry(answer).State = EntityState.Modified;
                            }
                        }
                        db.Entry(item).State = EntityState.Modified;
                    }
                }
                db.QuizTable.Attach(quizNew);
                db.Entry(quizNew).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<Quiz> GetQuizAll()
        {
            using (var db = new QuizDbContext())
            {
                var quizList = from quiz in db.QuizTable
                               select quiz;

                return quizList.ToList();
            }

        }

        public Quiz GetQuizById(int id)
        {
            using (var db = new QuizDbContext())
            {
                var quiz = db.QuizTable.Find(id);
                db.Entry(quiz).Collection(q => q.Questions).Load();
                foreach (var item in quiz.Questions)
                {
                    var question = db.QuestionTable.Find(item.QuestionId);
                    db.Entry(question).Collection(quest => quest.Answers).Load();
                }
                return quiz;
            }
        }
    }
}

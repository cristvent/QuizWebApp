using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizLibrary;

namespace QuizCli
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new QuizModel())
            {
                var list = from s in db.Questions
                               select s;

                foreach (var question in list)
                {
                    Console.WriteLine(question.QuestionId + " " + question.Content);
                }
            }
        }
    }
}

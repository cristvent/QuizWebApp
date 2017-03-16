using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QuizLibrary
{
    class QuizDbContext : DbContext
    {
        public DbSet<Quiz> QuizTable { get; set; }
        public DbSet<Question> QuestionTable { get; set; }
        public DbSet<Answer> AnswerTable { get; set; }
    }
}

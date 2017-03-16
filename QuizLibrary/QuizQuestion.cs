using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuizLibrary
{
    public class Question
    {
        [Required]
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
        public string Category { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public List<Answer> Answers { get; set; }
        public override string ToString()
        {
            return QuestionId + " " + Content;
        }
    }
}

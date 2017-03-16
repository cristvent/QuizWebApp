using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuizLibrary
{
    public class Quiz
    {
        [Required]
        public int QuizId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Topic { get; set; }
        public List<Question> Questions { get; set; }
        public bool Active { get; set; }

        public override string ToString()
        {
            return QuizId + " " + Title + " " + Topic;
        }
    }
}

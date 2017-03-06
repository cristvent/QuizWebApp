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
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Topic { get; set; }
        public List<QuizQuestion> Questions { get; set; }
        public bool Active { get; set; }

        public override string ToString()
        {
            return Id + " " + Title + " " + Topic;
        }
    }
}

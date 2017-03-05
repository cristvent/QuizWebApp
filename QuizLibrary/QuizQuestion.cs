using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuizLibrary
{
    public class QuizQuestion
    {
        [Required]
        public int Id { get; set; }
        public string Category { get; set; }
        [Required]
        public string Content { get; set; }
        //public string ImageUrl { get; set; }
        [Required]
        public List<QuizAnswer> Answers { get; set; }
        //public string MoreInfoUrl { get; set; }
        public string QuestionType { get; set; }
        //public string ReasonForAnswer { get; set; }

        public override string ToString()
        {
            return Id + " " + Content;
        }
    }
}

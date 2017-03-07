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
        [Required]
        public List<QuizAnswer> Answers { get; set; }
        public override string ToString()
        {
            return Id + " " + Content;
        }
    }
}

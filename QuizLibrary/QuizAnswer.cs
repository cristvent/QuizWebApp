using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLibrary
{
    public class QuizAnswer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
        [Required]
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Reason { get; set; }

        public override string ToString()
        {
            return Id + " " + Content + " " + IsCorrect;
        }

    }
}

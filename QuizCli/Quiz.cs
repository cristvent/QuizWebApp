namespace QuizCli
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quiz")]
    public partial class Quiz
    {
        public int QuizId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Topic { get; set; }

        public bool? Active { get; set; }
    }
}

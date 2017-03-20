using System.Collections.Generic;

namespace QuizLibrary
{
    public class QuestionViewModel
    {
        public QuestionViewModel()
        {
            Answers = new List<AnswerViewModel>();
        }
        public QuestionViewModel(Question question)
        {
            Answers = new List<AnswerViewModel>();

            QuestionId = question.QuestionId;
            Content = question.Content;

            foreach (var answer in question.Answers)
            {
                Answers.Add(new AnswerViewModel(answer));
            }

        }
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
    }
}

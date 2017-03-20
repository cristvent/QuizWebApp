
namespace QuizLibrary
{
    public class AnswerViewModel
    {
        public AnswerViewModel()
        {

        }
        public AnswerViewModel(Answer answer)
        {
            AnswerId = answer.AnswerId;
            QuestionId = answer.QuestionId;
            Content = answer.Content;
        }

        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; }
    }
}

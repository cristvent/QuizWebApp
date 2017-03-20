using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuizLibrary;

namespace QuizWebApp.Controllers
{
    public class QuizGameController : ApiController
    {
        public static IQuizStorage _quizStorage;

        public QuizGameController()
        {
            if (_quizStorage == null)
            {
                _quizStorage = new QuizStorageToDatabase();
                //_quizRepo.LoadSampleQuestions();
            }
        }

        public QuizGameController(IQuizStorage newStorage)
        {
            _quizStorage = newStorage;
        }

        // GET: api/QuizGame
        public IEnumerable<Quiz> Get()
        {
            return _quizStorage.GetQuizAll();
        }

        [Route("api/quizgame/isanswercorrect")]
        [HttpGet]
        public AnswerResults IsAnswerCorrect(int answerId)
        {
            var searchedAnswer = _quizStorage.GetAnswerById(answerId);
            AnswerResults returnResult = new AnswerResults();
            returnResult.IsCorrect = searchedAnswer.IsCorrect;
            return returnResult;
        }

        // GET: api/QuizGame/5
        public Quiz Get(int id)
        {
            return _quizStorage.GetQuizById(id);
        }

        // POST: api/QuizGame
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/QuizGame/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/QuizGame/5
        public void Delete(int id)
        {
        }
    }
}

using BackendLab01;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Controllers
{
    [Route("/api/v1/quizzes")]
    public class QuizController : Controller
    {
        private readonly IQuizUserService _quizUserService;

        public QuizController(IQuizUserService quizUserService)
        {
            _quizUserService = quizUserService;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDto> FindById(int id)
        {
            var quiz = _quizUserService.FindQuizById(id);

            if (quiz != null)
            {
                return Ok(QuizDto.Of(quiz));
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
        [Route("api/FindAll")]
        public IEnumerable<QuizDto> FindAll()
        {
            var quizzes = _quizUserService.GetAllQuizzes();
            var quizDtos = new List<QuizDto>();

            if (quizzes != null)
            {
                foreach (var quiz in quizzes)
                {
                    quizDtos.Add(QuizDto.Of(quiz));
                }
            }

            return quizDtos.ToArray();
        }


        [HttpPost]
        [Route("{quizId}/items/{itemId}")]
        public void SaveAnswer([FromBody] QuizItemAnswerDto dto, int quizId, int itemId)
        {
            _quizUserService.SaveUserAnswerForQuiz(quizId,dto.UserId,itemId,dto.Answer);
        }
    }
}

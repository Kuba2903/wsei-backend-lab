using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages.Quiz
{
    public class QuizzesModel : PageModel
    {
        private readonly IQuizUserService _userService;

        private readonly ILogger _logger;

        public List<BackendLab01.Quiz> Quizzes { get; set; }

        public QuizzesModel(IQuizUserService service, ILogger<QuizModel> logger)
        {
            this._userService = service;
            this._logger = logger;
        }

        public void OnGet(int id)
        {
            Quizzes = _userService.GetAllQuizzes().ToList();
        }
    }
}

using BackendLab01;

namespace WebApi.Dto
{
    public class QuizItemDto
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public List<string> Options { get; set; }


        public static QuizItemDto Of(QuizItem item)
        {
            var options = new List<string>();
            options.AddRange(item.IncorrectAnswers);
            options.Add(item.CorrectAnswer);
            return new QuizItemDto
            {
                Id = item.Id,
                Question = item.Question,
                Options = options
            };
        }
    }
}

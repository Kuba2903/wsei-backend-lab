using BackendLab01;

namespace WebApi.Dto
{
    public class QuizDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<QuizItemDto> Items { get; set; }

        public static QuizDto Of(Quiz item)
        {
            var itemDtos = new List<QuizItemDto>();
            foreach (var quizItem in item.Items)
            {
                itemDtos.Add(QuizItemDto.Of(quizItem));
            }

            return new QuizDto
            {
                Id = item.Id,
                Title = item.Title,
                Items = itemDtos
            };
        }
    }
}

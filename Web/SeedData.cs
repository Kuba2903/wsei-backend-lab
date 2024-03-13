using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();

            List<QuizItem> questions1 = new List<QuizItem>();
            List<QuizItem> questions2 = new List<QuizItem>();


            var quizItem0 = new QuizItem(1, "Stolica Polski", new List<string> {"Bonn","Moskwa","Bruksela"}, "Warszawa");
            var quizItem1 = new QuizItem(2, "Stolica Belgii", new List<string> {"Paryż","Waszyngton","Montreal" }, "Bruksela");
            var quizItem2 = new QuizItem(3, "Stolica Malty", new List<string> { "Oslo","Prisztina","Jekaterynburg"}, "Valetta");
            var quizItem3 = new QuizItem(1, "Stolica Islandii", new List<string> { "Thorshavn","Kopenhaga","Sztokholm"}, "Rejkjawik");
            var quizItem4 = new QuizItem(2, "Stolica Bośni", new List<string> { "Belgrad","Podgorica","Kiszyniów"}, "Sarajewo");
            var quizItem5 = new QuizItem(3, "Stolica Rosji", new List<string> {"Monako","Kijów","Bukareszt" }, "Moskwa");

            questions1.Add(quizItem0);
            questions1.Add(quizItem1);
            questions1.Add(quizItem2);

            questions2.Add(quizItem3);
            questions2.Add(quizItem4);
            questions2.Add(quizItem5);

            var quiz1 = new Quiz(1, questions1, "title1");
            var quiz2 = new Quiz(2, questions2, "title2");

            quizRepo.Add(quiz1);
            quizRepo.Add(quiz2);

            quizItemRepo.Add(quizItem0);
            quizItemRepo.Add(quizItem1);
            quizItemRepo.Add(quizItem2);
            quizItemRepo.Add(quizItem3);
            quizItemRepo.Add(quizItem4);
            quizItemRepo.Add(quizItem5);
        }
    }
}
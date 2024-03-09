using ApplicationCore.Interfaces.Repository;
using BackendLab01;
using Infrastructure.Memory.Repository;

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
        }
    }


    public static IGenericRepository<Quiz,int> GetQuiz()
    {
        var quizRepository = new MemoryGenericRepository<Quiz, int>(new IntGenerator());

        var itemRepository0 = new MemoryGenericRepository<QuizItem, int>(new IntGenerator());
        var itemRepository1 = new MemoryGenericRepository<QuizItem, int>(new IntGenerator());



        var _aservice0 = new QuizAdminService(quizRepository, itemRepository0);
        var _aservice1 = new QuizAdminService(quizRepository, itemRepository1);
        

        _aservice0.AddQuizItem("Jaki kolor ma czerwony maluch?", new List<string> { "seledynowy","żółty","beżowy" }, "czerwony", 1);
        _aservice0.AddQuizItem("Ile łap ma pies?", new List<string> { "0","5","10" }, "4", 1);
        _aservice0.AddQuizItem("Stolicą którego kraju jest Moskwa?", new List<string> { "Czechy","Polska","Białoruś" }, "Rosja", 2);

        _aservice1.AddQuizItem("Stolicą którego kraju jest Warszawa?", new List<string> { "Słowacja", "Niemcy", "USA" }, "Polska", 1);
        _aservice1.AddQuizItem("Stolicą którego kraju jest Prisztina?", new List<string> { "Kanada", "Turkmenistan", "Nigeria" }, "Kosowo", 1);
        _aservice1.AddQuizItem("Stolicą którego kraju jest Valetta?", new List<string> { "San Marino", "Wyspy Owcze", "Monako" }, "Malta", 3);
        

        Quiz quiz0 = _aservice0.AddQuiz("quiz",_aservice0.FindAllQuizItems());
        Quiz quiz1 = _aservice1.AddQuiz("stolice", _aservice1.FindAllQuizItems());

        quizRepository.Add(quiz0);
        quizRepository.Add(quiz1);

        return quizRepository;
    } 
}
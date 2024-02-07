using quiz.Dtos;
using quiz.Repositories;

namespace quiz.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<IEnumerable<QuestionDto>> GetAll()
        {
            var questionsFromDb = _questionRepository.GetAll();

            return questionsFromDb.Select(it => new QuestionDto(it));
        }
    }
}

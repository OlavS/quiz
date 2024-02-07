using quiz.Dtos;

namespace quiz.Services
{
    public interface IQuestionService
    {
        public Task<IEnumerable<QuestionDto>> GetAll();
    }
}

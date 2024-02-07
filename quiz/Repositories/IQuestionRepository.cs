using quiz.Repositories.Models;

namespace quiz.Repositories
{
    public interface IQuestionRepository
    {
        public IEnumerable<QuestionModel> GetAll();
    }
}

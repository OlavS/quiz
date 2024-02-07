using Microsoft.EntityFrameworkCore;
using quiz.Core;
using quiz.Repositories.Models;

namespace quiz.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuizDbContext _context;

        public QuestionRepository(QuizDbContext context)
        {
            _context = context;
        }

        public IEnumerable<QuestionModel> GetAll()
        {
            return _context.Questions.Include(x => x.Alternatives);
        }
    }
}

using quiz.Repositories.Models;
using System.Security;

namespace quiz.Dtos
{
    public class QuestionDto
    {
        public QuestionDto(QuestionModel question)
        {
            Question = question.Question;
            Alternatives = question.Alternatives.Select(it => new AlternativeDto(it));
        }

        public string Question { get; set; }

        public IEnumerable<AlternativeDto> Alternatives { get; set; }
    }
}

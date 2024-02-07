using quiz.Repositories.Models;

namespace quiz.Dtos
{
    public class AlternativeDto
    {
        public AlternativeDto(AlternativeModel alternative)
        {
            Alternative = alternative.Alternative;
            CorrectAnswer = alternative.CorrectAnswer;
        }

        public string Alternative { get; set; }

        public bool CorrectAnswer { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace quiz.Repositories.Models
{
    [Table("Alternative")]
    public class AlternativeModel : Entity
    {
        public string Alternative { get; set; }

        public bool CorrectAnswer { get; set; }

        public int QuestionId { get; set; }

        public QuestionModel Question { get; set; }
    }
}

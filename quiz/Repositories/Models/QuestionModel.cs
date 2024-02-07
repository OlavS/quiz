using System.ComponentModel.DataAnnotations.Schema;

namespace quiz.Repositories.Models
{
    [Table("Question")]
    public class QuestionModel : Entity
    {
        public string Question { get; set; }

        public IEnumerable<AlternativeModel> Alternatives { get; set; } 
    }
}

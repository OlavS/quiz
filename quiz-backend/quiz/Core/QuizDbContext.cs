using Microsoft.EntityFrameworkCore;
using quiz.Repositories.Models;

namespace quiz.Core
{
    public class QuizDbContext : DbContext
    {
        public DbSet<AlternativeModel> Alternatives { get; set; }

        public DbSet<QuestionModel> Questions { get; set; }

        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuestionModel>()
                .HasMany(x => x.Alternatives)
                .WithOne(x => x.Question)
                .HasForeignKey(x => x.QuestionId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

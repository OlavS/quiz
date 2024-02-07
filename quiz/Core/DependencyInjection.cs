using Microsoft.EntityFrameworkCore;
using quiz.Repositories;
using quiz.Services;

namespace quiz.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IQuestionService, QuestionService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<QuizDbContext>(options =>
                options.UseSqlServer("Server=localhost\\MSSQLSERVER02;Database=master;Trusted_Connection=True;")
            );
            return services;
        }
    }
}

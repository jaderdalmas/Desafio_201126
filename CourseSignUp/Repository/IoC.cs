using Microsoft.Extensions.DependencyInjection;

namespace CourseSignUp.Repository
{
  public static class IoC
  {
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
      services.AddSingleton<ICourseRepository, CourseRepository>();
      services.AddSingleton<ILectureRepository, LectureRepository>();
      services.AddSingleton<IStudentRepository, StudentRepository>();

      return services;
    }
  }
}

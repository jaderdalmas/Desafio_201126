using Microsoft.Extensions.DependencyInjection;

namespace CourseSignUp.Service
{
  public static class IoC
  {
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
      services.AddSingleton<IEmailService, MockEmailService>();
      services.AddSingleton<ISignUpService, SignUpService>();

      return services;
    }
  }
}

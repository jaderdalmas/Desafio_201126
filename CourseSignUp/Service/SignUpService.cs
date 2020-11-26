using CourseSignUp.Extension;
using CourseSignUp.Handler;
using CourseSignUp.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CourseSignUp.Service
{
  public class SignUpService : ISignUpService
  {
    readonly ILogger _logger;

    readonly IEmailService _emailService;
    readonly IStatisticsService _statisticsService;

    readonly ICourseRepository _courseRepository;
    readonly IStudentRepository _studentRepository;

    public SignUpService(ILogger<SignUpService> logger, IEmailService emailService, IStatisticsService statisticsService, ICourseRepository courseRepository, IStudentRepository studentRepository)
    {
      _logger = logger;

      _emailService = emailService;
      _statisticsService = statisticsService;

      _courseRepository = courseRepository;
      _studentRepository = studentRepository;

      EventBus.Instance.Register(this);
    }

    public void Dispose()
    {
      EventBus.Instance.Unregister(this);
    }

    public Task<string> OnEvent(SignUpEvent signUp)
    {
      return SignUp(signUp.CourseId, signUp.Email, signUp.Name, signUp.DateOfBirth);
    }

    public async Task<string> SignUp(string courseId, string email, string name, DateTime doB)
    {
      var result = await _courseRepository.SingUp(courseId).ConfigureAwait(false);

      try
      {
        _ = await _emailService.SendSignUpEmail(email, result).ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Couldn't send SingUp Email");
      }

      if (!result) return string.Empty;

      _ = await _statisticsService.Add(courseId, doB.GetAge()).ConfigureAwait(false);
      return await _studentRepository.Add(courseId, email, name, doB).ConfigureAwait(false);
    }
  }
}

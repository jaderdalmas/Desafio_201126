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

    readonly ICourseRepository _courseRepository;
    readonly IStudentRepository _studentRepository;

    public SignUpService(ILogger<SignUpService> logger, IEmailService emailService, ICourseRepository courseRepository, IStudentRepository studentRepository)
    {
      _logger = logger;

      _emailService = emailService;

      _courseRepository = courseRepository;
      _studentRepository = studentRepository;
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

      return await _studentRepository.Add(courseId, email, name, doB).ConfigureAwait(false);
    }
  }
}

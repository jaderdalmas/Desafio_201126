using System.Threading.Tasks;

namespace CourseSignUp.Service
{
  public interface IEmailService
  {
    Task<bool> SendSignUpEmail(string email, bool success = true);
  }
}

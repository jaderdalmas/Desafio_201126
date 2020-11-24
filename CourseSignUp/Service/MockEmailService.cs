using System.Threading.Tasks;

namespace CourseSignUp.Service
{
  public class MockEmailService : IEmailService
  {
    public Task<bool> SendSignUpEmail(string email, bool success = true) => Task.FromResult(true);
  }
}

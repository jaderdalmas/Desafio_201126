using CourseSignUp.Handler;
using System;
using System.Threading.Tasks;

namespace CourseSignUp.Service
{
  public interface ISignUpService : IDisposable
  {
    Task<string> OnEvent(SignUpEvent signUp);

    Task<string> SignUp(string courseId, string email, string name, DateTime doB);
  }
}

using System;
using System.Threading.Tasks;

namespace CourseSignUp.Service
{
  public interface ISignUpService
  {
    Task<string> SignUp(string courseId, string email, string name, DateTime doB);
  }
}

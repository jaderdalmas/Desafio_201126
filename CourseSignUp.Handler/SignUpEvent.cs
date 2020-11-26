using System;

namespace CourseSignUp.Handler
{
  public class SignUpEvent
  {
    public string CourseId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
  }
}

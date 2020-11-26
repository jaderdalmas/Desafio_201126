using CourseSignUp.Handler;
using System;

namespace CourseSignUp.Api.Courses
{
  public class SignUpToCourseDto
  {
    public string CourseId { get; set; }
    public StudentDto Student { get; set; }

    public class StudentDto
    {
      public string Email { get; set; }
      public string Name { get; set; }
      public DateTime DateOfBirth { get; set; }
    }

    public SignUpEvent GetEvent()
    {
      return new SignUpEvent() { 
        CourseId = CourseId,
        Email = Student.Email,
        Name = Student.Name,
        DateOfBirth = Student.DateOfBirth,
      };
    }
  }
}
using System;

namespace CourseSignUp.Model
{
  public class Student
  {
    public Student() { }

    public Student(string courseId, string email, string name, DateTime dateOfBirth)
    {
      Id = Guid.NewGuid().ToString();
      CourseId = courseId;
      Email = email;
      Name = name;
      DateOfBirth = dateOfBirth;
    }

    public string Id { get; set; }
    public string CourseId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
  }
}

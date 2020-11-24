using System;

namespace CourseSignUp.Model
{
  public class Lecture
  {
    public Lecture() { }

    public Lecture(string name)
    {
      Id = Guid.NewGuid().ToString();
      Name = name;
    }

    public string Id { get; set; }
    public string Name { get; set; }
  }
}

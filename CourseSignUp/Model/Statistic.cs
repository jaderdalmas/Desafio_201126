using System.Collections.Generic;

namespace CourseSignUp.Model
{
  public class Statistic
  {
    public Statistic() { }

    public Statistic(string courseId, string name, int age)
    {
      CourseId = courseId;
      CourseName = name;
      Avg = new List<int>() { age };
    }

    public string CourseId { get; set; }
    public string CourseName { get; set; }
    public IList<int> Avg { get; set; }
  }
}

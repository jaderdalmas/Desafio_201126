using System.Linq;

namespace CourseSignUp.Model
{
  public class CourseStatistic
  {
    public CourseStatistic() { }

    public CourseStatistic(string courseId, decimal avg, int min, int max, string name = "")
    {
      CourseId = courseId;
      CourseName = name;
      Avg = avg;
      Min = min;
      Max = max;
    }

    public CourseStatistic(Statistic statistic)
    {
      CourseId = statistic.CourseId;
      CourseName = statistic.CourseName;
      Min = statistic.Avg.Min();
      Max = statistic.Avg.Max();
      Avg = (decimal)statistic.Avg.Average();
    }

    public string CourseId { get; set; }
    public string CourseName { get; set; }
    public decimal Avg { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
  }
}

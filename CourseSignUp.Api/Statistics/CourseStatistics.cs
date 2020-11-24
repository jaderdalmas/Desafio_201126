using CourseSignUp.Model;

namespace CourseSignUp.Api.Statistics
{
  public class CourseStatistics
  {
    public CourseStatistics() { }

    public CourseStatistics(StudentStatistic statistic)
    {
      Id = statistic.CourseId;
      MinimumAge = statistic.Min;
      MaximumAge = statistic.Max;
      AverageAge = statistic.Avg;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public int MinimumAge { get; set; }
    public int MaximumAge { get; set; }
    public decimal AverageAge { get; set; }
  }
}
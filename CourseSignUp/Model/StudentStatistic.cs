namespace CourseSignUp.Model
{
  public class StudentStatistic
  {
    public StudentStatistic() { }

    public StudentStatistic(string courseId, decimal avg, int min, int max)
    {
      CourseId = courseId;
      Avg = avg;
      Min = min;
      Max = max;
    }

    public string CourseId { get; set; }
    public decimal Avg { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
  }
}

using CourseSignUp.Model;
using System.Text.Json.Serialization;

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

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("minimumAge")]
    public int MinimumAge { get; set; }

    [JsonPropertyName("maximumAge")]
    public int MaximumAge { get; set; }

    [JsonPropertyName("averageAge")]
    public decimal AverageAge { get; set; }
  }
}
using CourseSignUp.Model;
using System.Text.Json.Serialization;

namespace CourseSignUp.Api.Courses
{
  public class CourseDto
  {
    public CourseDto() { }

    public CourseDto(Course course)
    {
      Id = course.Id;
      Capacity = course.Capacity;
      NumberOfStudents = course.NumberOfStudents;
    }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("capacity")]
    public int Capacity { get; set; }

    [JsonPropertyName("numberOfStudents")]
    public int NumberOfStudents { get; set; }
  }
}
using CourseSignUp.Model;

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

    public string Id { get; set; }
    public int Capacity { get; set; }
    public int NumberOfStudents { get; set; }
  }
}
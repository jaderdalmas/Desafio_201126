using System;

namespace CourseSignUp.Model
{
  public class Course
  {
    public Course() { }

    public Course(string lectureId, string name, int capacity)
    {
      Id = Guid.NewGuid().ToString();
      LectureId = lectureId;
      Name = name;
      Capacity = capacity;
      NumberOfStudents = 0;
    }

    public string Id { get; set; }
    public string LectureId { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public int NumberOfStudents { get; set; }
  }
}

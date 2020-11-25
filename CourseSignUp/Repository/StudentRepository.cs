using CourseSignUp.Extension;
using CourseSignUp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSignUp.Repository
{
  public class StudentRepository : IStudentRepository
  {
    readonly IList<Student> db;

    public StudentRepository()
    {
      db = new List<Student>();
    }

    public Task<string> Add(string courseId, string email, string name, DateTime dateOfBirth) => Add(new Student(courseId, email, name, dateOfBirth));

    public Task<string> Add(Student student)
    {
      if (string.IsNullOrWhiteSpace(student.Email))
        return Task.FromResult(string.Empty);

      db.Add(student);
      return Task.FromResult(student.Id);
    }

    public Task<IList<CourseStatistic>> GetStatistic()
    {
      var groups = db.GroupBy(x => x.CourseId);

      IList<CourseStatistic> list = new List<CourseStatistic>();
      foreach (var group in groups)
      {
        var result = group.Select(x => x.DateOfBirth.GetAge());

        var avg = result.Average();
        var min = result.Min();
        var max = result.Max();

        list.Add(new CourseStatistic(group.Key, (decimal)avg, min, max));
      }

      return Task.FromResult(list);
    }
  }
}

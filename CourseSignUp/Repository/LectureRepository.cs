using CourseSignUp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignUp.Repository
{
  public class LectureRepository : ILectureRepository
  {
    readonly IList<Lecture> db;

    public LectureRepository()
    {
      db = new List<Lecture>();
    }

    public Task<string> Add(string name) => Add(new Lecture(name));

    public Task<string> Add(Lecture lecture)
    {
      if (string.IsNullOrWhiteSpace(lecture.Name))
        return Task.FromResult(string.Empty);

      db.Add(lecture);
      return Task.FromResult(lecture.Id);
    }
  }
}

using CourseSignUp.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSignUp.Repository
{
  public class StatisticRepository : IStatisticRepository
  {
    readonly Dictionary<string, Statistic> db;

    public StatisticRepository()
    {
      db = new Dictionary<string, Statistic>();
    }

    public Task<bool> Add(Course course, int age)
    {
      if (db.ContainsKey(course.Id))
        return Add(course.Id, age);

      db.Add(course.Id, new Statistic(course.Id, course.Name, age));
      return Task.FromResult(true);
    }

    public Task<bool> Add(string id, int age)
    {
      if (!db.ContainsKey(id))
        Task.FromResult(false);

      db[id].Avg.Add(age);
      return Task.FromResult(true);
    }

    public Task<bool> Exists(string id)
    {
      return Task.FromResult(db.ContainsKey(id));
    }

    public Task<IEnumerable<Statistic>> GetAll()
    {
      return Task.FromResult(db.Select(x => x.Value));
    }
  }
}

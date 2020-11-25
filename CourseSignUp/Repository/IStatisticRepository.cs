using CourseSignUp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignUp.Repository
{
  public interface IStatisticRepository
  {
    Task<bool> Add(Course course, int age);

    Task<bool> Add(string id, int age);

    Task<bool> Exists(string id);

    Task<IEnumerable<Statistic>> GetAll();
  }
}

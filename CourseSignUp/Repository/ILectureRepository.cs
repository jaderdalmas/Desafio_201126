using CourseSignUp.Model;
using System.Threading.Tasks;

namespace CourseSignUp.Repository
{
  public interface ILectureRepository
  {
    Task<string> Add(string name);

    Task<string> Add(Lecture lecture);
  }
}

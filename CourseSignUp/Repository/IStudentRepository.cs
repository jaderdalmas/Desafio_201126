using CourseSignUp.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignUp.Repository
{
  public interface
    IStudentRepository
  {
    Task<string> Add(string courseId, string email, string name, DateTime dateOfBirth);

    Task<string> Add(Student student);

    Task<IList<StudentStatistic>> GetStatistic();
  }
}

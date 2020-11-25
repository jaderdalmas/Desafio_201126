using CourseSignUp.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignUp.Service
{
  public interface IStatisticsService
  {
    Task<bool> Add(string courseId, int age);

    Task<IEnumerable<CourseStatistic>> GetCacheStatistic();
    Task<IEnumerable<CourseStatistic>> GetStatistic();
  }
}

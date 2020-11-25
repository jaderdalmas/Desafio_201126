using API.Extension;
using CourseSignUp.Api;
using CourseSignUp.Api.Courses;
using CourseSignUp.Api.Lecturers;
using CourseSignUp.Api.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using static CourseSignUp.Api.Courses.SignUpToCourseDto;

namespace IntegrationTest.Lecturers
{
  public class StatisticsControllerTest : IClassFixture<TestApplicationFactory<Startup>>
  {
    private readonly TestApplicationFactory<Startup> _factory;
    public static string GetUrl => "Statistics";

    public StatisticsControllerTest(TestApplicationFactory<Startup> factory)
    {
      _factory = factory;
    }

    [Fact]
    public async Task Get()
    {
      // Arrange
      var client = _factory.CreateClient();

      var lecture = new CreateLecturerDto()
      {
        Name = "Lecture"
      };
      var lectureResponse = await client.PostAsync(LecturersControllerTest.PostUrl, lecture.AsContent());
      var lectureId = await lectureResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

      var course = new CreateCourseDto()
      {
        LecturerId = lectureId,
        Name = "Course",
        Capacity = 10
      };
      var courseResponse = await client.PostAsync(CoursesControllerTest.PostUrl, course.AsContent());
      var courseId = await courseResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

      var signUp = new SignUpToCourseDto()
      {
        CourseId = courseId,
        Student = new StudentDto()
        {
          Name = "Student",
          Email = "teste@test.com",
          DateOfBirth = DateTime.Now.AddYears(-28)
        }
      };
      _ = await client.PostAsync(CoursesControllerTest.SignUpUrl, signUp.AsContent());

      // Act
      var response = await client.GetAsync(GetUrl);

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      Assert.NotEmpty(result);

      var item = JsonSerializer.Deserialize<IEnumerable<CourseStatistics>>(result);
      Assert.NotEmpty(item);
      Assert.Equal(course.Name, item.First().Name);
      Assert.Equal(item.First().MaximumAge, item.First().MinimumAge);
    }
  }
}

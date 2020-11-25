using API.Extension;
using CourseSignUp.Api;
using CourseSignUp.Api.Courses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using static CourseSignUp.Api.Courses.SignUpToCourseDto;

namespace IntegrationTest.Lecturers
{
  public class CoursesControllerTest : IClassFixture<TestApplicationFactory<Startup>>
  {
    private readonly TestApplicationFactory<Startup> _factory;
    public static string GetUrl => "Courses";
    public static string PostUrl => "Courses/create";
    public static string SignUpUrl => "Courses/sign-up";

    public CoursesControllerTest(TestApplicationFactory<Startup> factory)
    {
      _factory = factory;
    }

    [Fact]
    public async Task Get_NotFound()
    {
      // Arrange
      var client = _factory.CreateClient();

      // Act
      var response = await client.GetAsync(GetUrl);

      // Assert
      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

      var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      Assert.Empty(result);
    }

    [Fact]
    public async Task Get()
    {
      // Arrange
      var client = _factory.CreateClient();
      var course = new CreateCourseDto()
      {
        Name = "Teste"
      };
      var courseResponse = await client.PostAsync(PostUrl, course.AsContent());
      var courseId = await courseResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

      // Act
      var response = await client.GetAsync($"{GetUrl}/{courseId}");

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      Assert.NotEmpty(result);

      var item = JsonSerializer.Deserialize<CourseDto>(result);
      Assert.NotNull(item);
      Assert.Equal(courseId, item.Id);
    }

    [Fact]
    public async Task Post_Null()
    {
      // Arrange
      var client = _factory.CreateClient();
      CreateCourseDto course = null;

      // Act
      var response = await client.PostAsync(PostUrl, course.AsContent());

      // Assert
      Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

      var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      Assert.NotEmpty(result);

      var item = JsonSerializer.Deserialize<ProblemDetails>(result);
      Assert.NotEmpty(item.Title);
      Assert.NotEmpty(item.Type);
      Assert.NotEmpty(item.Extensions);
    }

    [Fact]
    public async Task Post_BadRequest()
    {
      // Arrange
      var client = _factory.CreateClient();
      var course = new CreateCourseDto();

      // Act
      var response = await client.PostAsync(PostUrl, course.AsContent());

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      Assert.Empty(result);
    }

    [Fact]
    public async Task Post_Empty()
    {
      // Arrange
      var client = _factory.CreateClient();
      var course = new CreateCourseDto()
      {
        Name = string.Empty
      };

      // Act
      var response = await client.PostAsync(PostUrl, course.AsContent());

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      Assert.Empty(result);
    }

    [Fact]
    public async Task Post()
    {
      // Arrange
      var client = _factory.CreateClient();
      var course = new CreateCourseDto()
      {
        Name = "Teste"
      };

      // Act
      var response = await client.PostAsync(PostUrl, course.AsContent());

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      Assert.NotEmpty(result);

      Assert.True(Guid.TryParse(result, out Guid id));
      Assert.NotEqual(Guid.Empty, id);
    }

    [Fact]
    public async Task SignUp_Null()
    {
      // Arrange
      var client = _factory.CreateClient();
      SignUpToCourseDto signUp = null;

      // Act
      var response = await client.PostAsync(SignUpUrl, signUp.AsContent());

      // Assert
      Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

      var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      Assert.NotEmpty(result);

      var item = JsonSerializer.Deserialize<ProblemDetails>(result);
      Assert.NotEmpty(item.Title);
      Assert.NotEmpty(item.Type);
      Assert.NotEmpty(item.Extensions);
    }

    [Fact]
    public async Task SignUp_NoContent()
    {
      // Arrange
      var client = _factory.CreateClient();
      var signUp = new SignUpToCourseDto();

      // Act
      var response = await client.PostAsync(SignUpUrl, signUp.AsContent());

      // Assert
      Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

      var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      Assert.Empty(result);
    }

    [Fact]
    public async Task SignUp_Empty()
    {
      // Arrange
      var client = _factory.CreateClient();
      var signUp = new SignUpToCourseDto()
      {
        Student = new StudentDto()
        {
          Name = string.Empty,
          Email = string.Empty
        }
      };

      // Act
      var response = await client.PostAsync(PostUrl, signUp.AsContent());

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      Assert.Empty(result);
    }

    [Fact]
    public async Task SignUp()
    {
      // Arrange
      var client = _factory.CreateClient();
      var course = new CreateCourseDto()
      {
        Name = "Teste",
        Capacity = 10
      };
      var courseResponse = await client.PostAsync(PostUrl, course.AsContent());
      var courseId = await courseResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

      var signUp = new SignUpToCourseDto()
      {
        CourseId = courseId,
        Student = new StudentDto()
        {
          Name = "Teste",
          Email = "teste@test.com",
          DateOfBirth = DateTime.Now.AddYears(-28)
        }
      };

      // Act
      var response = await client.PostAsync(SignUpUrl, signUp.AsContent());

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      Assert.NotEmpty(result);

      Assert.True(Guid.TryParse(result, out Guid id));
      Assert.NotEqual(Guid.Empty, id);
    }
  }
}

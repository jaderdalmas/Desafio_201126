using API.Extension;
using CourseSignUp.Api;
using CourseSignUp.Api.Lecturers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest.Lecturers
{
  public class LecturersControllerTest : IClassFixture<TestApplicationFactory<Startup>>
  {
    private readonly TestApplicationFactory<Startup> _factory;
    private string PostUrl => "Lecturers/create";

    public LecturersControllerTest(TestApplicationFactory<Startup> factory)
    {
      _factory = factory;
    }

    [Fact]
    public async Task Post_Null()
    {
      // Arrange
      var client = _factory.CreateClient();
      CreateLecturerDto lecture = null;

      // Act
      var response = await client.PostAsync(PostUrl, lecture.AsContent());

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
      var lecture = new CreateLecturerDto();

      // Act
      var response = await client.PostAsync(PostUrl, lecture.AsContent());

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
      var lecture = new CreateLecturerDto()
      {
        Name = string.Empty
      };

      // Act
      var response = await client.PostAsync(PostUrl, lecture.AsContent());

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
      var lecture = new CreateLecturerDto()
      {
        Name = "Teste"
      };

      // Act
      var response = await client.PostAsync(PostUrl, lecture.AsContent());

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      Assert.NotEmpty(result);

      Assert.True(Guid.TryParse(result, out Guid id));
      Assert.NotEqual(Guid.Empty, id);
    }
  }
}

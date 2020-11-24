using CourseSignUp.Extension;
using System;
using Xunit;

namespace UnitTest.Extension
{
  public class DoBExtensionTest
  {
    [Fact]
    public void GetAge_BirthDay()
    {
      // Arrange
      var age = 30;
      var date = DateTime.Now.AddYears(-age);

      // Act
      var result = date.GetAge();

      // Assert
      Assert.Equal(age, result);
    }

    [Fact]
    public void GetAge_BirthDayMinus()
    {
      // Arrange
      var age = 30;
      var date = DateTime.Now.AddYears(-age).AddDays(-1);

      // Act
      var result = date.GetAge();

      // Assert
      Assert.Equal(age, result);
    }

    [Fact]
    public void GetAge_BirthDayPlus()
    {
      // Arrange
      var age = 30;
      var date = DateTime.Now.AddYears(-age).AddDays(+1);

      // Act
      var result = date.GetAge();

      // Assert
      Assert.Equal(age - 1, result);
    }
  }
}

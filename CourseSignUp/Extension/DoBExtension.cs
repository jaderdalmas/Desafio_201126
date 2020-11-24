using System;

namespace CourseSignUp.Extension
{
  public static class DoBExtension
  {
    public static int GetAge(this DateTime dob)
    {
      int age = DateTime.Now.Year - dob.Year;

      if (dob.Date > DateTime.Now.AddYears(-age))
        age--;

      return age;
    }
  }
}

using System;

namespace Program_to_check_Strength_of_Password
{
  // https://www.geeksforgeeks.org/program-check-strength-password/
  class Program
  {
    static void Main(string[] args)
    {
      Program p = new Program();
      string password = "gfg!@12"; // gfg!@12 // GeeksforGeeks!@12
      var result = p.ReturnPasswordStrength(password);
      Console.WriteLine(result);
    }

    /*
      It contains at least one lowercase English character.
      It contains at least one uppercase English character.
      It contains at least one special character. The special characters are: !@#$%^&*()-+
      Its length is at least 8.
      It contains at least one digit.
     */

    // Given a string, find its strength. Let a strong password is one that satisfies all above conditions.
    // A moderate password is one that satisfies first three conditions and has length at least 6.
    // Otherwise password is Weak.

    string ReturnPasswordStrength(string password)
    {
      if (string.IsNullOrWhiteSpace(password)) return "Weak";
      var (satisfiedFirstThreeCases, containsSpecial) = SatisfiedFirstThreeCasesAndContainsAtLeastOneDigit(password);
      if (satisfiedFirstThreeCases && password.Length >= 8 && containsSpecial) return "Strong";
      else if (satisfiedFirstThreeCases && password.Length >= 6) return "Moderate";
      else return "Weak";
    }

    (bool, bool) SatisfiedFirstThreeCasesAndContainsAtLeastOneDigit(string password)
    {
      const string special = "!@#$%^&*()-+";
      bool containsLower = false, containsUpper = false, containsSpecial = false, containsDigit = false;
      bool satisfiedFirstThreeCases = false;
      foreach (char c in password)
      {
        if (!containsLower && char.IsLower(c)) containsLower = true;
        if (!containsUpper && char.IsUpper(c)) containsUpper = true;
        if (!containsDigit && char.IsDigit(c)) containsDigit = true;
        if (!containsSpecial && !char.IsLetterOrDigit(c) && special.Contains(c)) containsSpecial = true;
        if (containsLower && containsUpper && containsDigit) satisfiedFirstThreeCases = true;
        if (satisfiedFirstThreeCases && containsSpecial) break;
      }
      return (satisfiedFirstThreeCases, containsSpecial);
    }
  }
}

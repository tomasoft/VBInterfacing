namespace VBInterfacing.Console;

using DAL;
using Models;
using VBUserValidator;
using System;

internal class Program
{
    private static void Main()
    {
        PerformUserValidation();
    }

    private static void PerformUserValidation()
    {
        // This is a valid user
        var dbUser = GetDbUser("TomStefanou");
        // This validator requires a non empty username and password
        ValidateUser(dbUser, UserValidator.BaseValidator);
        
        dbUser = GetDbUser("TomStefanou1");
        // This validator requires a non empty username and password
        // and password length of at least 8 characters long
        ValidateUser(dbUser, UserValidator.DbValidator);

        Console.Write("Press any key to exit...");
        Console.ReadKey();
    }

    private static void ValidateUser(User dbUser, UserValidator validator)
    {
        var userValidator = validator == UserValidator.BaseValidator ? (_IUserValidator) new UserValidatorBaseClass() : new DbUserValidatorClass();

        //Randomly fail the password validation by emptying the password
        dbUser.Password = new Random().NextDouble() > 0.5 ? dbUser.Password : string.Empty;

        var isUserValid = userValidator.IsUserValid(dbUser.Username, dbUser.Password);

        Console.WriteLine(isUserValid
            ? $"{validator} User {dbUser.Username} is valid, Phone is {dbUser.Phone}."
            : $"{validator} User {dbUser.Username} is invalid.");
    }

    private static User GetDbUser(string userName)
    {
        using var context = new UserContext();

        var dbUser = context.Users?.FirstOrDefault(o => o.Username.Equals(userName));

        if (dbUser != null) return dbUser;
        
        Console.Write($"User {userName} was not found in the database.\nPress any key to exit...");
        Console.ReadKey();
        
        return new User();
    }
}
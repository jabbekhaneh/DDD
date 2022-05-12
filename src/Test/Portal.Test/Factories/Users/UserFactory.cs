using Portal.Domain.Users;
using Portal.EF;
using System;

namespace Portal.Test.Factories;

public static class UserFactory
{
    public static User GenerateUser(EFdbApplication context, string mobile)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Mobile = mobile,
            Firstname ="dummy-dirstname",
            Lastname =  "dummy-lastname",
            Email  ="dummy-mail@mail.com",
            DateOfBirth=DateTime.Now,
            LastActivityDateUtc=DateTime.Now,
            LastLoginDateUtc=DateTime.Now,
            Geneder =GenederType.Female,
            Wallet=0,
            CreatedOnUtc=DateTime.Now,
           
        };
        context.Users.Add(user);
        return user;
    }
}

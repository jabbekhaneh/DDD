using Portal.Application.Users.Commands.AddUser;
using Portal.Application.Users.Commands.EditUser;
using Portal.Domain.Users;
using Portal.EF;
using System;

namespace Portal.Test.Factories;

public static class UserFactory
{
    public static User GenerateUser(EFdbApplication context, string mobile, Guid roleId)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Mobile = mobile,
            Firstname = "dummy-dirstname",
            Lastname = "dummy-lastname",
            Email = "dummy-mail@mail.com",
            DateOfBirth = DateTime.Now,
            LastActivityDateUtc = DateTime.Now,
            LastLoginDateUtc = DateTime.Now,
            Geneder = GenederType.Female,
            Wallet = 0,
            CreatedOnUtc = DateTime.Now,

        };
        user.AddRole(new RoleUser
        {
            RoleId = roleId,
            UserId = user.Id
        });
        context.Users.Add(user);
        return user;
    }

    public static AddUserDto GenerateAddUserDto(string mobile,
                                                Guid roleId,
                                                string firstname = "dummy-firstname",
                                                string lastname = "dummy-lastname",
                                                string email = "dummy-email")
    {
        return new AddUserDto
        {
            Email = email,
            Firsname = firstname,
            Lastname = lastname,
            Mobile = mobile,
            RoleId = roleId,
        };
    }

    public static EditUserDto GenerateEditUserDto(Guid roleId,
                                                  string firstname = "dummy-edit-firstname",
                                                  string lastname = "dummy-edit-lastname",
                                                  string email = "dummy-edit-email")
    {
        return new EditUserDto
        {
            RoleId = roleId,
            Firstname = firstname,
            Lastname = lastname,
            Email = email,
            Geneder=GenederType.Male,
            IsActiveMobile = true,
        };
    }
}

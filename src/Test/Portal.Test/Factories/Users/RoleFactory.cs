using Portal.Domain.Users;
using Portal.EF;
using System;

namespace Portal.Test.Factories;

public static class RoleFactory
{
    public static Role GenerateRole(EFdbApplication context, string roleName = "dummy-role")
    {
        var newRole = new Role
        {
            Id = Guid.NewGuid(),
            Title = roleName,
        };
        context.Roles.Add(newRole);
        return newRole;
    }
}

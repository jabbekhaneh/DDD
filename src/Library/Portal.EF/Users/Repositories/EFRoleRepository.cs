using Microsoft.EntityFrameworkCore;
using Portal.Application.Users.Contracts;
using Portal.Domain.Users;

namespace Portal.EF.Users.Repositories;

public class EFRoleRepository : RoleRepository
{
    private readonly EFdbApplication _db;

    public EFRoleRepository(EFdbApplication db)
    {
        _db = db;
    }

    public async Task<bool> IsExistRoleById(Guid roleId)
    {
        return await _db.Roles.AnyAsync(_=>_.Id == roleId);
    }
}

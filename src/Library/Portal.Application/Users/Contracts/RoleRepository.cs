using Portal.Domain.Users;

namespace Portal.Application.Users.Contracts;

public interface RoleRepository 
{
    Task<bool> IsExistRoleById(Guid roleId);
    
}

using Portal.Application.Users.Commands.AddUser;
using Portal.Domain.Users;

namespace Portal.Application.Users.Contracts
{
    public interface UserRepository
    {
        Task Add(User user);
    }
}

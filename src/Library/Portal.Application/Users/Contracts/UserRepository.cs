using Portal.Application.Users.Commands.AddUser;
using Portal.Application.Users.Queries.GetUserById;
using Portal.Domain.Users;

namespace Portal.Application.Users.Contracts
{
    public interface UserRepository
    {
        Task Add(User user);
        Task<User> FindById(Guid id);
        Task<GetUserByIdDto> GetUserById(Guid id);
    }
}

using Microsoft.EntityFrameworkCore;
using Portal.Application.Users.Contracts;
using Portal.Application.Users.Queries.GetUserById;
using Portal.Domain.Users;
using Mapster;
namespace Portal.EF.Users.Repositories;

public class EFUserRepository : UserRepository
{
    private readonly EFdbApplication _context;

    public EFUserRepository(EFdbApplication context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User> FindById(Guid id) => await _context.Users
        .FirstOrDefaultAsync(_ => _.Id == id);

    public async Task<GetUserByIdDto> GetUserById(Guid id)
    {
        return await _context.Users.Where(_ => _.Id == id)
            .ProjectToType<GetUserByIdDto>().FirstOrDefaultAsync();
    }
}

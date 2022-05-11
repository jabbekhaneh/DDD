using Microsoft.EntityFrameworkCore;
using Portal.Application.Users.Contracts;
using Portal.Domain.Users;

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

    public Task Delete(User user)
    {
        
        throw new NotImplementedException();
    }

    public async Task<User> FindById(Guid id) => await _context.Users.FirstOrDefaultAsync(_ => _.Id == id);

    
}

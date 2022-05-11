using Microsoft.EntityFrameworkCore;
using Portal.Application.Users.Contracts;
using Portal.Application.Users.Queries.GetUserById;
using Portal.Domain.Users;
using Mapster;
using Portal.Application.Users.Queries.GetUsers;
using Portal.Extentions;

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

    public async Task<GetUsersDto> GetUsers(string search, int pageId, int take)
    {
        IQueryable<User> users = _context.Users;
        var getUser = new GetUsersDto();

        if (string.IsNullOrEmpty(search))
            users = users.Where(_ => _.Firstname.Contains(search) &&
                                     _.Lastname.Contains(search) &&
                                     _.Mobile.Contains(search) &&
                                     _.Email.Contains(search));

        var pagination = users.Pagination<User>(take, pageId);
        getUser.Users = await pagination.Query.ProjectToType<GetUserDto>().ToListAsync();
        getUser.PageSize = pagination.PageSize;
        getUser.PageId = pageId;
        return getUser;
    }
}

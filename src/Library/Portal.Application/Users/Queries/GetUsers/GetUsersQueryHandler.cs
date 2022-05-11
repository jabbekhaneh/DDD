using MediatR;
using Portal.Application.Users.Contracts;
using Portal.Extentions.Common;

namespace Portal.Application.Users.Queries.GetUsers;
public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, OperationResult<GetUsersDto>>
{
    private readonly UserRepository _userRepository;
    public GetUsersQueryHandler(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<OperationResult<GetUsersDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

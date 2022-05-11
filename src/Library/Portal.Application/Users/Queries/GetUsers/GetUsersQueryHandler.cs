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

    public async Task<OperationResult<GetUsersDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        GetUsersDto users =await _userRepository.GetUsers(request.Search,request.PageId, request.Take);
        return OperationResult<GetUsersDto>.BuildSuccess(users);
    }
}

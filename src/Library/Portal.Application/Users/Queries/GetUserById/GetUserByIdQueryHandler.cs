using MediatR;
using Portal.Application.Users.Contracts;
using Portal.Extentions.Common;

namespace Portal.Application.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, OperationResult<GetUserByIdDto>>
{
    private readonly UserRepository _userRepository;

    public GetUserByIdQueryHandler(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult<GetUserByIdDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        GetUserByIdDto response=await _userRepository.GetUserById(request.UserId);
        return OperationResult<GetUserByIdDto>.BuildSuccess(response);
    }
}

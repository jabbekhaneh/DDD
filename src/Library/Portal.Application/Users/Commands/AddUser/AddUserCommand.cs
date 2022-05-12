using MediatR;
using Portal.Application.Common;
using Portal.Extentions.Common;

namespace Portal.Application.Users.Commands.AddUser;

public class AddUserCommand :  IRequest<OperationResult<AddUserResponseDto>>, CommittableRequest
{
    public AddUserDto User { get; set; }

}

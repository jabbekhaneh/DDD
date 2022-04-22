using MediatR;
using Portal.Application.Common;
using Portal.Extentions.Common;

namespace Portal.Application.Users.Commands.AddUser;

public class AddUserCommand : CommittableRequest, IRequest<OperationResult<AddUserResponseDto>>
{
    public AddUserCommand(AddUserDto user)
    {
        User = user;
    }
    public AddUserDto User { get; set; }

}

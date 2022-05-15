using MediatR;
using Portal.Extentions.Common;

namespace Portal.Application.Users.Commands.EditUser;

public class EditUserCommand : IRequest<OperationResult<EditUserResponseDto>>
{
    public EditUserCommand(Guid id, EditUserDto user)
    {
        Id = id;
        User = user;
    }
    public Guid Id { get; set; }

    public EditUserDto User { get; set; }
}

using MediatR;
using Portal.Extentions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

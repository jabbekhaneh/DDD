using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Users.Commands.AddUser;
using Portal.Application.Users.Commands.EditUser;
using Portal.Extentions.Common;

namespace Portal.WebApi.Controllers.Manager
{
    public class ManagerUsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ManagerUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<OperationResult<AddUserResponseDto>> AddUser(AddUserDto user)
        {
            return  await _mediator.Send(new AddUserCommand(user));
        }

        [HttpPut]
        public async Task<OperationResult<EditUserResponseDto>> EditUser(Guid id,EditUserDto user)
        {
            return await _mediator.Send(new EditUserCommand(id,user));
        }

    }
}

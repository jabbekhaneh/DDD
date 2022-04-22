using MediatR;
using Portal.Application.Users.Contracts;
using Portal.Domain.Users;
using Portal.Extentions.Common;

namespace Portal.Application.Users.Commands.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, OperationResult<AddUserResponseDto>>
{
    private readonly UserRepository _userRepository;

    public AddUserCommandHandler(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult<AddUserResponseDto>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = new AddUserResponseDto();
            var user = new User();
            user.Id = Guid.NewGuid();
            user.Mobile = request.User.Mobile;
            user.Firstname = request.User.Firsname;
            user.Lastname = request.User.Lastname;
            user.AddRole(new RoleUser
            {
                Id = Guid.NewGuid(),
                RoleId = request.User.RoleId,
                UserId = user.Id,
            });
            await _userRepository.Add(user);
            return OperationResult<AddUserResponseDto>.BuildSuccess(response);
        }
        catch (Exception ex)
        {

            return OperationResult<AddUserResponseDto>
                .BuildFailure(new OperationException(ex.Message, ExceptionStatusCodeType.AddUser));
        }
        
    }
}

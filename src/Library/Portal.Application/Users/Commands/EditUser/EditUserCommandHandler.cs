using MediatR;
using Portal.Application.Users.Contracts;
using Portal.Extentions.Common;

namespace Portal.Application.Users.Commands.EditUser;

public class EditUserCommandHandler : IRequestHandler<EditUserCommand, OperationResult<EditUserResponseDto>>
{
    private readonly UserRepository _userRepository;
    public EditUserCommandHandler(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult<EditUserResponseDto>> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response=new EditUserResponseDto();
            var user = await _userRepository.FindById(request.Id);
            if (user == null)
                return OperationResult<EditUserResponseDto>
                    .BuildFailure(new OperationException("", ExceptionStatusCodeType.NotFoundUser));

            var editRole = user.RoleUsers.FirstOrDefault();
            editRole.RoleId = request.User.RoleId;
            user.Email = request.User.Email;
            user.Address = request.User.Address;
            user.City = request.User.City;
            user.County = request.User.County;
            user.FatherName = request.User.FatherName;
            user.Firstname = request.User.Firstname;
            user.Lastname = request.User.Lastname;
            user.Job = request.User.Job;
            user.Geneder = request.User.Geneder;
            return OperationResult<EditUserResponseDto>.BuildSuccess(response);
        }
        catch (Exception ex) 
        {
            return OperationResult<EditUserResponseDto>.BuildFailure(ex);
        }
        
    }
}

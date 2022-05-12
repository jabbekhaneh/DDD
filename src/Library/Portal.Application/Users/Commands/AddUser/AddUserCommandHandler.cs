using MediatR;
using Portal.Application.Users.Contracts;
using Portal.Domain.Users;
using Portal.Extentions.Common;

namespace Portal.Application.Users.Commands.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, OperationResult<AddUserResponseDto>>
{
    private readonly UserRepository _userRepository;
    private readonly RoleRepository _roleRepository;
    public AddUserCommandHandler(UserRepository userRepository, 
                                 RoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<OperationResult<AddUserResponseDto>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = new AddUserResponseDto();

            if (!await _roleRepository.IsExistRoleById(request.User.RoleId))
                return OperationResult<AddUserResponseDto>
                    .BuildFailure(new OperationException("",ExceptionStatusCodeType.NotFoundRole));
            if(await _userRepository.IsExistByMobile(request.User.Mobile))
                return OperationResult<AddUserResponseDto>
                    .BuildFailure(new OperationException("", ExceptionStatusCodeType.DublicateMobile));
            var user = new User();
            user.Id = Guid.NewGuid();
            user.Mobile = request.User.Mobile;
            user.Firstname = request.User.Firsname;
            user.Lastname = request.User.Lastname;
            user.Geneder = GenederType.Empty;
            user.Wallet=0;
            user.DateOfBirth=DateTime.Now;
            user.LastActivityDateUtc=DateTime.Now;
            user.LastLoginDateUtc=DateTime.Now;
            user.AddRole(new RoleUser
            {
                Id = Guid.NewGuid(),
                RoleId = request.User.RoleId,
                UserId = user.Id,

            });
            await _userRepository.Add(user);
            response.UserId= user.Id;
            return OperationResult<AddUserResponseDto>.BuildSuccess(response);
        }
        catch (Exception ex)
        {

            return OperationResult<AddUserResponseDto>
                .BuildFailure(new OperationException(ex.Message, ExceptionStatusCodeType.AddUser));
        }
        
    }
}

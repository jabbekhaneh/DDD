using MediatR;
using Portal.Extentions.Common;

namespace Portal.Application.Users.Queries.GetUsers;

public class GetUsersQuery  : IRequest<OperationResult<GetUsersDto>>
{

}

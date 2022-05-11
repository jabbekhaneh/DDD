using MediatR;
using Portal.Extentions.Common;

namespace Portal.Application.Users.Queries.GetUserById;

public class GetUserByIdQuery  : IRequest<OperationResult<GetUserByIdDto>>
{
    public Guid UserId { get; set; }
}

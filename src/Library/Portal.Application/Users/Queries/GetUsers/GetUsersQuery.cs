using MediatR;
using Portal.Extentions.Common;

namespace Portal.Application.Users.Queries.GetUsers;

public class GetUsersQuery  : IRequest<OperationResult<GetUsersDto>>
{
    public string Search { get; set; }
    public int Take { get; set; }
    public int PageId { get; set; }
}

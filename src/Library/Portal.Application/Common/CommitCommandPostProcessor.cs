using MediatR;

namespace Portal.Application.Common;
public class CommitCommandPostProcessor<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly UnitOfWork _UOW;
    public CommitCommandPostProcessor(UnitOfWork unitOfWork)
    {
        _UOW = unitOfWork;
    }
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        try
        {
            if (request is CommittableRequest)
            {
                await _UOW.CommitAsync();
            }

            return await next();
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}

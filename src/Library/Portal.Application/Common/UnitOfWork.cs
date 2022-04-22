namespace Portal.Application.Common;
public interface UnitOfWork
{
    Task CommitAsync();
}

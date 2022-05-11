namespace Portal.Extentions;

public static class PaginationToolser
{
    public static (IQueryable<T> Query, int PageSize) Pagination<T>(this IQueryable<T> source, int take, int pageId)
    {
        var query = source;
        int TotalItemCount = query.Count();
        int pageSize = (int)Math.Ceiling((double)TotalItemCount / take);
        pageId = pageId > pageSize || pageId < 1 ? 1 : pageId;
        var skiped = (pageId - 1) * take;
        return (query.Skip(skiped).Take(take),pageSize);
    }

}

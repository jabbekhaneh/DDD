namespace Portal.Extentions.Common;

public class OperationResult<TResult>
{
    public TResult? Result { get; private set; }
    public bool IsSuccess { get; set; }
    public OperationException? Exception { get; private set; }
    public static OperationResult<TResult> BuildSuccess(TResult result)
    {
        return new OperationResult<TResult> { IsSuccess = true, Result = result };
    }

    public static OperationResult<TResult> BuildFailure(OperationException exception)
    {
        return new OperationResult<TResult> { IsSuccess = false, Exception = exception };
    }



}

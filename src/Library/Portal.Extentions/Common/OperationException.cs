namespace Portal.Extentions.Common;

public class OperationException : Exception
{
    public ExceptionStatusCodeType Status { get; private set; }
    public OperationException(string message, ExceptionStatusCodeType status) : base(message)
    {
        Status = status;
    }



}

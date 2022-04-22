namespace Portal.Extentions.Common;

public enum ExceptionStatusCodeType 
{
    BadRequest = 400,
    Forbidden = 403,
    NotFound = 404,
    InternalServer = 500,
    ServiceUnavailable = 503,
    GatewayTimeout = 504,


    AddUser = 601,
}

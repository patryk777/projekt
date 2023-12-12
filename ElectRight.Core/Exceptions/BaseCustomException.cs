namespace ElectRight.Core.Exceptions;

public class BaseCustomException : Exception
{
    public string ErrorCode { get; }

    public BaseCustomException(string message)
    {
        ErrorCode = message;
    }
}
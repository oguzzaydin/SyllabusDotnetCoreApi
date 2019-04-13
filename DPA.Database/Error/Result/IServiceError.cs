using System;
namespace DPA.Database.Error.Result
{
    public interface IServiceError
    {
        string Code { get; }
        string Description { get; }
        string Message { get; }
        Exception Exception { get; }
    }
}

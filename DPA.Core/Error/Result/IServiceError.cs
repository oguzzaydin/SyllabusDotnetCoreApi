using System;
namespace DPA.Core.Error.Result
{
    public interface IServiceError
    {
        string Code { get; }
        string Description { get; }
        string Message { get; }
        Exception Exception { get; }
    }
}

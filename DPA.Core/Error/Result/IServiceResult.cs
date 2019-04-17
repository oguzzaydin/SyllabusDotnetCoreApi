using System;
using System.Collections.Generic;

namespace DPA.Core.Error.Result
{
    public interface IServiceResult
    {
        int Code { get; }
        bool IsSuccess { get; }
        List<IServiceError> Errors { get; }
    }
    public interface IServiceResult<out TResult> : IServiceResult
    {
        TResult Result { get; }
    }
}

using System;
using System.Collections.Generic;

namespace DPA.Core.Error.Result
{
    public class ServiceResult : ServiceResult<int>
    {

        public ServiceResult(IServiceError serviceError, int code) : base(new List<IServiceError> { serviceError }, code)
        {

        }

        public ServiceResult(List<IServiceError> serviceError, int code) : base(serviceError, code)
        {
        }
    }
    public class ServiceResult<TResult> : ServiceResultBase<TResult>
    {
        public ServiceResult(List<IServiceError> serviceError, int code)
        {
            Errors.AddRange(serviceError);
            Code = code;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace DPA.Core.Error.Result
{
    public abstract class ServiceResultBase<TResult> : IServiceResult<TResult>
    {
        public TResult Result { get; protected set; }
        public int Code { get; protected set; }
        public bool IsSuccess => !Errors.Any();
        public List<IServiceError> Errors { get; protected set; }
        protected ServiceResultBase()
        {
            Errors = new List<IServiceError>();
        }
    }
}

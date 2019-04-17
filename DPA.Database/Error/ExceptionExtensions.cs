using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPA.Database.Error.Result;
using DPA.Database.Exceptions;

namespace DPA.Database.Error
{
    public static class ExceptionExtensions
    {
        public static IServiceResult ToServiceResult(this DpaException exception)
        {
            try
            {
                return new ServiceResult(new ServiceError(exception.StatusCode.ToString(), exception.ExceptionMessage,
                    message: exception.Message), exception.StatusCode);
            }
            catch (Exception ex)
            {
                return new ServiceResult(new ServiceError("400", "Translation Error", ex), exception.StatusCode);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DPA.Test
{
        public class IntegrationPagedServiceResult<TResult>
        {
            public int PageIndex { get; set; }
            public int RowCount { get; set; }
            public TResult Result { get; set; }
            public bool IsSuccess { get; set; }
       
        }
        public class IntegrationServiceResult
        {
            public object Result { get; set; }
            public bool IsSuccess { get; set; }
            public IEnumerable<IntegrationServiceError> Errors { get; set; }
        }

        public class IntegrationServiceError
        {
            public string Code { get; set; }
            public string Description { get; set; }
            public string Message { get; set; }
            public object Exception { get; set; }
        }

        public class AsyncResult<TResultType>
        {
            public TResultType Result { get; set; }
        }
}

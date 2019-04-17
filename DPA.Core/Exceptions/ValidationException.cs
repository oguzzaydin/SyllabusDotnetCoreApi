using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DPA.Core.Exceptions
{
    [Serializable]
    public class NotValidatedException : DpaException
    {
        public ValidationResult ValidationResult { get; }

        public NotValidatedException(ValidationResult validationResult) : base(400, null)
        {
            ValidationResult = validationResult;
        }

        protected NotValidatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    [Serializable]
    public class ParameterValueCannotBeZeroException : DpaException
    {
        public ParameterValueCannotBeZeroException(string parameterName) : base(400, "'{@@parameterName}' can not be zero") { Parameters.Add($"@{parameterName}", parameterName); }

        protected ParameterValueCannotBeZeroException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    [Serializable]
    public class ParameterCannotBeNullOrEmptyException : DpaException
    {
        public ParameterCannotBeNullOrEmptyException(string parameterName) : base(400, "'{@@parameterName} can not be null or empty!") { Parameters.Add($"@{parameterName}", parameterName); }

        protected ParameterCannotBeNullOrEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    [Serializable]
    public class ParameterValueGreaterThanZeroException : DpaException
    {
        public ParameterValueGreaterThanZeroException(string parameterName) : base(400, "{@@parameterName} should be greater than zero!") { Parameters.Add($"@{parameterName}", parameterName); }

        protected ParameterValueGreaterThanZeroException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    [Serializable]
    public class ParameterValueGreaterThanContractDateException : DpaException
    {
        public ParameterValueGreaterThanContractDateException(string parameterName) : base(400, "{@@parameterName} should be greater than contract date!") { Parameters.Add($"@{parameterName}", parameterName); }

        protected ParameterValueGreaterThanContractDateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}
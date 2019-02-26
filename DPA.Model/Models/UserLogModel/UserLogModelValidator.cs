using DotNetCore.Validation;
using FluentValidation;
using System;

namespace DPA.Model
{
    public sealed class UserLogModelValidator : Validator<UserLogModel>
    {
        public UserLogModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.UserId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.LogType).NotNull().NotEmpty().NotEqual(LogType.None);
            RuleFor(x => x.DateTime).NotNull().NotEmpty().NotEqual(DateTime.MinValue);
        }
    }
}

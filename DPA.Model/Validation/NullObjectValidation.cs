using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class NullObjectValidation<T> : Validator<T>
    {
        public NullObjectValidation()
        {
            RuleFor(x => x).NotNull().NotEmpty();
        }
    }
}
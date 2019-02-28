using DotNetCore.Validation;
using DPA.CrossCutting.Resources;
using FluentValidation;

namespace DPA.Model
{
    public class NullObjectValidation<T> : Validator<T>
    {
        public NullObjectValidation() : base(Texts.NullObject)
        {
            RuleFor(x => x).NotNull().NotEmpty();
        }
    }
}
using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public sealed class SignedInModelValidator : Validator<SignedInModel>
    {
        public SignedInModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.Roles).NotNull().NotEmpty().NotEqual(Roles.None);
        }
    }
}
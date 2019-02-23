using DotNetCore.Validation;
using DPA.CrossCutting.Resources;
using FluentValidation;
using DPA.Model;

namespace DPA.Model
{
    public sealed class SignedInModelValidator : Validator<SignedInModel>
    {
        public SignedInModelValidator() : base(Texts.AuthenticationInvalid)
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.Roles).NotNull().NotEmpty().NotEqual(Roles.None);
        }

    }
}
using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public sealed class SignInModelValidator : Validator<SignInModel>
    {
        public SignInModelValidator() 
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Login).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
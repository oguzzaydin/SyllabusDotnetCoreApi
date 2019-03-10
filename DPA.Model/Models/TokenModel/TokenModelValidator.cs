using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public sealed class TokenModelValidator : Validator<TokenModel>
    {
        public TokenModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Token).NotNull().NotEmpty();
            RuleFor(x => x.UserInfo).NotNull().NotEmpty();
        }
    }
}
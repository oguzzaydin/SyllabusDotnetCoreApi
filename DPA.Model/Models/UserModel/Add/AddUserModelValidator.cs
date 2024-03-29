using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public sealed class AddUserModelValidator : Validator<AddUserModel>
    {
        public AddUserModelValidator()
        {
            RuleFor(x => x).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Surname).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.Login).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.Title).NotNull().NotEmpty();
        }
    }
}
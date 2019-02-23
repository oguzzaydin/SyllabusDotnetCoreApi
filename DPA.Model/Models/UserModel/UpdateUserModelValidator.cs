using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class UpdateUserModelValidator : Validator<UpdateUserModel>
    {
        public UpdateUserModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Surname).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.Title).NotNull().NotEmpty();
        }
    }
}
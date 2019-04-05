using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class AddConstraintModelValidator : Validator<AddConstraintModel>
    {
        public AddConstraintModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Title).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.IsFreeDay).NotNull();
            RuleFor(x => x.IsActive).NotNull();
            RuleFor(x => x.WeeklyHour).NotNull().NotEmpty();
            RuleFor(x => x.EducationType).NotNull().NotEmpty();
            RuleFor(x => x.UserId).NotNull().NotEmpty();
        }
    }
}
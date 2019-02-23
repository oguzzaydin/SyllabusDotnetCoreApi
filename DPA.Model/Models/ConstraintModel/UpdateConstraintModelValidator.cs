using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class UpdateConstraintModelValidator : Validator<UpdateConstraintModel>
    {
        public UpdateConstraintModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Title).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.IsFreeDay).NotNull().NotEmpty();
            RuleFor(x => x.IsActive).NotNull().NotEmpty();
            RuleFor(x => x.WeeklyHour).NotNull().NotEmpty();
            RuleFor(x => x.EducationType).NotNull().NotEmpty();
        }
    }
}
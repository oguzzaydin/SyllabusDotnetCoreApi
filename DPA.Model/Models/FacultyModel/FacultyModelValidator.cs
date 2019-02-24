using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class FacultyModelValidator : Validator<FacultyModel>
    {
        public FacultyModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Title).NotNull().MaximumLength(100);
            RuleFor(x => x.FacultyCode).NotNull().MaximumLength(50);
        }
    }
}
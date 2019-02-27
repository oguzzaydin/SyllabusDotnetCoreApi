using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class SyllabusModelValidator : Validator<SyllabusModel>
    {
        public SyllabusModelValidator()
        {
            RuleFor(x => x).NotNull().NotEmpty();
            RuleFor(x => x.PeriodType).NotNull().NotEmpty();
            RuleFor(x => x.SyllabusId).NotNull().NotEmpty();
            RuleFor(x => x.Year).NotNull().NotEmpty();
        }
    }
}
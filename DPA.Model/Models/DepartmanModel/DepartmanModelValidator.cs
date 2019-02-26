using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class DepartmanModelValidator : Validator<DepartmanModel>
    {
        public DepartmanModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Title).NotNull().MaximumLength(200);
            RuleFor(x => x.DepartmanCode).NotNull().MaximumLength(200);
            RuleFor(x => x.FacultyId).NotNull();
        }
    }
}
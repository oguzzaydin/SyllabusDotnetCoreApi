using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class DepartmentModelValidator : Validator<DepartmentModel>
    {
        public DepartmentModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Title).NotNull().MaximumLength(200);
            RuleFor(x => x.DepartmentCode).NotNull().MaximumLength(200);
            RuleFor(x => x.FacultyId).NotNull();
        }
    }
}
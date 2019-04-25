using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class DepartmentInstructorModel
    {
        public long UserId { get; set; }
        public long DepartmentId { get; set; }
    }

    public sealed class DepartmentInstructorValidator : Validator<DepartmentInstructorModel>
    {
        public DepartmentInstructorValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Bu alanlar zorunludur.");
            RuleFor(x => x.DepartmentId).NotNull().NotEmpty();
            RuleFor(x => x.UserId).NotNull().NotEmpty();
        }
    }
}
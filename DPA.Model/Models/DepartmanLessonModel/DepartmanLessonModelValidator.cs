using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public sealed class DepartmentLessonModelValidator : Validator<DepartmentLessonModel>
    {
        public DepartmentLessonModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.DepartmentId).NotNull().NotEmpty();
            RuleFor(x => x.LessonId).NotNull().NotEmpty();
        }
    }
}
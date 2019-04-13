using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class AddDepartmentLessonModelValidator : Validator<AddDepartmentLessonModel>
    {
        public AddDepartmentLessonModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.DepartmentId).NotNull().NotEmpty();
            RuleFor(x => x.LessonId).NotNull().NotEmpty();
        }
    }
}
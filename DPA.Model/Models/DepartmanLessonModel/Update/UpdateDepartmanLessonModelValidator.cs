using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
     public sealed class UpdateDepartmentLessonModelValidator : Validator<UpdateDepartmentLessonModel>
    {
        public UpdateDepartmentLessonModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.DepartmentId).NotNull().NotEmpty();
            RuleFor(x => x.LessonId).NotNull().NotEmpty();
        }
    }
}
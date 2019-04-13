using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class ListDepartmentLessonModelValidator : Validator<ListDepartmentLessonModel>
    {
        public ListDepartmentLessonModelValidator()
        {
            RuleFor(x => x.DepartmentLessonEntity).NotNull().NotEmpty();
        }
    }
}
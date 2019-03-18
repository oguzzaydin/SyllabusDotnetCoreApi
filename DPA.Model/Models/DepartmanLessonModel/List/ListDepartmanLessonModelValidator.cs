using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class ListDepartmanLessonModelValidator : Validator<ListDepartmanLessonModel>
    {
        public ListDepartmanLessonModelValidator()
        {
            RuleFor(x => x.DepartmanLessonId).NotNull().NotEmpty();
        }
    }
}
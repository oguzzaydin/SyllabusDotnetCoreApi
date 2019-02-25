using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class AddDepartmanLessonModelValidator : Validator<AddDepartmanLessonModel>
    {
        public AddDepartmanLessonModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.DepartmanId).NotNull().NotEmpty();
            RuleFor(x => x.LessonId).NotNull().NotEmpty();
        }
    }
}
using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public sealed class DepartmanLessonModelValidator : Validator<DepartmanLessonModel>
    {
        public DepartmanLessonModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.DepartmanId).NotNull().NotEmpty();
            RuleFor(x => x.DepartmanLessonId).NotNull().NotEmpty();
            RuleFor(x => x.LessonId).NotNull().NotEmpty();
        }
    }
}
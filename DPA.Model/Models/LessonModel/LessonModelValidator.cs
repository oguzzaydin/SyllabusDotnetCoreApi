using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class LessonModelValidator : Validator<LessonModel>
    {
        public LessonModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Name).NotNull().MaximumLength(50);
            RuleFor(x => x.WeeklyHour).NotNull();
            RuleFor(x => x.LessonCode).NotNull();
            RuleFor(x => x.Group).NotNull();
            RuleFor(x => x.AKTS).NotNull();
            RuleFor(x => x.LessonType).NotNull();
        }
    }
}
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
            RuleFor(x => x.LessonCode).NotNull().MaximumLength(5);
            RuleFor(x => x.Group).NotNull().MaximumLength(5);
            RuleFor(x => x.AKTS).NotNull();
            RuleFor(x => x.LessonType).NotNull();
            RuleFor(x => x.EducationType).NotNull();
        }
    }
}
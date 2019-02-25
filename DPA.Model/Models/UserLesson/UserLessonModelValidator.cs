using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public sealed class UserLessonModelValidator : Validator<UserLessonModel>
    {
        public UserLessonModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.UserLessonId).NotNull().NotEmpty();
            RuleFor(x => x.LessonId).NotNull().NotEmpty();
        }
    }
}
using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
     public sealed class AddUserLessonModelValidator : Validator<AddUserLessonModel>
    {
        public AddUserLessonModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.LessonId).NotNull().NotEmpty();
        }
    }
}
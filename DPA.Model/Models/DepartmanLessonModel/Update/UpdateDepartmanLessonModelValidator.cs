using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
     public sealed class UpdateDepartmanLessonModelValidator : Validator<UpdateDepartmanLessonModel>
    {
        public UpdateDepartmanLessonModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.DepartmanId).NotNull().NotEmpty();
            RuleFor(x => x.LessonId).NotNull().NotEmpty();
        }
    }
}
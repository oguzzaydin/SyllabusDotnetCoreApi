using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class ListLessonModelValidator : Validator<ListLessonModel>
    {
        public ListLessonModelValidator()
        {
            RuleFor(x => x).NotNull().NotEmpty();
            
        }
    }
}
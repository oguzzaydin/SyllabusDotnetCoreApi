using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class ListConstraintModelValidator : Validator<ListConstraintModel>
    {
        public ListConstraintModelValidator()
        {
            RuleFor(x => x.ConstraintId).NotNull().NotEmpty();
        }
    }
}
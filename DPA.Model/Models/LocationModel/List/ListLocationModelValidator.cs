using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class ListLocationModelValidator : Validator<ListLocationModel>
    {
        public ListLocationModelValidator()
        {
            RuleFor(x => x.LocationId).NotNull().NotEmpty();
        }
    }
}
using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class ListDepartmanModelValidator : Validator<ListDepartmanModel>
    {
        public ListDepartmanModelValidator()
        {
            RuleFor(x => x.DepartmanId).NotNull().NotEmpty();
        }
    }
}
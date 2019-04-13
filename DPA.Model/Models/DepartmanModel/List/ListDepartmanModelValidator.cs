using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class ListDepartmentModelValidator : Validator<ListDepartmentModel>
    {
        public ListDepartmentModelValidator()
        {
            RuleFor(x => x.DepartmentId).NotNull().NotEmpty();
        }
    }
}
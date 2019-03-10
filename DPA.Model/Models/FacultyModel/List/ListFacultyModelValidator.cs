using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class ListFacultyModelValidator : Validator<ListFacultyModel>
    {
        public ListFacultyModelValidator()
        {
            RuleFor(x => x.FacultyId).NotNull().NotEmpty();
        }
    }
}
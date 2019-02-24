using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class LocationModelValidator : Validator<LocationModel>
    {
        public LocationModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Title).NotNull();
            RuleFor(x => x.FacultyId).NotNull();
        }
    }
}
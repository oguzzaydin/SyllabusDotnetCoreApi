using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model.Models.UserModel.List
{
    public class ListUserModelValidatior : Validator<ListUserModel>
    {
        public ListUserModelValidatior()
        {
            RuleFor(x => x.Roles).NotNull().NotEmpty();
        }
    }
}
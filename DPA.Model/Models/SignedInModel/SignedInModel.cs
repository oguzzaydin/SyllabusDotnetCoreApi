using DPA.Model.Enums;

namespace DPA.Model.Models.SignedInModel
{
    public class SignedInModel
    {
        public long UserId { get; set; }

        public Roles Roles { get; set; }
    }
}
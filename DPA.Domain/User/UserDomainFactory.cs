using DPA.Model;

namespace DPA.Domain
{
    public static class UserDomainFactory
    {
        public static UserDomain Create(SignInModel signInModel)
        {
            return new UserDomain
            (
                signInModel.UserName,
                signInModel.Password
            );
        }

        public static UserDomain Create(SignedInModel signedInModel)
        {
            return new UserDomain
            (
                signedInModel.UserId,
                signedInModel.Roles
            );
        }
    }
}

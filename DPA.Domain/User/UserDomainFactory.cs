using DPA.Model;

namespace DPA.Domain
{
    public static class UserDomainFactory
    {
        public static UserDomain Create(AddUserModel addUserModel)
        {
            return new UserDomain
            (
                addUserModel.Name,
                addUserModel.Surname,
                addUserModel.Email,
                addUserModel.Login,
                addUserModel.Password,
                addUserModel.Title
            );
        }

        public static UserDomain Create(UpdateUserModel updateUserModel)
        {
            return new UserDomain
            (
                updateUserModel.Name,
                updateUserModel.Surname,
                updateUserModel.Email,
                null,
                null,
                updateUserModel.Title
            );
        }

        public static UserDomain Create(UserEntity userEntity)
        {
            return new UserDomain
            (
                userEntity.UserId,
                userEntity.Name,
                userEntity.Surname,
                userEntity.Email,
                userEntity.Login,
                userEntity.Password,
                userEntity.Title,
                userEntity.Roles
            );
        }

        public static UserDomain Create(SignInModel signInModel)
        {
            return new UserDomain
            (
                signInModel.Login,
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
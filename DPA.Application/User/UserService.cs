using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Model;
using System.Threading.Tasks;

namespace DPA.Application
{
    public sealed class UserService : IUserService
    {
        public UserService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IUserDomainService userDomainService,
            IUserRepository userRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            UserDomainService = userDomainService;
            UserRepository = userRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IUserDomainService UserDomainService { get; }

        private IUserRepository UserRepository { get; }

        public async Task<IDataResult<SignedInModel>> SignInAsync(SignInModel signInModel)
        {
            var validation = new SignInModelValidator().Valid(signInModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<SignedInModel>(validation.Message);
            }

            signInModel.UserName = UserDomainService.GenerateHash(signInModel.UserName);

            signInModel.Password = UserDomainService.GenerateHash(signInModel.Password);

            var signedInModel = await UserRepository.SignInAsync(signInModel);

            validation = new SignedInModelValidator().Valid(signedInModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<SignedInModel>(validation.Message);
            }

            return new SuccessDataResult<SignedInModel>(signedInModel);
        }

        public async Task<IDataResult<TokenModel>> SignInJwtAsync(SignInModel signInModel)
        {
            var result = await SignInAsync(signInModel).ConfigureAwait(false);

            if (!result.Success)
            {
                return new ErrorDataResult<TokenModel>(result.Message);
            }

            var token = UserDomainService.GenerateToken(result.Data);

            var tokenModel = new TokenModel(token);

            return new SuccessDataResult<TokenModel>(tokenModel);
        }
    }
}
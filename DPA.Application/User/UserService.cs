using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public sealed class UserService : IUserService
    {
        public UserService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IUserDomainService userDomainService,
            IUserLogService userLogService,
            IUserRepository userRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            UserDomainService = userDomainService;
            UserRepository = userRepository;
            UserLogService = userLogService;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }
        private IUserDomainService UserDomainService { get; }
        private IUserRepository UserRepository { get; }
        private IUserLogService UserLogService { get; }

        public async Task<IDataResult<long>> AddUserAsync(AddUserModel addUserModel)
        {
            var validation = new AddUserModelValidator().Valid(addUserModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            addUserModel.Login = UserDomainService.GenerateHash(addUserModel.Login);
            addUserModel.Password = UserDomainService.GenerateHash(addUserModel.Password);
            var userDomain = UserDomainFactory.Create(addUserModel);
            userDomain.Add();
            var userEntity = userDomain.Map<UserEntity>();
            await UserRepository.AddAsync(userEntity);
            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(userEntity.UserId);
        }

        public async Task<IResult> DeleteAsync(long userId)
        {
            await UserRepository.DeleteAsync(userId);
            await DatabaseUnitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }

        public async Task<IEnumerable<UserModel>> ListAsync()
        {
            return await UserRepository.ListAsync<ListUserModel>();
        }

        public async Task<PagedList<UserModel>> ListAsync(PagedListParameters parameters)
        {
            return await UserRepository.ListAsync<UserModel>(parameters);
        }

        public async Task<ListUserModel> SelectAsync(long userId)
        {
            return await  UserRepository.SelectAsync<ListUserModel>(userId);
        }

        public async Task<IDataResult<SignedInModel>> SignInAsync(SignInModel signInModel)
        {
            var validation = new SignInModelValidator().Valid(signInModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<SignedInModel>(validation.Message);
            }

            signInModel.Login = UserDomainService.GenerateHash(signInModel.Login);
            signInModel.Password = UserDomainService.GenerateHash(signInModel.Password);
            var signedInModel = await UserRepository.SignInAsync(signInModel);
            validation = new SignedInModelValidator().Valid(signedInModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<SignedInModel>(validation.Message);
            }

            await AddUserLogAsync(signedInModel.UserId, LogType.SignIn).ConfigureAwait(false);

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
            var userInfo = await SelectAsync(result.Data.UserId).ConfigureAwait(false);
            var tokenModel = new TokenModel(token, userInfo);

            return new SuccessDataResult<TokenModel>(tokenModel);
        }

        public async Task SignOutAsync(SignOutModel signOutModel)
        {
            await AddUserLogAsync(signOutModel.UserId, LogType.SignOut).ConfigureAwait(false);
        }

        public async Task<IResult> UpdateAsync(long userId, UpdateUserModel updateUserModel)
        {
            var validation = new UpdateUserModelValidator().Valid(updateUserModel);

            if (!validation.Success)
            {
                return new ErrorResult(validation.Message);
            }

            var userEntity = await UserRepository.SelectAsync(userId);
            var nullObjectValidation = new NullObjectValidation<UserEntity>().Valid(userEntity);

            if (!nullObjectValidation.Success)
            {
                return new ErrorResult(nullObjectValidation.Message);
            }

            var userDomain = UserDomainFactory.Create(userEntity);
            userDomain.Update(updateUserModel);
            userEntity = userDomain.Map<UserEntity>();
            userEntity.UserId = userId;
            await UserRepository.UpdateAsync(userEntity, userEntity.UserId);
            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        private async Task AddUserLogAsync(long userId, LogType logType)
        {
            var userLogModel = new UserLogModel(userId, logType);
            await UserLogService.AddAsync(userLogModel);
        }

    }
}
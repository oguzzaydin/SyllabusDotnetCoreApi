using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DPA.Application
{
    public sealed class UserLessonService : IUserLessonService
    {
        public UserLessonService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IUserLessonRepository userLessonRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            UserLessonRepository = userLessonRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IUserLessonRepository UserLessonRepository { get; }

        public async Task<IDataResult<long>> AddAsync(AddUserLessonModel addUserLessonModel)
        {
            var validation = new AddUserLessonModelValidator().Valid(addUserLessonModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var userLessonDomain = UserLessonDomainFactory.Create(addUserLessonModel);

            var userLessonEntity = userLessonDomain.Map<UserLessonEntity>();

            await UserLessonRepository.AddAsync(userLessonEntity);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(userLessonEntity.UserLessonId);
        }

        public async Task<IResult> DeleteLessonAsync(long userId, long lessonId)
        {
            await UserLessonRepository.DeleteAsync(x => x.UserId == userId && x.LessonId == lessonId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IEnumerable<UserModel>> ListInstructorAsync(long lessonId)
        {
            var userLesson = await UserLessonRepository.ListAsync<UserLessonEntity>(x => x.LessonId == lessonId, y => y.User);

            return userLesson.Select(x => x.User).Map<IEnumerable<UserModel>>();
        }

        public async Task<IEnumerable<LessonModel>> ListLessonAsync(long userId)
        {
            var userLesson = await UserLessonRepository.ListAsync<UserLessonEntity>(x => x.UserId == userId, y => y.Lesson);

            return userLesson.Select(x => x.Lesson).Map<IEnumerable<LessonModel>>();
        }

        public async Task<IResult> UpdateInstructorAsync(long userId, UpdateUserLessonModel updateUserLessonModel)
        {
            return await Update(updateUserLessonModel, x => x.LessonId == updateUserLessonModel.LessonId && x.UserId == userId).ConfigureAwait(false);;
        }

        public async Task<IResult> UpdateLessonAsync(long lessonId, UpdateUserLessonModel updateUserLessonModel)
        {
            return await Update(updateUserLessonModel, x => x.UserId == updateUserLessonModel.UserId && x.LessonId == lessonId).ConfigureAwait(false);;
        }

        private async Task<IResult> Update(UpdateUserLessonModel updateUserLessonModel, Expression<Func<UserLessonEntity, bool>> where)
        {
            var validation = new UserLessonModelValidator().Valid(updateUserLessonModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var userLessonEntity = await UserLessonRepository.SingleOrDefaultAsync(where);
            
            var nullObjectValidation = new NullObjectValidation<UserLessonEntity>().Valid(userLessonEntity);

            if (!nullObjectValidation.Success)
            {
                return new ErrorResult(nullObjectValidation.Message);
            }

            var userLessonDomain = UserLessonDomainFactory.Create(updateUserLessonModel);

            userLessonDomain.Update(updateUserLessonModel);

            userLessonEntity = userLessonDomain.Map<UserLessonEntity>();

            await UserLessonRepository.UpdateAsync(userLessonEntity, userLessonEntity.UserLessonId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}
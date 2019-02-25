using System;
using DPA.Model;

namespace DPA.Domain
{
    public static class UserLessonDomainFactory
    {
        public static UserLessonDomain Create(UpdateUserLessonModel updateUserLessonModel)
        {
            return new UserLessonDomain
            (
                updateUserLessonModel.UserId,
                updateUserLessonModel.LessonId
            );
        }

        public static UserLessonDomain Create(AddUserLessonModel addUserLessonModel)
        {
            return new UserLessonDomain
            (
                addUserLessonModel.UserId,
                addUserLessonModel.LessonId
            );
        }


        public static UserLessonDomain Create(UserLessonEntity userLessonEntity)
        {
            return new UserLessonDomain
            (
                userLessonEntity.UserLessonId,
                userLessonEntity.UserId,
                userLessonEntity.LessonId
            );
        }

    }
}
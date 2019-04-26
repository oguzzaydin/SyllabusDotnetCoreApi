using DPA.Model;

namespace DPA.Domain
{
    public static class ConstraintDomainFactory
    {
        public static ConstraintDomain Create(AddConstraintModel addConstraintModel)
        {
            return new ConstraintDomain(
                addConstraintModel.Title,
                addConstraintModel.Description,
                addConstraintModel.IsFreeDay,
                addConstraintModel.IsActive,
                addConstraintModel.WeeklyHour,
                addConstraintModel.EducationType,
                addConstraintModel.UserId,
                addConstraintModel.StartTime,
                addConstraintModel.EndTime
            );
        }

        public static ConstraintDomain Create(UpdateConstraintModel updateConstraintModel)
        {
            return new ConstraintDomain(
                updateConstraintModel.Title,
                updateConstraintModel.Description,
                updateConstraintModel.IsFreeDay,
                updateConstraintModel.IsActive,
                updateConstraintModel.WeeklyHour,
                updateConstraintModel.EducationType,
                updateConstraintModel.UserId,
                updateConstraintModel.StartTime,
                updateConstraintModel.EndTime
            );
        }

        public static ConstraintDomain Create(ConstraintEntity constraintEntity)
        {
            return new ConstraintDomain(
                constraintEntity.ConstraintId,
                constraintEntity.Title,
                constraintEntity.Description,
                constraintEntity.IsFreeDay,
                constraintEntity.IsActive,
                constraintEntity.WeeklyHour,
                constraintEntity.EducationType,
                constraintEntity.CreatedDate,
                constraintEntity.StartTime,
                constraintEntity.EndTime
            );
        }
    }
}
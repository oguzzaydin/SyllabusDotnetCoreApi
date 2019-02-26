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
                addConstraintModel.UserId
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
                updateConstraintModel.UserId
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
                constraintEntity.CreatedDate
            );
        }
    }
}
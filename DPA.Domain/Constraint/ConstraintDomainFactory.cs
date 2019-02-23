using DPA.Model;

namespace DPA.Domain
{
    public static class ConstraintDomainFactory
    {
        public static ConstraintDomain Create(AddConstraintModel addConstraintModel) {
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

         public static ConstraintDomain Create(UpdateConstraintModel addConstraintModel) {
            return new ConstraintDomain(
                addConstraintModel.Title,
                addConstraintModel.Description,
                addConstraintModel.IsFreeDay,
                addConstraintModel.IsActive,
                addConstraintModel.WeeklyHour,
                addConstraintModel.EducationType
            );
        }

         public static ConstraintDomain Create(ConstraintEntity constraintEntity) {
            return new ConstraintDomain(
                constraintEntity.Id,
                constraintEntity.Title,
                constraintEntity.Description,
                constraintEntity.IsFreeDay,
                constraintEntity.IsActive,
                constraintEntity.WeeklyHour,
                constraintEntity.EducationType
            );
        }
    }
}
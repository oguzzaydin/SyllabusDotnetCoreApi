using System;
using DPA.Model;

namespace DPA.Domain
{
    public class ConstraintDomain
    {
        // Update
        protected internal ConstraintDomain(
            string title,
            string description,
            bool isFreeDay,
            bool isActive,
            WeeklyHour weeklyHour,
            EducationType educationType,
            long userId
        )
        {
            Title = title;
            Description = description;
            IsFreeDay = isFreeDay;
            IsActive = isActive;
            WeeklyHour = weeklyHour;
            EducationType = educationType;
            UserId = userId;
        }

        protected internal ConstraintDomain(
          string title,
          string description,
          bool isFreeDay,
          bool isActive,
          WeeklyHour weeklyHour,
          EducationType educationType
        )
        {
            Title = title;
            Description = description;
            IsFreeDay = isFreeDay;
            IsActive = isActive;
            WeeklyHour = weeklyHour;
            EducationType = educationType;
        }

        protected internal ConstraintDomain(
          long constraintId,
          string title,
          string description,
          bool isFreeDay,
          bool isActive,
          WeeklyHour weeklyHour,
          EducationType educationType,
          DateTime createdDate
        )
        {
            ConstraintId = constraintId;
            Title = title;
            Description = description;
            IsFreeDay = isFreeDay;
            IsActive = isActive;
            WeeklyHour = weeklyHour;
            EducationType = educationType;
            CreatedDate = createdDate;
        }

        public long ConstraintId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public bool IsFreeDay { get; private set; }

        public bool IsActive { get; private set; }

        public WeeklyHour WeeklyHour { get; private set; }

        public EducationType EducationType { get; private set; }

        public long UserId { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime UpdatedDate { get; private set; }

        public void Add()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public void Update(UpdateConstraintModel updateConstraintModel)
        {
            Title = updateConstraintModel.Title;
            Description = updateConstraintModel.Description;
            IsFreeDay = updateConstraintModel.IsFreeDay;
            IsActive = updateConstraintModel.IsActive;
            WeeklyHour = updateConstraintModel.WeeklyHour;
            EducationType = updateConstraintModel.EducationType;
            UserId = updateConstraintModel.UserId;
            UpdatedDate = DateTime.Now;
        }
    }
}
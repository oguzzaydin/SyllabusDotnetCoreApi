using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class UpdateUnitLessonModel
    {
        public long UnitLessonId { get; set; }
        public long LocationId { get; set; }
        public int StarTime { get; set; }
        public int EndTime { get; set; }
        public DayOfTheWeekType DayOfTheWeekType { get; set; }
    }

     public class UpdateUnitLessonModelValidator : Validator<UpdateUnitLessonModel>
    {
        public UpdateUnitLessonModelValidator()
        {
            RuleFor(x => x).NotNull().NotEmpty();
            RuleFor(x => x.UnitLessonId).NotEqual(0).GreaterThan(0).NotEmpty();
            RuleFor(x => x.LocationId).NotEqual(0).GreaterThan(0).NotEmpty();
            RuleFor(x => x.StarTime).NotEqual(0).GreaterThan(0).NotEmpty();
            RuleFor(x => x.EndTime).NotEqual(0).GreaterThan(0).NotEmpty();
            RuleFor(x => x.DayOfTheWeekType).IsInEnum().NotEmpty();
        }
    }
}
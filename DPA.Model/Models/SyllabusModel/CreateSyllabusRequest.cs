using System;
using DotNetCore.Validation;
using FluentValidation;

namespace DPA.Model
{
    public class CreateSyllabusRequest
    {
        public long FacultyId { get; set; }
        public long DepartmentId { get; set; }
        public SemesterType SemesterType { get; set; }
        public PeriodType PeriodType { get; set; }
        public EducationType EducationType { get; set; }
        public int WeeklyHour { get; set; }
    }

    public class CreateSyllabusRequestValidator : Validator<CreateSyllabusRequest>
    {
        public CreateSyllabusRequestValidator()
        {
            RuleFor(x => x).NotNull().NotEmpty();
            RuleFor(x => x.FacultyId).NotNull().GreaterThan(0);
            RuleFor(x => x.DepartmentId).NotNull().GreaterThan(0);
            RuleFor(x => x.SemesterType).IsInEnum().NotNull().NotEmpty();
            RuleFor(x => x.EducationType).IsInEnum().NotNull().NotEmpty();
            RuleFor(x => x.WeeklyHour).NotNull().GreaterThan(10);
        }
    }
}

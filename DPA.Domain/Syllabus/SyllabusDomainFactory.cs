using DPA.Model;

namespace DPA.Domain.Syllabus
{
    public static class SyllabusDomainFactory
    {
        public static SyllabusDomain Create(CreateSyllabusRequest request)
        {
            return new SyllabusDomain
            (
                request.DepartmentId,
                request.SemesterType,
                request.PeriodType,
                request.EducationType,
                request.WeeklyHour
            );
        }
    }
}
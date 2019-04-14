namespace DPA.Domain.UnitLesson
{
    public static class UnitLessonFactory
    {
        public static UnitLessonDomain Create(long lessonId, long userId, long locationId, long syllabusId)
        {
            return new UnitLessonDomain
            (
                lessonId,
                userId,
                locationId,
                syllabusId
            );
        }
    }
}
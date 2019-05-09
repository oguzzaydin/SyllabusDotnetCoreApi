using System;
using System.Collections.Generic;
using System.Text;

namespace DPA.Model.Models.SyllabusModel.Dtos
{
    public class TeacherConstraintWithLessonsDto
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Roles Roles { get; set; }
        public Status Status { get; set; }
        public Title Title { get; set; }
        public List<LessonDto> Lessons { get; set; }
        public ConstraintModel Constraint { get; set; }
        public int IterationCount { get; set; } = 0;
        public int MinHour { get; set; }
        public bool IsFullyAssigned { get; set; } = false;
    }
}

using DPA.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPA.Domain.Syllabus
{
    public class LessonBlock
    {
        public int BlockId { get; set; }
        public List<UnitLessonEntity> units { get; set; }
        public long LessonId { get; set; }
        public long UserId { get; set; } = 0;
        public bool IsDeadLock { get; set; } = false;
    }
}

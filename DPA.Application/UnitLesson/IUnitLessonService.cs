using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Objects;
using DPA.Model;

namespace DPA.Application.UnitLesson
{
    public interface IUnitLessonService
    {
        Task<IResult> UpdateAsync(UpdateUnitLessonModel request);
    }
}
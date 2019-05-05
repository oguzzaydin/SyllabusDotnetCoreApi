using System.Collections.Generic;
using DPA.Model;

namespace DPA.Domain
{
    public class TimesAndDays
    {
        public TimesAndDays(EducationType educationType)
        {
            if (educationType == EducationType.IOgretim)
                TimeAndDayCreator(9, 15);
            else
                TimeAndDayCreator(15, 23);

        }

        public void TimeAndDayCreator(int startTime, int endTime)
        {
            for (int i = 1; i < 6; i++)
            {
                var times = new TimeAndDaysBase(); 
                for (int j = startTime; j < endTime; j++)
                {
                    times.Days = (DayOfTheWeekType)i;
                    times.times.Add(j);

                }
                TimeAndDays.Add(times);
            }
        }

        public List<TimeAndDaysBase> TimeAndDays { get; set; } = new List<TimeAndDaysBase>();
    }


    public class TimeAndDaysBase
    {
        public DayOfTheWeekType Days { get; set; }
        public List<int> times { get; set; } = new List<int>();
    }
}
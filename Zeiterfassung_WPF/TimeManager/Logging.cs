using System;

namespace Arbeitszeiterfassung_TN.TimeManager
{
    static internal class Logging
    {
        static internal DateTime LogInOut(DateTime actualTime)
        {
            DateTime timeSpan = actualTime;
            DateTime timeLog = new DateTime();

            DateTime firstQuarter = Convert.ToDateTime(timeSpan.Hour + ":07:30");
            DateTime secondQuarter = Convert.ToDateTime(timeSpan.Hour + ":22:30");
            DateTime thirdQuarter = Convert.ToDateTime(timeSpan.Hour + ":37:30");
            DateTime fourthQuarter = Convert.ToDateTime(timeSpan.Hour + ":52:30");

            DateTime earlistComing = Convert.ToDateTime("08:30:00");
            DateTime latestToGo = Convert.ToDateTime("14:30:00");

            if (DateTime.Compare(timeSpan, earlistComing) < 0)
            {
                timeLog = earlistComing;
            }
            else if (DateTime.Compare(timeSpan, latestToGo) > 0)
            {
                timeLog = latestToGo;
            }
            else
            {
                if (DateTime.Compare(timeSpan, firstQuarter) < 0)
                {
                    timeLog = Convert.ToDateTime(timeSpan.Hour + ":00:00");
                }
                else if (DateTime.Compare(timeSpan, secondQuarter) < 0)
                {
                    timeLog = Convert.ToDateTime(timeSpan.Hour + ":15:00");
                }
                else if (DateTime.Compare(timeSpan, thirdQuarter) < 0)
                {
                    timeLog = Convert.ToDateTime(timeSpan.Hour + ":30:00");
                }
                else if (DateTime.Compare(timeSpan, fourthQuarter) < 0)
                {
                    timeLog = Convert.ToDateTime(timeSpan.Hour + ":45:00");
                }
                else if (DateTime.Compare(timeSpan, fourthQuarter) > 0)
                {
                    timeLog = Convert.ToDateTime((timeSpan.Hour + 1) + ":00:00");
                }

            }
            return timeLog;
        }
        internal static void loggingTime(DateTime loggingTime)
        {
            // TODO for the database
        }
    }
}

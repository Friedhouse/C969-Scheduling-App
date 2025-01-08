using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Scheduling_App
{
    public static class TimeZoneHelper
    {
        /// <summary>
        /// Converts a UTC DateTime to the local time zone.
        /// </summary>
        /// <param name="utcDateTime">The UTC DateTime.</param>
        /// <returns>The DateTime converted to the local time zone.</returns>
        public static DateTime ConvertToLocalTime(DateTime utcDateTime)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local; // User's local time zone
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, localTimeZone);
        }

        /// <summary>
        /// Converts a local DateTime to UTC.
        /// </summary>
        /// <param name="localDateTime">The local DateTime.</param>
        /// <returns>The DateTime converted to UTC.</returns>
        public static DateTime ConvertToUtc(DateTime localDateTime)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local; // User's local time zone
            return TimeZoneInfo.ConvertTimeToUtc(localDateTime, localTimeZone);
        }
    }
}

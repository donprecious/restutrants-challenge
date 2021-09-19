using System;
using System.Globalization;

namespace ResturantsOpenApi.Utility
{
    public static class AppUtility
    {
        public static DateTime ConvertUnixToTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            
            return dateTime;
        }

        public static string GetTimeFromDate(DateTime dateTime) => dateTime.ToString("h:mm tt");

        public static string ConvertUnixToTimeString(double unixTimeStamp)
        {
            var date = ConvertUnixToTime(unixTimeStamp);
            var timeString = GetTimeFromDate(date);
            return timeString;
        }
    }
}
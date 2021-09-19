using System.Collections.Generic;
using System.Linq;
using ResturantsOpenApi.Models;
using ResturantsOpenApi.Utility;

namespace ResturantsOpenApi.Services.RestaurantService
{
    public class RestaurantService : IRestaurantService
    {

        public Dictionary<DayOfWeekEnum, string>  ProcessSession(Dictionary<DayOfWeekEnum, List<RestaurantHour>> record)
        {
            var sunday = record.FirstOrDefault(a => a.Key == DayOfWeekEnum.Sunday).Value;
            var sundaySessions = new RestaurantSession(DayOfWeekEnum.Sunday, sunday); 

            var monday = record.FirstOrDefault(a => a.Key == DayOfWeekEnum.Monday).Value;
            var mondaySessions = new RestaurantSession(DayOfWeekEnum.Monday, monday);

            var tuesday = record.FirstOrDefault(a => a.Key == DayOfWeekEnum.Tuesday).Value;
            var tuesdaySessions = new RestaurantSession(DayOfWeekEnum.Tuesday, tuesday);

            var wednesday = record.FirstOrDefault(a => a.Key == DayOfWeekEnum.Wednesday).Value;
            var wednesdaySessions = new RestaurantSession(DayOfWeekEnum.Wednesday, wednesday);

            var thursday = record.FirstOrDefault(a => a.Key == DayOfWeekEnum.Thursday).Value;
            var thursdaySessions = new RestaurantSession(DayOfWeekEnum.Thursday, thursday);

            var friday = record.FirstOrDefault(a => a.Key == DayOfWeekEnum.Friday).Value;
            var fridaySessions = new RestaurantSession(DayOfWeekEnum.Friday, friday);

            var saturday = record.FirstOrDefault(a => a.Key == DayOfWeekEnum.Saturday).Value;
            var saturdaySessions = new RestaurantSession(DayOfWeekEnum.Saturday, saturday);

            mondaySessions.SetPreviousDayClosingSession(sundaySessions);
            tuesdaySessions.SetPreviousDayClosingSession(mondaySessions);
            wednesdaySessions.SetPreviousDayClosingSession(tuesdaySessions);
            thursdaySessions.SetPreviousDayClosingSession(wednesdaySessions);
            fridaySessions.SetPreviousDayClosingSession(thursdaySessions);
            saturdaySessions.SetPreviousDayClosingSession(fridaySessions);
          
            var sessions = new Dictionary<DayOfWeekEnum, string>()
            {
                {DayOfWeekEnum.Sunday, ProcessOpeningAndClosingTime(sundaySessions) },
                {DayOfWeekEnum.Monday, ProcessOpeningAndClosingTime(mondaySessions)},
                {DayOfWeekEnum.Tuesday, ProcessOpeningAndClosingTime(tuesdaySessions)},
                {DayOfWeekEnum.Wednesday, ProcessOpeningAndClosingTime(wednesdaySessions)},
                {DayOfWeekEnum.Thursday, ProcessOpeningAndClosingTime(thursdaySessions)},
                {DayOfWeekEnum.Friday, ProcessOpeningAndClosingTime(fridaySessions)},
                {DayOfWeekEnum.Saturday, ProcessOpeningAndClosingTime(saturdaySessions)},
            };
            return sessions;
        }

        private string ProcessOpeningAndClosingTime(RestaurantSession session)
        {
            var message = "";
            if (session.OpeningHour.Count < 1)
            {
                return message = "closed";
            }
            for (int i = 0; i < session.OpeningHour.Count; i++)
            {
                var openingTime = AppUtility.ConvertUnixToTimeString(session.OpeningHour[i].Value);
                var closingTime = "";
                if (session.ClosingHour[i] != null)
                {
                    closingTime = AppUtility.ConvertUnixToTimeString(session.ClosingHour[i].Value);
                }

                message += $"{openingTime} - {closingTime} ,";
            }

           return  message.TrimEnd(','); 
        }
    
       
        
        
    }
}
using System.Collections.Generic;
using System.Linq;
using ResturantsOpenApi.Utility;

namespace ResturantsOpenApi.Models
{
    public  class RestaurantSession
    {
        public List<string> Sessions = new List<string>();

        public bool hasClosed = true;
        public RestaurantHour PreviousDayClosingHour = new RestaurantHour();
        public List<RestaurantHour> OpeningHour { get; set; } = new List<RestaurantHour>();
        public List<RestaurantHour> ClosingHour { get; set; } = new List<RestaurantHour>();

        public void SetPreviousDayClosingSession(RestaurantSession previousDay)
        {
            
            if (previousDay.hasClosed == false)
            {
                previousDay.ClosingHour.Add(PreviousDayClosingHour);
            }
        }
        
        public RestaurantSession(DayOfWeekEnum dayOfWeek, List<RestaurantHour> openingAndClosingHours)
        {
            if(openingAndClosingHours == null || !openingAndClosingHours.Any())
            {
                Sessions.Add("closed");
                this.hasClosed = true;
                return;
            }

            if (openingAndClosingHours.Count == 1)
            {
                var hour = openingAndClosingHours.FirstOrDefault();
                if (hour.Type.ToLower() == "open")
                {
                    hasClosed = false; 
                }
                OpeningHour = openingAndClosingHours.Where(a => a.Type.ToLower() == "open").ToList();
                Sessions.Add($"opens at - {AppUtility.GetTimeFromDate(AppUtility.ConvertUnixToTime(hour.Value))}");
                return;
            }else if (openingAndClosingHours.Count % 2 != 0)
            {
                var previousDayClosingSession = openingAndClosingHours.FirstOrDefault(a => a.Type.ToLower() == "close");
                if (previousDayClosingSession != null)
                {
                    PreviousDayClosingHour = previousDayClosingSession;
                    openingAndClosingHours.Remove(PreviousDayClosingHour);
                    OpeningHour = openingAndClosingHours.Where(a => a.Type.ToLower() == "open").ToList();
                    ClosingHour = openingAndClosingHours.Where(a => a.Type.ToLower() == "close").ToList();
                }
            }
            else
            {
                OpeningHour = openingAndClosingHours.Where(a => a.Type.ToLower() == "open").ToList();
                ClosingHour = openingAndClosingHours.Where(a => a.Type.ToLower() == "close").ToList();
            }
           
        }
    }
}
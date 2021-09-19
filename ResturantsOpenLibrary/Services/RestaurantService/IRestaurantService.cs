using System.Collections.Generic;
using ResturantsOpenApi.Models;


namespace ResturantsOpenApi.Services.RestaurantService
{
    public interface IRestaurantService
    {
        Dictionary<DayOfWeekEnum, string> ProcessSession(Dictionary<DayOfWeekEnum, List<RestaurantHour>> record);
    }
}
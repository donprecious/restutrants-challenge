using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResturantsOpenApi.Models;
using ResturantsOpenApi.Services.RestaurantService;
using ResturantsOpenApi.Utility;

namespace ResturantsOpenApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResturantController : ControllerBase
    {
        
        private readonly ILogger<ResturantController> _logger;
        private readonly IRestaurantService _restaurantService;
        public ResturantController(ILogger<ResturantController> logger, IRestaurantService restaurantService)
        {
            _logger = logger;
            _restaurantService = restaurantService;
        }

        [HttpPost("opening-hours")]
     
        public IActionResult OpeningHours([FromBody] Dictionary<DayOfWeekEnum, List<RestaurantHour>> record)
        {
            var result = _restaurantService.ProcessSession(record);
            return Ok(result); 
        }
    }
}
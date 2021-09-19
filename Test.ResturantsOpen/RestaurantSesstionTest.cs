using System.Collections.Generic;
using ResturantsOpenApi.Models;
using Xunit;

namespace Test.ResturantsOpen
{
    public class RestaurantSesstionTest
    {
        [Fact]
        public void ShouldHasClosed()
        {
            //arrange 
            var session = new RestaurantSession(DayOfWeekEnum.Monday, new List<RestaurantHour>());
            // act 
            // assert 
            Assert.True(session.hasClosed); 
            Assert.Empty(session.OpeningHour);
            Assert.Empty(session.ClosingHour);
        }

        [Fact]
        public void ShouldHasMultipleDays()
        {
            //arrange 
            var session = new RestaurantSession(DayOfWeekEnum.Monday, new List<RestaurantHour>()
            {
                new RestaurantHour()
                {
                    Type = "open",
                    Value = 3200,
                },
                new RestaurantHour()
                {
                    Type = "close",
                    Value = 5200,
                },
                new RestaurantHour()
                {
                    Type = "open",
                    Value = 4200,
                },
                new RestaurantHour()
                {
                    Type = "close",
                    Value = 6200,
                }
            }); 
            
            // act  
            var openingHours = session.OpeningHour;
            var closingHours = session.ClosingHour;
            // assert  
            Assert.True(openingHours.Count>1);
            Assert.True(closingHours.Count>1);

        }

        [Fact]
        public void ShouldHasSpanNextMultipleDays()
        {
            //arrange 
            var mondaySession = new RestaurantSession(DayOfWeekEnum.Monday, new List<RestaurantHour>()
            {
                new RestaurantHour()
                {
                    Type = "open",
                    Value = 3200,
                }
            });
            var tuesdaySession = new RestaurantSession(DayOfWeekEnum.Tuesday, new List<RestaurantHour>()
            {
                new RestaurantHour()
                {
                    Type = "close",
                    Value = 5200,
                },
                new RestaurantHour()
                {
                    Type = "open",
                    Value = 4200,
                },
                new RestaurantHour()
                {
                    Type = "close",
                    Value = 6200,
                }
            });
          
            // act  
            tuesdaySession.SetPreviousDayClosingSession(mondaySession); 
            // assert   

            Assert.True(mondaySession.ClosingHour.Count >= 1);

        }
        
        
    }
}
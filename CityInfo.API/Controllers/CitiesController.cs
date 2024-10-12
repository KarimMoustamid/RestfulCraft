namespace CityInfo.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;


    [ApiController]
    public class CitiesController : ControllerBase
    {
        [HttpGet("api/Cities")]
        public JsonResult GetCities()
        {
            return new JsonResult(new List<object>
            {
                new {id = 1 , Name = "Paris"},
                new {id = 2 , Name = "New York"},
                new {id = 3 , Name = "Tokyo"},
                new {id = 4 , Name = "London"},
                new {id = 5 , Name = "Sydney"}
            });
        }
    }
}
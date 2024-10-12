namespace CityInfo.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;


    [ApiController]
    [Route("api/cities")]
    // [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return this.Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        {
            var cityToReturn = new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id));

            if (cityToReturn is null)
            {
                return this.NotFound();
            }

            return this.Ok(cityToReturn);
        }
    }
}
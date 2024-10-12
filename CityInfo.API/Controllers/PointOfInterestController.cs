namespace CityInfo.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<IEnumerator<PointOfInterestDto>> GetPointOfInterests(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city is null)
            {
                return NotFound();
            }

            return this.Ok(city.PointOfInterests);
        }

        [HttpGet("{pointOfInterestId}")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city is null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointOfInterests.FirstOrDefault(p => p.Id == pointOfInterestId);

            if (pointOfInterest is null)
            {
                return NotFound();
            }

            return this.Ok(pointOfInterest);
        }
    }
}
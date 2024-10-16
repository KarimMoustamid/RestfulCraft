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

        [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
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

        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, PointOfInterestCreationDto pointOfInterestToBeCreated)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            // if city is null
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city is null)
            {
                return this.NotFound();
            }

            // to be improved :
            var maxPointOfInterestId = city.PointOfInterests.Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterestToBeCreated.Name,
                Description = pointOfInterestToBeCreated.Description,
            };

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    cityId, pointOfInterestId = finalPointOfInterest.Id
                },
                finalPointOfInterest);
        }

        [HttpPut("{pointOfInterestId}")]
        public ActionResult<PointOfInterestDto> UpdatePointOfInterest(int cityId, int pointOfInterestId, [FromBody] PointOfInterestUpdateDto pointOfInterestDataToBeUpdated)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city is null)
            {
                return this.NotFound();
            }

            var pointOfInterest = city.PointOfInterests.FirstOrDefault(p => p.Id == pointOfInterestId);


            if (pointOfInterest is null)
            {
                return this.NotFound();
            }

            var updatedPointOfInterest = new PointOfInterestDto
            {
                Id = pointOfInterestId,
                Name = pointOfInterestDataToBeUpdated.Name,
                Description = pointOfInterestDataToBeUpdated.Description
            };

            return this.Ok(updatedPointOfInterest);
            // return this.NoContent();
        }
    }
}
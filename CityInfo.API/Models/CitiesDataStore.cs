namespace CityInfo.API.Models
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            // Init dummy data
            Cities = new List<CityDto>
            {
                new CityDto
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointOfInterests = new List<PointOfInterestDto>
                    {
                        new PointOfInterestDto
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "A large public park in New York City."
                        },
                        new PointOfInterestDto
                        {
                            Id = 2,
                            Name = "Statue of Liberty",
                            Description = "Colossal neoclassical sculpture on Liberty Island."
                        }
                    }
                },
                new CityDto
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished."
                },
                new CityDto
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower."
                },
                new CityDto
                {
                    Id = 4,
                    Name = "Tokyo",
                    Description = "The one with the busy crosswalk.",
                    PointOfInterests = new List<PointOfInterestDto>
                    {
                        new PointOfInterestDto
                        {
                            Id = 3,
                            Name = "Shibuya Crossing",
                            Description = "Famous pedestrian scramble crossing."
                        },
                        new PointOfInterestDto
                        {
                            Id = 4,
                            Name = "Tokyo Tower",
                            Description = "Communications and observation tower."
                        }
                    }
                },
                new CityDto
                {
                    Id = 5,
                    Name = "Sydney",
                    Description = "The one with the famous opera house.",
                    PointOfInterests = new List<PointOfInterestDto>
                    {
                        new PointOfInterestDto
                        {
                            Id = 5,
                            Name = "Sydney Opera House",
                            Description = "Multi-venue performing arts centre."
                        },
                        new PointOfInterestDto
                        {
                            Id = 6,
                            Name = "Harbour Bridge",
                            Description = "Steel through arch bridge."
                        }
                    }
                }
            };
        }
    }
}
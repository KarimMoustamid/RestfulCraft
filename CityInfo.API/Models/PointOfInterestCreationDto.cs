namespace CityInfo.API.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PointOfInterestCreationDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }

    }
}
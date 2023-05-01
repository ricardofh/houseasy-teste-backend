using System.ComponentModel.DataAnnotations;

namespace HouseasyApi.Data.Dto
{
    public class OcupationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}

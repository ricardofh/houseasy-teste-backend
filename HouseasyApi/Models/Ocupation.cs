using System.ComponentModel.DataAnnotations;

namespace HouseasyApi.Models
{
    public class Ocupation
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}

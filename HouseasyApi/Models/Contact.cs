using System.ComponentModel.DataAnnotations;

namespace HouseasyApi.Models
{
    public class Contact
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }
    }
}

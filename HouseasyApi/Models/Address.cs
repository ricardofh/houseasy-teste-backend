using System.ComponentModel.DataAnnotations;

namespace HouseasyApi.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]        
        public string Cep { get; set; }
        
        [Required]        
        public string State { get; set; }
        
        [Required]        
        public string City { get; set; }
        
        [Required]
        public string District { get; set; }
        
        [Required]
        public string Street { get; set; }
        
        [Required]
        public string Number { get; set; }
        
        public string Complement { get; set; }

    }
}

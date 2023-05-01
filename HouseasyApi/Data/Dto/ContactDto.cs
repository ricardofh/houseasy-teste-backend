using System.ComponentModel.DataAnnotations;

namespace HouseasyApi.Data.Dto;

public class ContactDto
{
    [Required]
    public string Phone { get; set; }

    [Required]
    public string Email { get; set; }
}

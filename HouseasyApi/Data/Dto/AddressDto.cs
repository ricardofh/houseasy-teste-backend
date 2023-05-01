using System.ComponentModel.DataAnnotations;

namespace HouseasyApi.Data.Dto;

public class AddressDto
{
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

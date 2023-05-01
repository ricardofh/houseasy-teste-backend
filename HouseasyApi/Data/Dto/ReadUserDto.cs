using HouseasyApi.Models;

namespace HouseasyApi.Data.Dto
{
    public class ReadUserDto
    {
        public string Name { get; set; }

        public AddressDto Address { get; set; }
        public OcupationDto Ocupation { get; set; }
        public ContactDto Contact { get; set; }


    }
}

using AutoMapper;
using HouseasyApi.Data.Dto;
using HouseasyApi.Models;

namespace HouseasyApi.Util;

public class Mapper : Profile
{
    public Mapper() {
        CreateMap<ContactDto, Contact>();
        CreateMap<Contact, ContactDto>();

        CreateMap<AddressDto, Address>();
        CreateMap<Address, AddressDto>();

        CreateMap<OcupationDto, Ocupation>();
        CreateMap<Ocupation, OcupationDto>();

        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();

    }
}

using AutoMapper;
using HouseasyApi.Data;
using HouseasyApi.Data.Dto;
using HouseasyApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace HouseasyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private HouseasyContext _context;
    private IMapper _mapper;

    public AddressController(HouseasyContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um endereço ao banco de dados
    /// </summary>
    /// <param name="addressDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult createAddress([FromBody] AddressDto addressDto)
    {
        Address address = _mapper.Map<Address>(addressDto);
        _context.Address.Add(address);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAddressById),
            new { id = address.Id },
            address);
    }

    /// <summary>
    /// Recupera as informações de um endereço
    /// </summary>
    /// <param name="id">id do endereço que está cadastrado no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAddressById(int id)
    {
        var address = _context.Address
            .FirstOrDefault(address => address.Id == id);
        if (address == null) return NotFound();
        var addressDto = _mapper.Map<AddressDto>(address);
        return Ok(addressDto);
    }

    /// <summary>
    /// Atualiza as informações de um endereço
    /// </summary>
    /// <param name="id">id do endereço que está cadastrado no banco de dados</param>
    /// <param name="addressDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a atualização seja feita com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult UpdateAdress(int id,[FromBody] AddressDto addressDto)
    {
        var address = _context.Address.FirstOrDefault(
            address => address.Id == id);
        if (address == null) return NotFound();
        _mapper.Map(addressDto, address);
        _context.SaveChanges();
        return Ok();
    }

    /// <summary>
    /// Remove as informações de um endereço
    /// </summary>
    /// <param name="id">id do endereço que está cadastrado no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a remoção seja feita com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult RemoveAddress(int id)
    {
        var address = _context.Address.FirstOrDefault(
            address => address.Id == id);
        if (address == null) return NotFound();
        _context.Remove(address);
        _context.SaveChanges();
        return Ok();
    }

}

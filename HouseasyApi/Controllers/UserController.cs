using AutoMapper;
using HouseasyApi.Data;
using HouseasyApi.Data.Dto;
using HouseasyApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseasyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private HouseasyContext _context;
    private IMapper _mapper;

    public UserController(HouseasyContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um usuário ao banco de dados
    /// </summary>
    /// <param name="userDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult createUser([FromBody] UserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);
        _context.Users.Add(user);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetUserById),
            new { id = user.Id },
            userDto);
    }

    /// <summary>
    /// Recupera as informações de um usuário
    /// </summary>
    /// <param name="id">id do usuário que está cadastrado no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetUserById(int id)
    {
        var user = _context.Users
                .FirstOrDefault(user => user.Id == id);

        if(user == null) return NotFound();

        var address = _context.Address
                .FirstOrDefault(address => address.Id == user.IdAdress);
        var addressDto = _mapper.Map<AddressDto>(address);

        var ocupation = _context.Ocupation
                .FirstOrDefault(ocupation => ocupation.Id == user.IdOccupation);
        var ocupationDto = _mapper.Map<OcupationDto>(ocupation);

        var contact = _context.Contact
                .FirstOrDefault(contact => contact.Id == user.IdContact);
        var contactDto = _mapper.Map<ContactDto>(contact);

        return Ok(new ReadUserDto
        {
            Name = user.Name,
            Address = addressDto,
            Contact = contactDto,
            Ocupation = ocupationDto

        });

    }

    /// <summary>
    /// Atualiza as informações de um usuário
    /// </summary>
    /// <param name="id">id do usuário que está cadastrado no banco de dados</param>
    /// <param name="userDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a atualização seja feita com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult UpdateUser(int id,
        [FromBody] UserDto userDto)
    {
        var user = _context.Users.FirstOrDefault(
            user => user.Id == id);
        if (user == null) return NotFound();
        _mapper.Map(userDto, user);
        _context.SaveChanges();
        return Ok();
    }

    /// <summary>
    /// Remove as informações de um usuário
    /// </summary>
    /// <param name="id">id do usuário que está cadastrado no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a remoção seja feita com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult RemoveUser(int id)
    {
        var user = _context.Users.FirstOrDefault(
            user => user.Id == id);
        if (user == null) return NotFound();
        _context.Remove(user);
        _context.SaveChanges();
        return Ok();
    }
}

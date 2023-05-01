using AutoMapper;
using HouseasyApi.Data;
using HouseasyApi.Data.Dto;
using HouseasyApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HouseasyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
    private HouseasyContext _context;
    private IMapper _mapper;

    public ContactController(HouseasyContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um contato ao banco de dados
    /// </summary>
    /// <param name="contactDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult createContact([FromBody] ContactDto contactDto)
    {
        Contact contact = _mapper.Map<Contact>(contactDto);
        _context.Contact.Add(contact);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetContactById),
            new { id = contact.Id },
            contact);
    }

    /// <summary>
    /// Recupera as informações de um contato
    /// </summary>
    /// <param name="id">id do endereço que está cadastrado no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetContactById(int id)
    {
        var contact = _context.Contact
            .FirstOrDefault(contact => contact.Id == id);
        if (contact == null) return NotFound();
        var contactDto = _mapper.Map<ContactDto>(contact);
        return Ok(contactDto);
    }

    /// <summary>
    /// Atualiza as informações de um contato
    /// </summary>
    /// <param name="id">id do contato que está cadastrado no banco de dados</param>
    /// <param name="contactDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a atualização seja feita com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult UpdateContact(int id,[FromBody] ContactDto contactDto)
    {
        var contact = _context.Contact.FirstOrDefault(
            contact => contact.Id == id);
        if (contact == null) return NotFound();
        _mapper.Map(contactDto, contact);
        _context.SaveChanges();
        return Ok();
    }

    /// <summary>
    /// Remove as informações de um contato
    /// </summary>
    /// <param name="id">id do contato que está cadastrado no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a remoção seja feita com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult RemoveContact(int id)
    {
        var contact = _context.Contact.FirstOrDefault(
            contact => contact.Id == id);
        if (contact == null) return NotFound();
        _context.Remove(contact);
        _context.SaveChanges();
        return Ok();
    }

}

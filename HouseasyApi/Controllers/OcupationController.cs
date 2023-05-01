using AutoMapper;
using HouseasyApi.Data;
using HouseasyApi.Data.Dto;
using HouseasyApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HouseasyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OcupationController : ControllerBase
    {
        private HouseasyContext _context;
        private IMapper _mapper;

        public OcupationController(HouseasyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um ocupação ao banco de dados
        /// </summary>
        /// <param name="ocupationDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult createOcupation([FromBody] OcupationDto ocupationDto)
        {
            Ocupation ocupation = _mapper.Map<Ocupation>(ocupationDto);
            _context.Ocupation.Add(ocupation);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetOcupationById),
                new { id = ocupation.Id },
                ocupation);
        }

        /// <summary>
        /// Recupera as informações de um ocupação
        /// </summary>
        /// <param name="id">id do ocupação que está cadastrado no banco de dados</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a busca seja feita com sucesso</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetOcupationById(int id)
        {
            var ocupation = _context.Contact
                .FirstOrDefault(ocupation => ocupation.Id == id);
            if (ocupation == null) return NotFound();
            var ocupationDto = _mapper.Map<OcupationDto>(ocupation);
            return Ok(ocupationDto);
        }

        /// <summary>
        /// Atualiza as informações de um ocupação
        /// </summary>
        /// <param name="id">id do ocupação que está cadastrado no banco de dados</param>
        /// <param name="ocupationDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a atualização seja feita com sucesso</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateOcupation(int id, [FromBody] OcupationDto ocupationDto)
        {
            var ocupation = _context.Ocupation.FirstOrDefault(
                ocupation => ocupation.Id == id);
            if (ocupation == null) return NotFound();
            _mapper.Map(ocupationDto, ocupation);
            _context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Remove as informações de um ocupação
        /// </summary>
        /// <param name="id">id do ocupação que está cadastrado no banco de dados</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a remoção seja feita com sucesso</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult RemoveOcupation(int id)
        {
            var ocupation = _context.Ocupation.FirstOrDefault(
                ocupation => ocupation.Id == id);
            if (ocupation == null) return NotFound();
            _context.Remove(ocupation);
            _context.SaveChanges();
            return Ok();
        }

    }
}
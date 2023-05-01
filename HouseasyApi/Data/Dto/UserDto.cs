using System.ComponentModel.DataAnnotations;

namespace HouseasyApi.Data.Dto
{
    public class UserDto
    {
        public int IdAdress { get; set; }
        [Required(ErrorMessage = "O id do contato é obrigatório")]
        public int IdContact { get; set; }
        [Required(ErrorMessage = "O id da ocupação é obrigatório")]
        public int IdOccupation { get; set; }
        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        public string Name { get; set; }
    }
}

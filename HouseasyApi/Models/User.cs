using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseasyApi.Models;

public class User
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage ="O id do endereço é obrigatório")]
    public int IdAdress { get; set; }
    [Required(ErrorMessage = "O id do contato é obrigatório")]
    public int IdContact { get; set; }
    [Required(ErrorMessage = "O id da ocupação é obrigatório")]
    public int IdOccupation { get; set; }
    [Required(ErrorMessage = "O nome do usuário é obrigatório")]
    public string Name { get; set; }

    [ForeignKey("IdAdress")]
    public virtual Address Address { get; set; }

    [ForeignKey("IdContact")]
    public virtual Contact Contact { get; set; }

    [ForeignKey("IdOccupation")]
    public virtual Ocupation Ocupation { get; set; }

}

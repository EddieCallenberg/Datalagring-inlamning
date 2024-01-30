using System.ComponentModel.DataAnnotations;

namespace Datalagringinlmnec.Entities;

public class RoleEntity
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string RoleName { get; set; } = null!;
}

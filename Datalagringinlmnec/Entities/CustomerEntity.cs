using System.ComponentModel.DataAnnotations;

namespace Datalagringinlmnec.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Required, StringLength(50)]
    public string LastName { get; set; } = null!;

    [Required, StringLength(50)]
    public string Email { get; set; } = null!;

    public int RoleId { get; set; }

    public int AdressId { get; set; }

    public RoleEntity Role { get; set; } = null!;

    public AdressEntity Adress { get; set; } = null!;
}

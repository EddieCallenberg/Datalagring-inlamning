using System.ComponentModel.DataAnnotations;

namespace Datalagringinlmnec.Entities;

public class AdressEntity
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string StreetName { get; set; } = null!;

    [Required, StringLength(50)]
    public string PostalCode { get; set; } = null!;

    [Required, StringLength(50)]
    public string City { get; set; } = null!;
}

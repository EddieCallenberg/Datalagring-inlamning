using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datalagringinlmnec.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string ProductName { get; set; } = null!;

    [Required]
    public decimal ProductPrice { get; set; }

    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
}

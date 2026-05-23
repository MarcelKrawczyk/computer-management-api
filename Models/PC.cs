using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerManagementApi.Models;

public class PC
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [Column(TypeName = "float")]
    public float Weight { get; set; }

    [Required]
    public int Warranty { get; set; }

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Required]
    public int Stock { get; set; }

    public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}

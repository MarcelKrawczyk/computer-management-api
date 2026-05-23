using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerManagementApi.Models;

public class PCComponent
{
    [Required]
    public int PCId { get; set; }

    [Required]
    [MaxLength(10)]
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } = null!;

    [Required]
    public int Amount { get; set; }

    [ForeignKey(nameof(PCId))]
    public PC PC { get; set; } = null!;

    [ForeignKey(nameof(ComponentCode))]
    public Component Component { get; set; } = null!;
}

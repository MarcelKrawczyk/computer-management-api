using System.ComponentModel.DataAnnotations;

namespace ComputerManagementApi.DTOs;

public class PcCreateDto
{
    [Required]
    public string Name { get; set; } = null!;
    public float Weight { get; set; }
    [Range(1, 120)]
    public int Warranty { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public int Stock { get; set; }
}

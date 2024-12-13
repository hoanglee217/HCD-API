using System.ComponentModel.DataAnnotations;

namespace Hcd.Common.Models;

public class PaginationRequest
{
    public string? Search { get; set; }
    public string? Filter { get; set; }
    public bool UseCountTotal { get; set; } = false;

    public string? OrderBy { get; set; }
    public string? OrderDirection { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public required int Page { get; set; } = 1;

    [Required]
    [Range(1, 1000)]
    public required int PageSize { get; set; } = 20;
}

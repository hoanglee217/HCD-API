﻿namespace Hcd.Common.Models;

public class PaginationMeta
{
    public int? TotalItems { get; set; }
    public int? PageCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Management.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        public static readonly string[] posts = new[]
        {
            "book1",
            "book2",
            "book3",
            "book4",
            "book5",
        };
        // private readonly ILogger<BlogController> logger;
        // public BlogController(ILogger<BlogController> _logger)
        // {
        //     _logger = logger;
        // }

        // [HttpGet](Name = 'blog')]
        // public IEnumerable<Blog> Get()
        // {
        //     return posts.ToArray();
        // }
    }
}
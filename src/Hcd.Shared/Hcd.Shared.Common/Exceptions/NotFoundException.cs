using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;

namespace Hcd.Shared.Common.Exceptions
{
    public class NotFoundException(string message) : Exception(message)
    {
    }
}
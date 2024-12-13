using Microsoft.AspNetCore.Identity;

namespace Hcd.Common.Exceptions;

public class IdentityException(IEnumerable<IdentityError> errors) : Exception
{
    public IEnumerable<IdentityError> Errors { get; } = errors;
}

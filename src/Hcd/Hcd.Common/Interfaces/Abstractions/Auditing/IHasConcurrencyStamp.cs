namespace Hcd.Common.Interfaces.Abstractions.Auditing;

public interface IHasConcurrencyStamp
{
    string ConcurrencyStamp { get; set; }
}
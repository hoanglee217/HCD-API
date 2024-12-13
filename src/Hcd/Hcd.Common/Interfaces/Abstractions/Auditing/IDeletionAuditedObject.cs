namespace Hcd.Common.Interfaces.Abstractions.Auditing;

public interface IDeletionAuditedObject
{
    DateTime? DeletionTime { get; set; }
    Guid? DeleterId { get; set; }
}

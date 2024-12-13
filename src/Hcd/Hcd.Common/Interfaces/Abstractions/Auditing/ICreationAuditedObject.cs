namespace Hcd.Common.Interfaces.Abstractions.Auditing;

public interface ICreationAuditedObject
{
    DateTime CreationTime { get; set; }
    Guid? CreatorId { get; set; }
}

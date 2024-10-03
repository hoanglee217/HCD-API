namespace Hcd.Data.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string? TableName { get; set; }
        public string? EntityId { get; set; }
        public string? Action { get; set; } // "Insert", "Update", "Delete"
        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        public DateTime ChangeTime { get; set; }
        public string? ChangedBy { get; set; }
    }
}
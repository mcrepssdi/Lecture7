namespace Lecture7.Models;

public class OrdersAudit
{
    public int AuditId { get; set; }
    public int Orderid { get; set; }
    public string Action { get; set; }
    public string Description { get; set; }
    public DateTime LastUpdatedTime { get; set; }
    public string ChangedBy { get; set; }
}
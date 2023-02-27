using System.Data.SqlClient;
using System.Text;
using Dapper;
using Lecture7.Models;


Console.WriteLine("Hello, World!");

const string connstr 
    = "Server=DESKTOP-IFN84LU\\SQLEXPRESS01;Database=Lab1;Trusted_Connection=True;";

using SqlConnection conn = new(connstr);
try
{
    conn.Open();
    conn.ChangeDatabase("Week4");
    Console.WriteLine("Connection Opened");
    
    string isql = "INSERT INTO dbo.Orders (Description, LastUpdatedTime) VALUES (@Desc,@Time)";
    DynamicParameters dp = new();
    dp.Add("@Desc", "HERE IS A DESC");
    dp.Add("@Time", DateTime.Now);
    int rowsAffected = conn.Execute(isql, dp);
    Console.WriteLine($"Rows Affected: {rowsAffected}");
    
    // Simple Select Statements
    string sql = "SELECT * FROM dbo.OrdersAudit";
    IEnumerable<OrdersAudit> orders = conn.Query<OrdersAudit>(sql);
    IEnumerable<OrdersAudit> audits = from s in orders where s.Description is not null select s;
    
    audits.ToList().ForEach(p =>
    {
        StringBuilder sb = new();
        sb.Append("AuditId: ").Append(p.AuditId).Append(", ");
        sb.Append("OrderId: ").Append(p.Orderid).Append(", ");
        sb.Append("Description: ").Append(p.Description).Append(", ");
        sb.Append("Action: ").Append(p.Action).Append(", ");
        sb.Append("Timestamp: ").Append(p.LastUpdatedTime).Append(", ");
        sb.Append("ChangedBy: ").Append(p.ChangedBy);
        
        Console.WriteLine(sb.ToString());
    });
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


// Select With A Join using a Multi Grid













Console.WriteLine("Terminating");

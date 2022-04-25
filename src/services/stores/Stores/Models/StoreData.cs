namespace Stores.Models;

[DynamoDBTable("stores")]
public class StoreData
{
    [DynamoDBHashKey]
    public Guid StoreId { get; set; }
        
    public Guid AccountId { get; set; }
        
    public string Name { get; set; }
        
    [DynamoDBVersion]
    public int? VersionNumber { get; set; }
}
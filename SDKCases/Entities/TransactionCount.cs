using AeFinder.Sdk.Entities;
using Nest;

namespace SDKCases.Entities;

public class TransactionCount : AeFinderEntity, IAeFinderEntity
{
    [Keyword] public string ContractAddress { get; set; } 
    public long Count { get; set; }
    
    [Keyword] public string TransactionId { get; set; } 
}
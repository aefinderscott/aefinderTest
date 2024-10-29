using AeFinder.Sdk.Dtos;

namespace SDKCases.GraphQL;

public class TransactionCountDto : AeFinderEntityDto
{
    public string ContractAddress { get; set; } 
    public long Count { get; set; }
    public string TransactionId { get; set; } 
}
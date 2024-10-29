using AeFinder.Sdk.Dtos;

namespace SDKCases.GraphQL;

public class TestTransferRecordDto : AeFinderEntityDto
{
    public string Symbol { get; set; }
    public string FromAddress { get; set; }
    public string ToAddress { get; set; }
    public long Amount { get; set; }
}
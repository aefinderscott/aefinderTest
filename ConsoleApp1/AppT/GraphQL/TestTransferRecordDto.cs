using AeFinder.Sdk.Dtos;

namespace TestApp.GraphQL;

public class TestTransferRecordDto : AeFinderEntityDto
{
    public string Symbol { get; set; }
    public string FromAddress { get; set; }
    public string ToAddress { get; set; }
    public long Amount { get; set; }
}
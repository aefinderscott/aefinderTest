using AeFinder.Sdk.Entities;
using Nest;

namespace SDKCases.Entities;

public class TestTransferRecord: AeFinderEntity, IAeFinderEntity
{
    [Keyword] public string Symbol { get; set; }
    [Keyword] public string FromAddress { get; set; }
    [Keyword] public string ToAddress { get; set; }
    public long Amount { get; set; }
}
using AeFinder.Sdk.Entities;
using AeFinder.Sdk.Processor;
using Nest;

namespace SDKCases.Entities;

public class Account : AeFinderEntity, IAeFinderEntity
{
    [Keyword] public string Address { get; set; }
    [Keyword] public string Symbol { get; set; }
    [Keyword] public string FeeSymbol { get; set; }
    [Keyword] public long Amount { get; set; }
    [Keyword] public long FeeSymbolAmount { get; set; }

    [Nested(Name = "LogEvents", Enabled = true, IncludeInParent = true, IncludeInRoot = true)]
    public List<LogEvent> LogEvents { get; set; }
}
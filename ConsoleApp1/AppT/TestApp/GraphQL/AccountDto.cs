using AeFinder.Sdk.Dtos;
using AeFinder.Sdk.Processor;

namespace TestApp.GraphQL;

public class AccountDto : AeFinderEntityDto
{
    public string Address { get; set; }
    public string Symbol { get; set; }
    public string FeeSymbol { get; set; }
    public long Amount { get; set; }
    public long FeeSymbolAmount { get; set; }
    public List<LogEvent> LogEvents { get; set; }
}
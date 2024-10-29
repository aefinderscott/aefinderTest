using AeFinder.Sdk.Dtos;
using AeFinder.Sdk.Processor;

namespace SDKCases.GraphQL;

public class BlockInTmpIndexDto
{
    public string InTmpBlockHash { get; set; }
    public long InTmpBlockHeight { get; set; }
    public string InTmpPreviousBlockHash { get; set; }
    // public string InTmpMiner { get; set; }
    // public string InTmpChainId { get; set; }
}
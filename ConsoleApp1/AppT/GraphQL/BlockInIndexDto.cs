using AeFinder.Sdk.Dtos;
using AeFinder.Sdk.Processor;

namespace TestApp.GraphQL;

public class BlockInIndexDto
{
    public string InBlockHash { get; set; }
    public long InBlockHeight { get; set; }
    public string InPreviousBlockHash { get; set; }
    // public string InMiner { get; set; }
    public string ChainId { get; set; }
    public BlockTmpIndexDto BlockTmpIndexDto { get; set; } = new BlockTmpIndexDto();
}
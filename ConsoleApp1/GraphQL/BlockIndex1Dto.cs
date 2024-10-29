using AeFinder.Sdk.Dtos;

namespace SDKCases.GraphQL;

public class BlockIndex1Dto : AeFinderEntityDto
{
    public string BlockHash { get; set; }
    public long BlockHeight { get; set; }
    // public string PreviousBlockHash { get; set; }
    // public string Miner { get; set; }
    // public List<string> TransactionIds { get; set; }
    // public List<BlockInIndexDto> blockIns { get; set; }
    // public BlockTmpIndexDto BlockTmpEntity { get; set; }  = new BlockTmpIndexDto();
    public BlockIndex2Dto Block2Entity { get; set; }  = new BlockIndex2Dto();
}
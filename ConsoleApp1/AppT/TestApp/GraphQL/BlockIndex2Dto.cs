using AeFinder.Sdk.Dtos;

namespace TestApp.GraphQL;

public class BlockIndex2Dto : AeFinderEntityDto
{
    public string BlockHash { get; set; }
    public long BlockHeight { get; set; }
    // public string PreviousBlockHash { get; set; }
    // public string Miner { get; set; }
    // public List<string> TransactionIds { get; set; }
    // public List<BlockInIndexDto> blockIns { get; set; }
    // public BlockTmpIndexDto BlockTmpEntity { get; set; }  = new BlockTmpIndexDto();
    public BlockIndex3Dto Block3Entity { get; set; }  = new BlockIndex3Dto();
}
using AeFinder.Sdk.Dtos;

namespace TestApp.GraphQL;

public class BlockIndexDto : AeFinderEntityDto
{
    public string BlockHash { get; set; }
    public long BlockHeight { get; set; }
    // public string PreviousBlockHash { get; set; }
    // public string Miner { get; set; }
    // public List<string> TransactionIds { get; set; }
    public string Miner { get; set; }
    public DateTime TimeTest { get; set; }
    public int? nulltest { get; set; }
    public DateTime? TimeNUllTest { get; set; }
    
    public List<BlockInIndexDto> blockIns { get; set; }
    public BlockTmpIndexDto BlockTmpEntity { get; set; }  = new BlockTmpIndexDto();
    public BlockIndex1Dto Block1Entity { get; set; }  = new BlockIndex1Dto();
}
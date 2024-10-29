using AeFinder.Sdk.Entities;
using AeFinder.Sdk.Processor;
using Nest;

namespace SDKCases.Entities;

public class Block1Entity : AeFinderEntity, IAeFinderEntity
{
    [Keyword] public string BlockHash { get; set; }
    public long BlockHeight { get; set; }
    // [Keyword] public string PreviousBlockHash { get; set; } 
    // public string Miner { get; set; }
    // public List<string> TransactionIds { get; set; }
    
    // //嵌套对象
    // [Nested(Name = "blockIns", Enabled = true, IncludeInParent = true, IncludeInRoot = true)]
    // public List<BlockInEntity> blockIns { get; set; }
    //
    // //子对象
    // public BlockTmpEntity BlockTmpEntity { get; set; } = new BlockTmpEntity();
    //子对象
    public Block2Entity Block2Entity { get; set; } = new Block2Entity();
}
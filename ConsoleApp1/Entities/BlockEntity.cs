using AeFinder.Sdk.Entities;
using AeFinder.Sdk.Processor;
using Nest;

namespace SDKCases.Entities;

public class BlockEntity : AeFinderEntity, IAeFinderEntity
{
    [Keyword] public string BlockHash { get; set; }
    public long BlockHeight { get; set; }
    // [Keyword] public string PreviousBlockHash { get; set; } 
    [Keyword] public string Miner { get; set; }
    public DateTime TimeTest { get; set; }
    public DateTime? TimeNUllTest { get; set; }
    // public List<string> TransactionIds { get; set; }
    
    [Keyword] public int? nulltest { get; set; }

    
     //嵌套对象
     [Nested(Name = "blockIns", Enabled = true, IncludeInParent = true, IncludeInRoot = true)]
     public List<BlockInEntity> blockIns { get; set; }
    
     //子对象
     public BlockTmpEntity BlockTmpEntity { get; set; } = new BlockTmpEntity();
    // 子对象
     public Block1Entity Block1Entity { get; set; } = new Block1Entity();
}
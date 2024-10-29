using AeFinder.Sdk.Entities;
using AeFinder.Sdk.Processor;
using Nest;

namespace SDKCases.Entities;

public class BlockTmpEntity
{
    [Keyword] public string TmpBlockHash { get; set; }
    public long TmpBlockHeight { get; set; }
    [Keyword] public string TmpPreviousBlockHash { get; set; } 
    // public string TmpMiner { get; set; }
    // public List<string> TmpTransactionIds { get; set; }
    
    //嵌套
    [Nested(Name = "blockInsTmp", Enabled = true, IncludeInParent = true, IncludeInRoot = true)]
    public List<BlockInTmpEntity> blockInsTmp { get; set; }
    
    public BlockTmpTmpEntity BlockTmpTmpEntity { get; set; } = new BlockTmpTmpEntity();
}

using AElf.EntityMapping.Elasticsearch.Linq;
using Nest;

namespace SDKCases.Entities;

[NestedAttributes("blockIns")]
public class BlockInEntity
{
    [Keyword] public string InBlockHash { get; set; }
    public long InBlockHeight { get; set; }
    // [Keyword] public string InPreviousBlockHash { get; set; }
    // public string InMiner { get; set; }

    [Keyword] public string ChainId { get; set; }
    
    //子对象
    public BlockTmpEntity BlockTmpEntity { get; set; } = new BlockTmpEntity();
    
}
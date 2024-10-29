
using AElf.EntityMapping.Elasticsearch.Linq;
using Nest;

namespace TestApp.Entities;

[NestedAttributes("blockInsTmp")]
public class BlockInTmpEntity
{
    public string InTmpBlockHash { get; set; }
    public long InTmpBlockHeight { get; set; }
    public string InTmpPreviousBlockHash { get; set; }
    // public string InTmpMiner { get; set; }

    // public string InTmpChainId { get; set; }
    
}
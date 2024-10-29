using AeFinder.Sdk.Entities;
using AeFinder.Sdk.Processor;
using Nest;

namespace SDKCases.Entities;

public class BlockTmpTmpEntity
{
    [Keyword] public string TmpBlockHash { get; set; }
    public long TmpBlockHeight { get; set; }
    [Keyword] public string TmpPreviousBlockHash { get; set; } 
    // public string TmpMiner { get; set; }
   
    
    
}
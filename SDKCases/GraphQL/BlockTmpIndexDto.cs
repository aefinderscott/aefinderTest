using AeFinder.Sdk.Dtos;

namespace SDKCases.GraphQL;

public class BlockTmpIndexDto
{
    public string TmpBlockHash { get; set; }
    public long TmpBlockHeight { get; set; }
    public string TmpPreviousBlockHash { get; set; }
    // public string TmpMiner { get; set; }
    // public List<string> TmpTransactionIds { get; set; }
    public List<BlockInTmpIndexDto> blockInsTmp { get; set; }
    public BlockTmpTmpIndexDto BlockTmpTmpEntity { get; set; } = new BlockTmpTmpIndexDto();
}
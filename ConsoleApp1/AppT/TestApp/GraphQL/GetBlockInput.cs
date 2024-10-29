namespace TestApp.GraphQL;

public class GetBlockInput
{
    public string ChainId { get; set; }
    public string PreviousBlockHash { get; set; }
    public string BlockHash { get; set; }
    public long BlockHeight { get; set; }
    public string InChainId { get; set; }
    public string InPreviousBlockHash { get; set; }
    public string InBlockHash { get; set; }
    public long InBlockHeight { get; set; }

    public long OrderByHe { get; set; }
    
    public long SearAfterBlockHeight { get; set; }
    
    public string SearAfterCHainId { get; set; }
    
    public string StartWithStr { get; set; }
    public string EndWithStr { get; set; }
    public string ContainsStr { get; set; }
    
    
    public long Termsop { get; set; }
}
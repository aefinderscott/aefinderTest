using AeFinder.Sdk.Dtos;

namespace TestApp.GraphQL;

public class SomeIndexDto : AeFinderEntityDto
{
    
    public string BlockHash { get; set; }
    public long BlockHeight { get; set; }
    public string Skey { get; set; }
    public long Svalue { get; set; }
}
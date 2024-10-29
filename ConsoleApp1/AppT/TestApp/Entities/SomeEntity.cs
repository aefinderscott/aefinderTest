using AeFinder.Sdk.Entities;
using AeFinder.Sdk.Processor;
using Nest;

namespace TestApp.Entities;

public class SomeEntity : AeFinderEntity, IAeFinderEntity
{
    [Keyword] public string BlockHash { get; set; }
    public long BlockHeight { get; set; }
    public string Skey { get; set; }
    public long Svalue { get; set; }
    
}
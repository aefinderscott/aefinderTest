using AeFinder.Sdk.Entities;
using Nest;

namespace TestApp.Entities;

public class TestEntity : AeFinderEntity, IAeFinderEntity
{ 
    public long Times { get; set; }
    [Text(Index = false)]public byte[] Bytes { get; set; }
}
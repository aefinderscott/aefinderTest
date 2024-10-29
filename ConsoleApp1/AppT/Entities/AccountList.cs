using AeFinder.Sdk.Entities;
using Nest;

namespace TestApp.Entities;

public class AccountList: AeFinderEntity, IAeFinderEntity
{
    public List<string> Accounts { get; set; }
}
using AeFinder.Sdk.Entities;
using Nest;

namespace SDKCases.Entities;

public class AccountList: AeFinderEntity, IAeFinderEntity
{
    public List<string> Accounts { get; set; }
}
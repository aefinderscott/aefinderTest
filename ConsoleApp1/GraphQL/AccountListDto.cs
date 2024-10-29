using AeFinder.Sdk.Dtos;

namespace SDKCases.GraphQL;

public class AccountListDto : AeFinderEntityDto
{
    public List<string> Accounts { get; set; }
}
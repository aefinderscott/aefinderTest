using AeFinder.Sdk.Dtos;

namespace TestApp.GraphQL;

public class AccountListDto : AeFinderEntityDto
{
    public List<string> Accounts { get; set; }
}
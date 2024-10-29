using AeFinder.Sdk;

namespace SDKCases.GraphQL;

public class SDKCasesSchema : AppSchema<SDKCasesQuery>
{
    public SDKCasesSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
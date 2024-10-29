using AeFinder.Sdk;

namespace TestApp.GraphQL;

public class TestAppSchema : AppSchema<TestAppQuery>
{
    public TestAppSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
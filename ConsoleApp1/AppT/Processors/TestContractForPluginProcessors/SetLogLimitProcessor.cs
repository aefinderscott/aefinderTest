using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using AElf.Contracts.TestContractForPluginContract;
using Volo.Abp.DependencyInjection;

namespace TestApp.Processors;

public class SetLogLimitProcessor : TestContractForPluginProcessorBase<SetLogLimitEvent>, ITransientDependency
{
    public override async Task ProcessAsync(SetLogLimitEvent logEvent, LogEventContext context)
    {
        var logLimit = logEvent.LogLimit;
        for (var i = 0; i < logLimit; i++)
        {
            switch (i % 3)
            {
                case 0:
                    Logger.LogDebug("Test log limit, number of calls: {0} ...", i);
                    break;
                case 1:
                    // Logger.LogTrace("Test log limit, number of calls: {0} ...", i);
                    break;
                case 2:
                    Logger.LogInformation("Test log limit, number of calls: {0} ...", i);
                    break;
            }
        }
    }
}
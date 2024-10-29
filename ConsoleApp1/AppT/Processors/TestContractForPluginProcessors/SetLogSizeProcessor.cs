using System.Text;
using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using AElf.Contracts.TestContractForPluginContract;
using Volo.Abp.DependencyInjection;

namespace TestApp.Processors;

public class SetLogSizeProcessor : TestContractForPluginProcessorBase<SetLogSizeEvent>, ITransientDependency
{
    public override async Task ProcessAsync(SetLogSizeEvent logEvent, LogEventContext context)
    {
        var logSize = logEvent.LogSize;
        Logger.LogInformation("Test log size: {0} ...", logSize);
        var builder = new StringBuilder((int)logSize);
        var startChar = 97;
        var random = new Random(DateTime.Now.Millisecond);
        for (var i = 0; i < logSize; i++)
        {
            builder.Append((char)(26 * random.NextDouble() + startChar));
        }
        Logger.LogInformation(builder.ToString());
    }
}
using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using AElf.Contracts.TestContractForPluginContract;
using SDKCases.Entities;
using Volo.Abp.DependencyInjection;

namespace SDKCases.Processors;

public class SetEntitySizeProcessor : TestContractForPluginProcessorBase<SetEntitySizeEvent>, ITransientDependency
{
    public override async Task ProcessAsync(SetEntitySizeEvent logEvent, LogEventContext context)
    {
        var size = logEvent.EntitySize;
        Logger.LogDebug("Test for set Entity Size {0} ...", size);

        var bytes = new byte[size];
        var rand = new Random(Guid.NewGuid().GetHashCode());
        rand.NextBytes(bytes);
        var testId = context.ChainId + "-" + "EntitySize";
        var currentSize = await GetEntityAsync<TestEntity>(testId);
        if (currentSize == null)
        {
            currentSize = new TestEntity
            {
                Id = testId,
                Times = 0,
                Bytes = bytes
            };
        }
        else
        {
            currentSize.Bytes = bytes;
        }

        await SaveEntityAsync(currentSize);
    }
}
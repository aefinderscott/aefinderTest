using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using AElf.Contracts.TestContractForPluginContract;
using AElf.CSharp.Core;
using TestApp.Entities;
using Volo.Abp.DependencyInjection;

namespace TestApp.Processors;

public class SetEntityLimitProcessor: TestContractForPluginProcessorBase<SetEntityLimitEvent>, ITransientDependency
{
    public override async Task ProcessAsync(SetEntityLimitEvent logEvent, LogEventContext context)
    {
        var saveTimes = logEvent.EntityLimit;
        Logger.LogDebug("Test for set Entity limit {0} ...", saveTimes);

        var b = new byte[] { };
        switch (logEvent.Type)
        {
            case "Add":
                var testId = context.ChainId + "-" + "EntityLimit";
                var currentTimes = await GetEntityAsync<TestEntity>(testId);
                if (currentTimes == null)
                {
                    currentTimes = new TestEntity
                    {
                        Id = testId,
                        Times = 0,
                        Bytes = b
                    };
                }
                else
                {
                    currentTimes.Times = 0;
                }
                await SaveEntityAsync(currentTimes);

                for (var i = 0; i < saveTimes; i++)
                {
                    currentTimes.Times = currentTimes.Times.Add(1); 
                    await SaveEntityAsync(currentTimes);
                }
                break;
            case "AddMany":
                for (var i = 0; i < saveTimes; i++)
                {
                    var id = context.ChainId + "-" + "EntityLimit" + i;
                    var times = await GetEntityAsync<TestEntity>(id);
                    if (times != null)
                    {
                        times.Times = i;
                    }
                    else
                    {
                        times = new TestEntity
                        {
                            Id = id,
                            Times = i,
                            Bytes = b
                        };
                    }
                    await SaveEntityAsync(times);
                }
                break;
            case "Delete":
                for (var i = 0; i < saveTimes; i++)
                {
                    var id = context.ChainId + "-" + "EntityLimit" + i;
                    var times = await GetEntityAsync<TestEntity>(id);
                    if (times != null)
                    {
                        times.Times = i;
                    }
                    else
                    {
                        times = new TestEntity
                        {
                            Id = id,
                            Times = i,
                            Bytes = b
                        };
                    }
                    await DeleteEntityAsync(times);
                }
                break;
            case "Mix":
                for (var i = 0; i < saveTimes.Div(2); i++)
                {
                    var id = context.ChainId + "-" + "EntityLimit" + i;
                    var times = await GetEntityAsync<TestEntity>(id);
                    if (times != null)
                    {
                        times.Times = i;
                    }
                    else
                    {
                        times = new TestEntity
                        {
                            Id = id,
                            Times = i,
                            Bytes = b
                        };
                    }
                    await SaveEntityAsync(times);
                    await DeleteEntityAsync(times);
                }
                break;
        }
       
    }
}
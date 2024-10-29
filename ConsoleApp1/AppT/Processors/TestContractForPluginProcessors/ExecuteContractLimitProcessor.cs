using AeFinder.Sdk;
using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using AElf.Contracts.TestContractForPluginContract;
using Google.Protobuf.WellKnownTypes;
using Volo.Abp.DependencyInjection;

namespace TestApp.Processors;

public class ExecuteContractLimitProcessor : TestContractForPluginProcessorBase<ExecutedLimitEvent>, ITransientDependency
{
    private readonly IBlockChainService _blockChainService;

    public ExecuteContractLimitProcessor(IBlockChainService blockChainService)
    {
        _blockChainService = blockChainService;
    }

    public override async Task ProcessAsync(ExecutedLimitEvent logEvent, LogEventContext context)
    {
        Logger.LogDebug("Test for ViewContractAsync limit ..");
        var limit = logEvent.ExecuteLimit;
        var contract = context.Transaction.To;
        for (var i = 0; i < limit; i++)
        {
            await _blockChainService.ViewContractAsync<Empty>(context.ChainId, contract, 
                "GetExecutedLimit", new Empty());
        }
        
    }
}
using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using AElf.Contracts.TestSomeContract;
using AElfTest.Contract;
using TestApp.Entities;
using Volo.Abp.DependencyInjection;

namespace TestApp.Processors;

public  class TestSomeProcessor :  LogEventProcessorBase<SetSomeInput>, ILogEventProcessor<SetSomeInput>
{
    public override string GetContractAddress(string chainId)
    {
        return chainId switch
        {
            // "AELF" => "2LUmicHyH4RXrMjG4beDwuDsiWJESyLkgkwPdGTR8kahRzq5XS",
            "AELF" => "2coLWftsu7sgJJ768NcGug7RLcWjdmPkzojJqzeUeFufdvmBqk",
            "tDVV" => "",
            "tDVW" => "8qkb17nbd1AptKaqHJXS4GR2QJoNmvZVzUepntWQrdVFsBeSA",
            _ => throw new Exception("Unknown chain id")
        };
    }

    public override async Task ProcessAsync(SetSomeInput logEvent, LogEventContext context)
    {
        
        
        Logger.LogDebug("Block {0}, receive SetSomeInput Event", context.Block.BlockHeight);
        var someinfo = new SomeEntity()
        {
            Id = context.ChainId + "-" + context.Transaction.TransactionId,
            
            Skey =  logEvent.Key,
            Svalue =  logEvent.Value,
            BlockHeight = context.Block.BlockHeight,
            BlockHash = context.Block.BlockHash
            
        };
        await SaveEntityAsync(someinfo);

        // if (context.Block.BlockHeight % 3 == 0)
        // {
        //     Logger.LogDebug("Block {0}, DeleteEntityAsync Event", context.Block.BlockHeight);
        //     await DeleteEntityAsync(someinfo);
        // }
        
        Logger.LogWarning("LogEventProcessor Delay 60000 ms start ");

        await Task.Delay(60000);
        Logger.LogWarning("LogEventProcessor Delay 60000 ms end");
       

    }

}
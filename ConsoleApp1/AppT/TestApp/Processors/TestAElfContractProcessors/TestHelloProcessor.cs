using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using AElf.Contracts.TestSomeContract;
using AElfTest.Contract;
using TestApp.Entities;
using Volo.Abp.DependencyInjection;

namespace TestApp.Processors;

public  class TestHelloProcessor :  LogEventProcessorBase<SetValue>, ILogEventProcessor<SetValue>
{
    public override string GetContractAddress(string chainId)
    {
        return chainId switch
        {
            "AELF" => "",
            "tDVV" => "",
            "tDVW" => "8qkb17nbd1AptKaqHJXS4GR2QJoNmvZVzUepntWQrdVFsBeSA",
            _ => throw new Exception("Unknown chain id")
        };
    }
    
    public override async Task ProcessAsync(SetValue logEvent, LogEventContext context)
    {
        Logger.LogDebug("Hello  Worl d!", logEvent.Key);
        // throw new NotImplementedException();
    }
}
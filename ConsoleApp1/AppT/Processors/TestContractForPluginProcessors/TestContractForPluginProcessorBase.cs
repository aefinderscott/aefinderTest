using AeFinder.Sdk.Processor;
using AElf.CSharp.Core;

namespace TestApp.Processors;

public abstract class TestContractForPluginProcessorBase<TEvent> : LogEventProcessorBase<TEvent>, ILogEventProcessor<TEvent> 
    where TEvent: IEvent<TEvent>, new ()
{
    public override string GetContractAddress(string chainId)
    {
        return chainId switch
        {
            "AELF" => "",
            "tDVV" => "",
            "tDVW" => "",
            _ => throw new Exception("Unknown chain id")
        };
    }
}
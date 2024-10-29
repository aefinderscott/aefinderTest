using AeFinder.Sdk.Processor;
using AElf.CSharp.Core;

namespace TestApp.Processors;

public abstract class TestAElfContractProcessorBase<TEvent>:LogEventProcessorBase<TEvent>, ILogEventProcessor<TEvent> 
    where  TEvent: IEvent<TEvent>, new ()

{
    public override string GetContractAddress(string chainId)
    {
        return chainId switch
        {
            "AELF" => "2coLWftsu7sgJJ768NcGug7RLcWjdmPkzojJqzeUeFufdvmBqk",
            "tDVV" => "",
            "tDVW" => "",
            _ => throw new Exception("Unknown chain id")
        };
    }
}
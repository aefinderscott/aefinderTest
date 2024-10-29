using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using AElf.Contracts.TestSomeContract;
using SDKCases.Entities;
using Volo.Abp.DependencyInjection;

namespace SDKCases.Processors;

public class TestTransferProcessor : TransactionProcessorBase, ITransientDependency
{

    public override async Task ProcessAsync(Transaction transaction, TransactionContext context)
    {
        // Logger.LogError("{0} chaintid ", context.ChainId);
        var address1 = GetContractAddress1(context.ChainId);
        var address2 = GetContractAddress2(context.ChainId);
        var address3 = GetContractAddress3(context.ChainId);
        TransactionCount entity;
        if (transaction.To.Equals(address1))
        {
            // Logger.LogError("{0} chaintid ", context.ChainId);

            Logger.LogDebug("211807; {0} add 1 transaction about method {1} ; BlockHeight: {2}", address1, transaction.MethodName, context.Block.BlockHeight);
            
            entity = await AddCount(context.ChainId, address1, transaction.TransactionId);

            for (var i = 0; i < transaction.LogEvents.Count; i++)
            {
                var SetSomeInput = transaction.LogEvents[i];
                // SetSomeInput.EventName + "-" + SetSomeInput.ContractAddress
                Logger.LogDebug("211807; EventName: {0} ;ContractAddress: {1} ", SetSomeInput.EventName, SetSomeInput.ContractAddress);
            }
            
            
            await SaveEntityAsync(entity);

        }
        else if (transaction.To.Equals(address2))
        {
            // Logger.LogDebug("{0} add 1 transaction about method {1} ", address2, transaction.MethodName);
            // entity = await AddCount(context.ChainId, address2);
            // await SaveEntityAsync(entity);
            
            Logger.LogDebug("211807; {0} add 1 transaction about method {1} ; BlockHeight: {2}", address1, transaction.MethodName, context.Block.BlockHeight);
            entity = await AddCount(context.ChainId, address1, transaction.TransactionId);

            for (var i = 0; i < transaction.LogEvents.Count; i++)
            {
                var SetSomeInput = transaction.LogEvents[i];
                // SetSomeInput.EventName + "-" + SetSomeInput.ContractAddress
                Logger.LogDebug("211807; EventName: {0} ;ContractAddress: {1} ", SetSomeInput.EventName, SetSomeInput.ContractAddress);
            }
            
            
            await SaveEntityAsync(entity);
        }
        else if (transaction.To.Equals(address3))
        {
            // Logger.LogDebug("{0} add 1 transaction about method {1} ", address2, transaction.MethodName);
            // entity = await AddCount(context.ChainId, address2);
            // await SaveEntityAsync(entity);
            
            Logger.LogDebug("211807; {0} add 1 transaction about method {1} ; BlockHeight: {2}", address1, transaction.MethodName, context.Block.BlockHeight);
            entity = await AddCount(context.ChainId, address1, transaction.TransactionId);

            for (var i = 0; i < transaction.LogEvents.Count; i++)
            {
                var SetSomeInput = transaction.LogEvents[i];
                // SetSomeInput.EventName + "-" + SetSomeInput.ContractAddress
                Logger.LogDebug("211807; EventName: {0} ;ContractAddress: {1} ", SetSomeInput.EventName, SetSomeInput.ContractAddress);
            }
            
            
            await SaveEntityAsync(entity);
        }
        else
        {
            Logger.LogWarning("Unknown Transaction {0}, method {1}, to {2}",transaction.TransactionId, transaction.MethodName, transaction.To);
        }
        
        if (context.Block.BlockHeight == 14688721)
        {
            Logger.LogWarning("TransactionProcessor Delay 3000 ms start ");
            await Task.Delay(3000);
            Logger.LogWarning("TransactionProcessor Delay 3000 ms end");

        }
        
        
        
    }

    private async Task<TransactionCount> AddCount(string chainId, string contractAddress, string transactionId)
    {
        Guid newGuid = Guid.NewGuid();
        var contractId = chainId + "-" + contractAddress + "-" + newGuid.ToString() + "=" + transactionId;
        var entity = await GetEntityAsync<TransactionCount>(contractId);
        if (entity == null)
        {
            entity = new TransactionCount
            {
                Id = contractId,
                ContractAddress = contractAddress,
                Count = 1,
                TransactionId = transactionId
            };
        }
        else
        {
            entity.Count += 1;
        }

        return entity;
    }
    
    public string GetContractAddress1(string chainId)
    {
        return chainId switch
        {
            "AELF" => "2LUmicHyH4RXrMjG4beDwuDsiWJESyLkgkwPdGTR8kahRzq5XS",
            // "AELF" => "2coLWftsu7sgJJ768NcGug7RLcWjdmPkzojJqzeUeFufdvmBqk",
            "tDVV" => "",
            "tDVW" => "",
            _ => throw new Exception("Unknown chain id")
        };
    }
    
    public string GetContractAddress2(string chainId)
    {
        return chainId switch
        {
            "AELF" => "2coLWftsu7sgJJ768NcGug7RLcWjdmPkzojJqzeUeFufdvmBqk",
            "tDVV" => "",
            "tDVW" => "",
            _ => throw new Exception("Unknown chain id")
        };
    }
    
    public string GetContractAddress3(string chainId)
    {
        return chainId switch
        {
            "AELF" => "JRmBduh4nXWi1aXgdUsj5gJrzeZb2LxmrAbf7W99faZSvoAaE",
            "tDVV" => "",
            "tDVW" => "",
            _ => throw new Exception("Unknown chain id")
        };
    }

}
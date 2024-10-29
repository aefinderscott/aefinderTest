using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using AElf.Contracts.MultiToken;
using SDKCases.Entities;
using Volo.Abp.DependencyInjection;

namespace SDKCases.Processors;

public class TransactionFeeChargeProcessor : LogEventProcessorBase<TransactionFeeCharged> , ITransientDependency
{
    // public override string GetContractAddress(string chainId)
    // {
    //     return chainId switch
    //     {
    //         "AELF" => "JRmBduh4nXWi1aXgdUsj5gJrzeZb2LxmrAbf7W99faZSvoAaE",
    //         "tDVV" => "7RzVGiuVWkvL4VfVHdZfQF2Tri3sgLe9U991bohHFfSRZXuGX",
    //         "tDVW" => "ASh2Wt7nSEmYqnGxPPzp4pnVDU4uhj1XW9Se5VeZcX2UDdyjx",
    //         _ => throw new Exception("Unknown chain id")
    //     };
    // }
    
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

    public override async Task ProcessAsync(TransactionFeeCharged logEvent, LogEventContext context)
    {
        await ChangeBalanceAsync(context.ChainId, logEvent.ChargingAddress.ToBase58(), logEvent.Symbol, -logEvent.Amount);
    }
    
    private async Task ChangeBalanceAsync(string chainId, string address, string symbol, long amount)
    {
        var accountId = chainId + "-" + "FeeInfo" + address + symbol;
        var account = await GetEntityAsync<Account>(accountId);
        if (account == null)
        {
            account = new Account
            {
                Id = accountId,
                Symbol = "",
                Amount = 0,
                Address = address,
                FeeSymbol = symbol,
                FeeSymbolAmount = amount
            };
        }
        else
        {
            account.FeeSymbolAmount += amount;
        }

        Logger.LogDebug("Account Fee Charged: {0} {1} {2}", account.Address, account.Symbol, account.Amount);
        
        await SaveEntityAsync(account);
    }
}
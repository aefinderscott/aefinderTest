using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using AElfTest.Contract;
using SDKCases.Entities;
using Volo.Abp.DependencyInjection;

namespace SDKCases.Processors;

public class TestTransferredProcessor : TestAElfContractProcessorBase<TestTransferred>
{
    public override async Task ProcessAsync(TestTransferred logEvent, LogEventContext context)
    {
        Logger.LogDebug("Block {0}, receive TestTransferred Event", context.Block.BlockHash);
        var transfer = new TestTransferRecord
        {
            Id = context.ChainId + "-" + context.Transaction.TransactionId,
            FromAddress = logEvent.From.ToBase58(),
            ToAddress = logEvent.To.ToBase58(),
            Symbol = logEvent.Symbol,
            Amount = logEvent.Amount
        };
        await SaveEntityAsync(transfer);
        
        await ChangeBalanceAsync(context.ChainId, logEvent.From.ToBase58(), logEvent.Symbol, -logEvent.Amount);
        await ChangeBalanceAsync(context.ChainId, logEvent.To.ToBase58(), logEvent.Symbol, logEvent.Amount);
    }
    
    private async Task ChangeBalanceAsync(string chainId, string address, string symbol, long amount)
    {
        var accountId = chainId + "-" + address + symbol;
        var account = await GetEntityAsync<Account>(accountId);
        if (account == null)
        {
            account = new Account
            {
                Id = accountId,
                Symbol = symbol,
                Amount = amount,
                Address = address,
                FeeSymbol = "",
                FeeSymbolAmount = 0
            };
        }
        else
        {
            account.Amount += amount;
        }

        Logger.LogDebug("Test Balance changed: {0} {1} {2}", account.Address, account.Symbol, account.Amount);
        
        await SaveEntityAsync(account);
    }
}
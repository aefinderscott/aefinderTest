using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using AElfTest.Contract;
using SDKCases.Entities;
using AccountList = SDKCases.Entities.AccountList;

namespace SDKCases.Processors;

public class TestAccountRemovedProcessor : TestAElfContractProcessorBase<AccountRemoved>
{
    public override async Task ProcessAsync(AccountRemoved logEvent, LogEventContext context)
    {
        var id = context.ChainId + "-" + context.Transaction.To + "-AccountList";
        var accountList = await GetEntityAsync<AccountList>(id);
        accountList.Accounts.Remove(logEvent.Account.ToBase58());
        await SaveEntityAsync(accountList);

        var accountId = context.ChainId + "-" + logEvent.Account.ToBase58();
        var account = await GetEntityAsync<Account>(accountId);
        if (account != null)
        {
            Logger.LogDebug("Delete account info ... {0}", logEvent.Account.ToBase58());
            await DeleteEntityAsync(account);
        }
    }
}
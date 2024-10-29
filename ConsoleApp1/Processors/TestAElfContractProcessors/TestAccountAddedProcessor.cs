using AeFinder.Sdk.Processor;
using AElfTest.Contract;
using AccountList = SDKCases.Entities.AccountList;


namespace SDKCases.Processors;

public class TestAccountAddedProcessor : TestAElfContractProcessorBase<AccountAdded>
{
    public override async Task ProcessAsync(AccountAdded logEvent, LogEventContext context)
    {
        var id = context.ChainId + "-" + context.Transaction.To + "-AccountList";
        var accountList = await GetEntityAsync<AccountList>(id);
        if (accountList == null)
        {
            accountList = new AccountList
            {
                Id = id,
                Accounts = new List<string>
                {
                    logEvent.Account.ToBase58()
                }
            };
        }
        else
        {
            if ( !accountList.Accounts.Contains(logEvent.Account.ToBase58()))
            {
                accountList.Accounts.Add(logEvent.Account.ToBase58());
            }
        }
        await SaveEntityAsync(accountList);
    }
}
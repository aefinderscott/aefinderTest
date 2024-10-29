using AeFinder.Sdk.Processor;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using SDKCases.GraphQL;
using SDKCases.Processors;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace SDKCases;

public class SDKCasesModule: AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options => { options.AddMaps<SDKCasesModule>(); });
        
        context.Services.AddSingleton<ISchema, SDKCasesSchema>();
        context.Services.AddTransient<ITransactionProcessor, TestTransferProcessor>();
        context.Services.AddTransient<IBlockProcessor, BlockProcessor>();
        
        context.Services.AddTransient<ILogEventProcessor, TransactionFeeChargeProcessor>();

        context.Services.AddTransient<ILogEventProcessor, TestTransferredProcessor>();
        context.Services.AddTransient<ILogEventProcessor, TestAccountAddedProcessor>();
        context.Services.AddTransient<ILogEventProcessor, TestAccountRemovedProcessor>();

        context.Services.AddTransient<ILogEventProcessor, SetEntityLimitProcessor>();
        context.Services.AddTransient<ILogEventProcessor, SetEntitySizeProcessor>();
        context.Services.AddTransient<ILogEventProcessor, SetLogLimitProcessor>();
        context.Services.AddTransient<ILogEventProcessor, SetLogSizeProcessor>();
        context.Services.AddTransient<ILogEventProcessor, ExecuteContractLimitProcessor>();
        context.Services.AddTransient<ILogEventProcessor, TestHelloProcessor>();
        context.Services.AddTransient<ILogEventProcessor, TestSomeProcessor>();

    }
}
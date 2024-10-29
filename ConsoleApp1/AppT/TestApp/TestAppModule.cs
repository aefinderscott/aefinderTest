using AeFinder.Sdk.Processor;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using TestApp.GraphQL;
using TestApp.Processors;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace TestApp;

public class TestAppModule: AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options => { options.AddMaps<TestAppModule>(); });
        
        context.Services.AddSingleton<ISchema, TestAppSchema>();
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
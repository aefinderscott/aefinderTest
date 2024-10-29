// using AeFinder.Sdk.Entities;
// using AeFinder.Sdk.Logging;
// using AeFinder.Sdk.Processor;
// // using Elasticsearch.Net;
// using TestApp.Entities;
// using Volo.Abp.DependencyInjection;
// using Volo.Abp.Domain.Repositories;
//
// using AeFinder.Apps;
// using AeFinder.Sdk.Attachments;
//
//
// namespace SDKCases.Processors;
//
// public class AppFile3AppAttachmentValueProvider : AppAttachmentValueProviderBase<TestInfo3>
// {
//     public override string Key => "AppFile3";
//
//    
// }
//
// public class TestInfo3
// {
//     public List<SubscriptionDto> SubscriptionItems { get; set; }
//     
// }
//
// public class SubscriptionDto
// {
//     
//     public string ChainId { get; set; }
//    
//     public long StartBlockNumber { get; set; }
//     public bool OnlyConfirmed { get; set; }
//     public List<TransactionConditionDto> Transactions { get; set; } = new();
//     public List<LogEventConditionDto> LogEvents { get; set; } = new();
// }
//
// public class TransactionConditionDto
// {
//     public string To { get; set; }
//     public List<string> MethodNames { get; set; } = new();
// }
//
// public class LogEventConditionDto
// {
//     public string ContractAddress { get; set; }
//     public List<string> EventNames { get; set; } = new();
// }
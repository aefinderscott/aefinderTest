using AeFinder.Sdk.Attachments;
using AeFinder.Sdk.Entities;
using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using Newtonsoft.Json;
// using Elasticsearch.Net;
using SDKCases.Entities;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;


namespace SDKCases.Processors;

public class BlockProcessor : BlockProcessorBase, ITransientDependency
{
    // private readonly IAppAttachmentValueProvider<TestInfo> _appAttachmentValueProvider;
    // private readonly IAppAttachmentValueProvider<TestInfo1> _appAttachmentValueProvider1;
    // private readonly IAppAttachmentValueProvider<TestInfo3> _appAttachmentValueProvider3;
    // private readonly IAppAttachmentValueProvider<TestInfo4> _appAttachmentValueProvider4;
    //
    // public BlockProcessor(IAppAttachmentValueProvider<TestInfo> appAttachmentValueProvider, IAppAttachmentValueProvider<TestInfo1> appAttachmentValueProvider1, IAppAttachmentValueProvider<TestInfo3> appAttachmentValueProvider3, IAppAttachmentValueProvider<TestInfo4> appAttachmentValueProvider4)
    // {
    //     _appAttachmentValueProvider = appAttachmentValueProvider;
    //     _appAttachmentValueProvider1 = appAttachmentValueProvider1;
    //     _appAttachmentValueProvider3 = appAttachmentValueProvider3;
    //     _appAttachmentValueProvider4 = appAttachmentValueProvider4;
    // }
    // public BlockProcessor( IAppAttachmentValueProvider<TestInfo3> appAttachmentValueProvider3)
    // {
    //     // _appAttachmentValueProvider = appAttachmentValueProvider;
    //     // _appAttachmentValueProvider1 = appAttachmentValueProvider1;
    //     _appAttachmentValueProvider3 = appAttachmentValueProvider3;
    //     // _appAttachmentValueProvider4 = appAttachmentValueProvider4;
    // }
    
    public override async Task ProcessAsync(Block block, BlockContext context)
    {
        
        // Logger.LogDebug("1000这是_appAttachmentValueProvider3：{0}", _appAttachmentValueProvider3.GetValue().SubscriptionItems[0].LogEvents[0].ContractAddress);
        // Logger.LogDebug("1000这是_appAttachmentValueProvider3：{0}", _appAttachmentValueProvider3.GetValue().SubscriptionItems[0].OnlyConfirmed);
        // Logger.LogDebug("1000这是_appAttachmentValueProvider3：{0}", _appAttachmentValueProvider3.GetValue().SubscriptionItems[0].StartBlockNumber);
        // Logger.LogDebug("这是_appAttachmentValueProvider3：{0}", _appAttachmentValueProvider3.GetValue().SubscriptionItems[0].LogEvents[0].ContractAddress);
        
        // Logger.LogDebug("这是_appAttachmentValueProvider4：{0}", _appAttachmentValueProvider4.GetValue().Info2);
        
        // var appAttachmentValueProvider = GetRequiredService<IAppAttachmentValueProvider<TestInfo>>();
        // var fileContent = await _awsS3ClientService.GetJsonFileContentAsync(_appInfoProvider.AppId, fileName);
        // var value = JsonConvert.DeserializeObject<TestInfo>(fileContent);
        
        // Logger.LogDebug("这是_appAttachmentValueProvider0：{0}, {1}, {2}, {3}, {4}", _appAttachmentValueProvider.GetValue().Info, _appAttachmentValueProvider.GetValue().Info1, _appAttachmentValueProvider.GetValue().Info2, _appAttachmentValueProvider.GetValue().Info3, _appAttachmentValueProvider.GetValue().Info4);
        // Logger.LogDebug("这是_appAttachmentValueProvider1：{0}, {1}, {2}, {3}, {4}, {5}", _appAttachmentValueProvider1.GetValue().Info, _appAttachmentValueProvider1.GetValue().Info, _appAttachmentValueProvider1.GetValue().Info1, _appAttachmentValueProvider1.GetValue().Info2, _appAttachmentValueProvider1.GetValue().Info4, _appAttachmentValueProvider1.GetValue().Info5, _appAttachmentValueProvider1.GetValue().Info5);

        
        
        
        
        
        
        
        // var appAttachmentValueProvider = GetRequiredService<IAppAttachmentValueProvider<TestInfo>>();
        // var fileContent = await _awsS3ClientService.GetJsonFileContentAsync(_appInfoProvider.AppId, fileName);
        // var value = JsonConvert.DeserializeObject<TestInfo>(fileContent);
        // Logger.LogDebug("这是_appAttachmentValueProvider：", _appAttachmentValueProvider.GetValue().Info);

        
        // Logger.LogWarning("11111111111", block.BlockHeight);
        // Logger.LogWarning("1", block.BlockHeight);
        // Logger.LogWarning("1", block.BlockHeight);
        // Logger.LogWarning("1", block.BlockHeight);
        // Logger.LogWarning("1", block.BlockHeight);
        // Logger.LogWarning("1", block.BlockHeight);
        // Logger.LogWarning("1", block.BlockHeight);
        
        //822
        // TimeSpan duration = new TimeSpan(5, 30, 0);
        //
        // // 输出时间间隔
        // Logger.LogWarning($"Total duration: {duration.Hours} hours, {duration.Minutes} minutes");
        //822-1
        
        // var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
        // var settings = new ConnectionSettings(pool);
        // var client = new ElasticClient(settings);
        // Logger.LogInformation("[TestLogChainId]--------- ChainId={ChainId}", context.ChainId);
        // Logger.LogInformation("这是info", block.BlockHeight);
        //
        // Logger.LogWarning("这是warning", block.BlockHeight);
        // Logger.LogError("这是err", block.BlockHeight);
        // Logger.LogDebug("这是debug", block.BlockHeight);
        // Logger.LogError("c", block.BlockHeight);

        // Logger.LogError("=====errortest. BlockHeight: {1}Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception testException test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception testException test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception testException test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，", block.BlockHeight);
        // Logger.LogWarning("-----warningtest. BlockHeight: {1}", block.BlockHeight);
        // Logger.LogInformation(block.BlockHeight);
        // Logger.LogInformation("block. BlockHash: {0}, BlockHeight: {1}", block.BlockHash, block.BlockHeight);
        // if (block.BlockHeight % 2 == 0)
        // {
        //     throw new Exception("Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，Exception test，");
        // }
        //
        // if (block.BlockHeight == 3451390)
        // {
        //     Logger.LogError("=====errortest. BlockHeight: {1}", block.BlockHeight);
        //     Logger.LogWarning("-----warningtest. BlockHeight: {1}", block.BlockHeight);
        // }
        // if (block.BlockHeight == 3431390)
        // {
        //     Logger.LogError("=====errortest. BlockHeight: {1}", block.BlockHeight);
        //     Logger.LogWarning("-----warningtest. BlockHeight: {1}", block.BlockHeight);
        // }
        // if (block.BlockHeight == 3421390)
        // {
        //     Logger.LogError("=====errortest. BlockHeight: {1}", block.BlockHeight);
        //     Logger.LogWarning("-----warningtest. BlockHeight: {1}", block.BlockHeight);
        // }
        // if (block.BlockHeight == 3321390)
        // {
        //     Logger.LogError("=====errortest. BlockHeight: {1}", block.BlockHeight);
        //     Logger.LogWarning("-----warningtest. BlockHeight: {1}", block.BlockHeight);
        // }
        
        // var blockInfo = await GetEntityAsync<BlockEntity>(context.ChainId + "-" + block.BlockHash + block.BlockHeight);
        // var blockInfo = await GetEntityAsync<BlockEntity>(context.ChainId + "-" + block.PreviousBlockHash + (block.BlockHeight - 1));
        
        //730
        var blockInfo = await GetEntityAsync<BlockEntity>(context.ChainId + "-" + block.BlockHeight);


        // if (blockInfo != null)
        // {
        //     Logger.LogError("Fork block. new BlockHash: {0}, BlockHeight: {1}", block.BlockHash, block.BlockHeight);
        //     Logger.LogError("Fork block. old BlockHash: {0}, BlockHeight: {1}", blockInfo.BlockHash, blockInfo.BlockHeight);
        //     return;
        //     // if (!block.PreviousBlockHash.Equals(blockInfo.BlockHash))
        //     // {
        //     //     Logger.LogError("Fork block. BlockHash: {0}, BlockHeight: {1}", block.BlockHash, block.BlockHeight);
        //     //     return;
        //     // }
        // }

        // if (block.BlockHeight < 19320380)
        // {
        //     throw new Exception("这是一个自定义异常消息");
        // }
        
        
        Random random = new Random();
        //
        // // 生成一个从0到100之间的随机整数
        int randomNumber = random.Next(0, 101);

        string strtmp = String.Empty;
        if(block.BlockHeight % 2 == 0)
        {
            strtmp = block.BlockHeight + "";
        }

        DateTime dateTime = DateTime.Now;
        if(block.BlockHeight % 7 == 0)
        {
            long unixTimeStamp = 1617187200; // 例如

// 转换为 DateTime
            dateTime = DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp).DateTime;
        }

        int? nullvalue = null;
        DateTime? TimeNUllTestValue = null;
        if(block.BlockHeight % 3 == 0)
        {
            nullvalue = 1; // 例如
            
            long unixTimeStamp = 1617187200; // 例如

// 转换为 DateTime
            TimeNUllTestValue = DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp).DateTime;
             

        }
        
        
        
        var blockIndex = new BlockEntity
        {
            // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
            Id = context.ChainId + "-" + block.BlockHeight + "-" + 0,
            Miner = strtmp,
            BlockHeight = block.BlockHeight,
            // PreviousBlockHash = block.PreviousBlockHash,
            BlockHash = block.BlockHash,
            // TransactionIds = 
            
            nulltest = nullvalue,
            
            TimeTest = dateTime,
            TimeNUllTest = TimeNUllTestValue,
            
            Block1Entity = new Block1Entity()
            {
                // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
                Id = context.ChainId + "-" + block.BlockHeight,
                // Miner = block.Miner,
                BlockHeight = block.BlockHeight - random.Next(0, 101),
                // PreviousBlockHash = block.PreviousBlockHash,
                BlockHash = block.BlockHash,
                // TransactionIds = 
            
            
                Block2Entity = new Block2Entity()
                {
                    // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
                    Id = context.ChainId + "-" + block.BlockHeight,
                    // Miner = block.Miner,
                    BlockHeight = block.BlockHeight - random.Next(0, 101),
                    // PreviousBlockHash = block.PreviousBlockHash,
                    BlockHash = block.BlockHash,
                    // TransactionIds = 
            
            
                    Block3Entity = new Block3Entity()
                    {
                        // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
                        Id = context.ChainId + "-" + block.BlockHeight,
                        // Miner = block.Miner,
                        BlockHeight = block.BlockHeight + random.Next(0, 101),
                        // PreviousBlockHash = block.PreviousBlockHash,
                        BlockHash = block.BlockHash,
                        // TransactionIds = 
                    }
                
                }
            }
        };
        // var random= new System.Random();
        // random.Next(0, 10000);
        // blockIndex.blockIns = new BlockInEntity()
        // {
        //     Id = random.Next(0, 10000) + "-" + context.ChainId + "-" + 1,
        //     InMiner = random.Next(0, 10000) + "-" + block.Miner + "-" + 1,
        //     InBlockHeight = block.BlockHeight + 1,
        //     InPreviousBlockHash = random.Next(0, 10000) + "-" + block.PreviousBlockHash + "-" + 1,
        //     InBlockHash = random.Next(0, 10000) + "-" + block.BlockHash + "-" + 1,
        // };
        
        blockIndex.blockIns = new List<BlockInEntity>()
        {
            new BlockInEntity()
            {
                ChainId = context.ChainId,
                InBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                InBlockHash = random.Next(0, 10000) + "-" + 1,
                BlockTmpEntity = new BlockTmpEntity()
                {
                   
                    TmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                    TmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                    TmpBlockHash = random.Next(0, 10000) + "-" + 1,
                    BlockTmpTmpEntity = new BlockTmpTmpEntity()
                    {
                        TmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                        TmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                        TmpBlockHash = random.Next(0, 10000) + "-" + 1,
                        
                    },
                    blockInsTmp = new List<BlockInTmpEntity>()
                    {
                        new BlockInTmpEntity()
                        {
                            InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                            InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                            InTmpBlockHash = random.Next(0, 10000) + "-" + 1,
                            
                        },
                        new BlockInTmpEntity()
                        {
                            InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                            InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                            InTmpBlockHash = random.Next(0, 10000) + "-" + 1,
                            
                        }
                    }
                }
                    
            },
            new BlockInEntity()
            {
                ChainId = context.ChainId,
                InBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                InBlockHash = random.Next(0, 10000) + "-" + 1,
                
                BlockTmpEntity = new BlockTmpEntity()
                {
                   
                    TmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                    TmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                    TmpBlockHash = random.Next(0, 10000) + "-" + 1,
                    BlockTmpTmpEntity = new BlockTmpTmpEntity()
                    {
                        TmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                        TmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                        TmpBlockHash = random.Next(0, 10000) + "-" + 1,
                        
                    },
                    blockInsTmp = new List<BlockInTmpEntity>()
                    {
                        new BlockInTmpEntity()
                        {
                            InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                            InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                            InTmpBlockHash = random.Next(0, 10000) + "-" + 1,
                            
                        },
                        new BlockInTmpEntity()
                        {
                            InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                            InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                            InTmpBlockHash = random.Next(0, 10000) + "-" + 1,
                            
                        }
                    }
                }
                    
            },
            new BlockInEntity()
            {
                ChainId = context.ChainId,
                InBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                InBlockHash = random.Next(0, 10000) + "-" + 1,
                BlockTmpEntity = new BlockTmpEntity()
                {
                   
                    TmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                    TmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                    TmpBlockHash = random.Next(0, 10000) + "-" + 1,
                    BlockTmpTmpEntity = new BlockTmpTmpEntity()
                    {
                        TmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                        TmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                        TmpBlockHash = random.Next(0, 10000) + "-" + 1,
                        
                    },
                    blockInsTmp = new List<BlockInTmpEntity>()
                    {
                        new BlockInTmpEntity()
                        {
                            InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                            InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                            InTmpBlockHash = random.Next(0, 10000) + "-" + 1,
                            
                        },
                        new BlockInTmpEntity()
                        {
                            InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                            InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                            InTmpBlockHash = random.Next(0, 10000) + "-" + 1,
                            
                        }
                    }
                }
                    
            },
            new BlockInEntity()
            {
                ChainId = context.ChainId,
                InBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                InBlockHash = random.Next(0, 10000) + "-" + 1,
                BlockTmpEntity = new BlockTmpEntity()
                {
                   
                    TmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                    TmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                    TmpBlockHash = random.Next(0, 10000) + "-" + 1,
                    BlockTmpTmpEntity = new BlockTmpTmpEntity()
                    {
                        TmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                        TmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                        TmpBlockHash = random.Next(0, 10000) + "-" + 1,
                        
                    },
                    blockInsTmp = new List<BlockInTmpEntity>()
                    {
                        new BlockInTmpEntity()
                        {
                            InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                            InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                            InTmpBlockHash = random.Next(0, 10000) + "-" + 1,
                            
                        },
                        new BlockInTmpEntity()
                        {
                            InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                            InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                            InTmpBlockHash = random.Next(0, 10000) + "-" + 1,
                            
                        }
                    }
                }
                    
            },
            new BlockInEntity()
            {
                ChainId = context.ChainId,
                InBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                InBlockHash = random.Next(0, 10000) + "-" + 1,
                BlockTmpEntity = new BlockTmpEntity()
                {
                   
                    TmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                    TmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                    TmpBlockHash = random.Next(0, 10000) + "-" + 1,
                    BlockTmpTmpEntity = new BlockTmpTmpEntity()
                    {
                        TmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                        TmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                        TmpBlockHash = random.Next(0, 10000) + "-" + 1,
                        
                    },
                    blockInsTmp = new List<BlockInTmpEntity>()
                    {
                        new BlockInTmpEntity()
                        {
                            InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                            InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                            InTmpBlockHash = random.Next(0, 10000) + "-" + 1,
                            
                        },
                        new BlockInTmpEntity()
                        {
                            InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                            InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                            InTmpBlockHash = random.Next(0, 10000) + "-" + 1,
                            
                        }
                    }
                }
                    
            },
            new BlockInEntity()
            {
                ChainId = context.ChainId,
                InBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                InBlockHash = random.Next(0, 10000) + "-" + 1,
                BlockTmpEntity = new BlockTmpEntity()
                {
                   
                    TmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                    TmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                    TmpBlockHash = random.Next(0, 10000) + "-" + 1,
                    BlockTmpTmpEntity = new BlockTmpTmpEntity()
                    {
                        TmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                        TmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                        TmpBlockHash = random.Next(0, 10000) + "-" + 1,
                        
                    },
                    blockInsTmp = new List<BlockInTmpEntity>()
                    {
                        new BlockInTmpEntity()
                        {
                            InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                            InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                            InTmpBlockHash = random.Next(0, 10000) + "-" + 1,
                            
                        },
                        new BlockInTmpEntity()
                        {
                            InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                            InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                            InTmpBlockHash = random.Next(0, 10000) + "-" + 1,
                            
                        }
                    }
                }
                    
            }
            
        };
        //
        //
        blockIndex.BlockTmpEntity = new BlockTmpEntity()
        {
            TmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
            TmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
            TmpBlockHash = random.Next(0, 10000)  + "-" + 1,
            
            BlockTmpTmpEntity = new BlockTmpTmpEntity()
            {
                TmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                TmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                TmpBlockHash = random.Next(0, 10000) + "-" + 1,
                        
            },
                blockInsTmp = new List<BlockInTmpEntity>()
                {
                    new BlockInTmpEntity()
                    {
                        InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                        InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                        InTmpBlockHash = random.Next(0, 10000)  + "-" + 1,
                            
                    },
                    new BlockInTmpEntity()
                    {
                        InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                        InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                        InTmpBlockHash = random.Next(0, 10000)  + "-" + 1,
                            
                    },
                    new BlockInTmpEntity()
                    {
                        InTmpBlockHeight = block.BlockHeight  + random.Next(0, 10000),
                        InTmpPreviousBlockHash = random.Next(0, 10000)  + "-" + 1,
                        InTmpBlockHash = random.Next(0, 10000)  + "-" + 1,
                            
                    }
                }
        };
        
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        
        
        // if (blockIndex.BlockHeight % 3 == 0)
        // {
        //     Logger.LogDebug("Block {0}, DeleteEntityAsync Event", blockIndex.BlockHeight);
        //     await DeleteEntityAsync(blockIndex);
        // }
        
        // randomNumber = random.Next(101, 201);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + 1,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + 2,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        // await SaveEntityAsync(blockIndex);
        
        
        
        // randomNumber = random.Next(0, 101);
        // blockIndex = new BlockEntity
        // {
        //     // Id = context.ChainId + "-" + block.BlockHash + block.BlockHeight,
        //     Id = context.ChainId + "-" + block.BlockHeight + "-" + randomNumber,
        //     // Miner = block.Miner,
        //     BlockHeight = block.BlockHeight,
        //     // PreviousBlockHash = block.PreviousBlockHash,
        //     BlockHash = block.BlockHash,
        //     // TransactionIds =
        // };
        // Logger.LogDebug("Add Block {0}", block.BlockHeight);
        await SaveEntityAsync(blockIndex);
        blockIndex.BlockHeight = blockIndex.BlockHeight + 111222;
        blockIndex.BlockHash = blockIndex.BlockHash + "ssr";
        await SaveEntityAsync(blockIndex);
        blockIndex.BlockHeight = blockIndex.BlockHeight + 111222;
        blockIndex.BlockHash = blockIndex.BlockHash + "ssr";
        await SaveEntityAsync(blockIndex);
        blockIndex.BlockHeight = blockIndex.BlockHeight + 111222;
        blockIndex.BlockHash = blockIndex.BlockHash + "ssr";
        await SaveEntityAsync(blockIndex);
        blockIndex.BlockHeight = blockIndex.BlockHeight + 111222;
        blockIndex.BlockHash = blockIndex.BlockHash + "ssr";
        await SaveEntityAsync(blockIndex);
        blockIndex.BlockHeight = blockIndex.BlockHeight + 111222;
        blockIndex.BlockHash = blockIndex.BlockHash + "ssr";
        await SaveEntityAsync(blockIndex);


        // await Task.Delay(60000);

    }
}
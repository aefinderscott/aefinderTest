
using System.Linq.Expressions;
using AeFinder.Entities.Es;
using AeFinder.Sdk;
using GraphQL;
using TestApp.Entities;
using Volo.Abp.ObjectMapping;

namespace TestApp.GraphQL;

public class TestAppQuery
{
    // public static async Task<List<AccountDto>> Account(
    //     [FromServices] IReadOnlyRepository<Account> repository,
    //     [FromServices] IObjectMapper objectMapper,
    //     GetAccountInput input)
    // {
    //     var queryable = await repository.GetQueryableAsync();
    //     
    //     queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);
    //     
    //     if (!input.Address.IsNullOrWhiteSpace())
    //     {
    //         queryable = queryable.Where(a => a.Address == input.Address);
    //     }
    //     
    //     if(!input.Symbol.IsNullOrWhiteSpace())
    //     {
    //         queryable = queryable.Where(a => a.Symbol == input.Symbol);
    //     }
    //     
    //     var accounts= queryable.ToList();
    //
    //     return objectMapper.Map<List<Account>, List<AccountDto>>(accounts);
    // }
    //
    // public static async Task<AccountListDto> AccountList(
    //     [FromServices] IReadOnlyRepository<AccountList> repository,
    //     [FromServices] IObjectMapper objectMapper,
    //     GetAccountsInput input
    //     )
    // {
    //     var queryable = await repository.GetQueryableAsync();
    //     
    //     queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);
    //
    //     var accounts = queryable.GetEnumerator().Current;
    //     return objectMapper.Map<AccountList, AccountListDto>(accounts);
    // }
    //
    // public static async Task<List<TestTransferRecordDto>> TestTransferRecords(
    //     [FromServices] IReadOnlyRepository<TestTransferRecord> repository,
    //     [FromServices] IObjectMapper objectMapper,
    //     GetAccountInput input
    // )
    // {
    //     var queryable = await repository.GetQueryableAsync();
    //     if (!input.ChainId.IsNullOrWhiteSpace())
    //     {
    //         queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);
    //     }
    //     if (input.BlockHeight != 0)
    //     {
    //         queryable = queryable.Where(a => a.Metadata.Block.BlockHeight == input.BlockHeight);
    //     }
    //
    //     if (!input.Address.IsNullOrWhiteSpace())
    //     {
    //         queryable = queryable.Where(a => a.FromAddress == input.Address || a.ToAddress == input.Address);
    //     }
    //     if(!input.Symbol.IsNullOrWhiteSpace())
    //     {
    //         queryable = queryable.Where(a => a.Symbol == input.Symbol);
    //     }
    //
    //     var records= queryable.ToList();
    //     return objectMapper.Map<List<TestTransferRecord>, List<TestTransferRecordDto>>(records);
    // }
    //
    // public static async Task<TransactionCountDto> TransactionCount(
    //     [FromServices] IReadOnlyRepository<TransactionCount> repository,
    //     [FromServices] IObjectMapper objectMapper,
    //     TransactionCountInput input
    // )
    // {
    //     var queryable = await repository.GetQueryableAsync();
    //     
    //     if (!input.ChainId.IsNullOrWhiteSpace())
    //     {
    //         queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);
    //     }
    //     if(!input.Address.IsNullOrWhiteSpace())
    //     {
    //         queryable = queryable.Where(a => a.ContractAddress == input.Address);
    //     }
    //
    //     var counts = queryable.FirstOrDefault();
    //     if (counts !=null) return objectMapper.Map<TransactionCount, TransactionCountDto>(counts);
    //     return new TransactionCountDto();
    // }

    // public static async Task<Dictionary<int, string>> BlockIndexIn1(
    //     [FromServices] IReadOnlyRepository<BlockEntity> repository,
    //     [FromServices] IObjectMapper objectMapper,
    //     long height,
    //     string chain,
    //     Dictionary<int, string> myDictionary ,
    //     GetBlockInput input
    // )
    // {
    //     // Dictionary<int, string> 
    //         myDictionary = new Dictionary<int, string>();
    //
    //     // 也可以使用集合初始化器
    //     var anotherDictionary = new Dictionary<int, string>
    //     {
    //         {1, "One"},
    //         {2, "Two"},
    //         {3, "Three"}
    //     };
    //     return anotherDictionary;
    // }

    public static async Task<List<BlockIndexDto>> BlockIndex(
        [FromServices] IReadOnlyRepository<BlockEntity> repository,
        [FromServices] IObjectMapper objectMapper,
        long height,
        string chain
    )
    {
        var queryable = await repository.GetQueryableAsync();
        
                
        if (height != 0)
        {
            queryable = queryable.Where(a => a.BlockHeight <= height);
        }
        if(!chain.IsNullOrWhiteSpace())
        {
            queryable = queryable.Where(a => a.Metadata.ChainId == chain);
        }
        
        var blockIndex = queryable.ToList();
        return objectMapper.Map<List<BlockEntity>, List<BlockIndexDto>>(blockIndex);
    }
    
    public static async Task<List<BlockIndexDto>> BlockIndexIn(
        [FromServices] IReadOnlyRepository<BlockEntity> repository,
        [FromServices] IObjectMapper objectMapper,
        GetBlockInput input
    )
    {
        var queryable = await repository.GetQueryableAsync();
        
        
        
        //普通查询  pass
        if (input.BlockHeight != 0)
        {
            // queryable = queryable.Where(a => a.BlockHeight <= input.BlockHeight);
            queryable = queryable.Where(a => a.BlockHeight == input.BlockHeight);
        }
        if(!input.ChainId.IsNullOrWhiteSpace())
        {
            queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);
        }
        if(!input.BlockHash.IsNullOrWhiteSpace())
        {
            queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
        }
        
        //模糊匹配 StartWithStr pass
        if(!input.StartWithStr.IsNullOrWhiteSpace())
        {
            
            // queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
            queryable = queryable.Where(a => a.BlockHash.StartsWith(input.StartWithStr));
        }
        //模糊匹配 EndsWith pass
        if(!input.EndWithStr.IsNullOrWhiteSpace())
        {
            
            // queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
            queryable = queryable.Where(a => a.BlockHash.EndsWith(input.EndWithStr));
        }
        //模糊匹配 Contains pass
        if(!input.ContainsStr.IsNullOrWhiteSpace())
        {
            
            // queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
            queryable = queryable.Where(a => a.BlockHash.Contains(input.ContainsStr));
        }
        
        //searchafter pass
        if(input.OrderByHe == 99)
        {
            // queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
            queryable = queryable.OrderBy(a => a.Id).OrderBy(a => a.BlockHeight).After(new object[]{input.SearAfterCHainId, input.SearAfterBlockHeight});
        }
        
        //排序 -普通升序  pass
        if(input.OrderByHe == 0)
        {
            queryable = queryable.OrderBy(a => a.BlockHeight);
        }
        //排序 -普通降序  pass
        if(input.OrderByHe == 1)
        {
            queryable = queryable.OrderByDescending(a => a.BlockHeight);
        }
        //排序 -嵌套升序 pass
        if(input.OrderByHe == 3)
        {
            // queryable = queryable.OrderByDescending(p => p.blockIns[0].InBlockHeight);
            
        }
        //排序 -嵌套升序 pass
        if(input.OrderByHe == 4)
        {
            // queryable = queryable.OrderBy(p => p.blockIns[0].InBlockHeight);
            // queryable = queryable.OrderBy(p => p.blockIns.OrderBy(i=>i.ChainId));
            //queryable = queryable.OrderBy(p => p.blockIns);


            // NestedSortDescriptor<BlockInEntity> ns = new NestedSortDescriptor<BlockInEntity>();
            // ns.Path(p => p.InBlockHeight);
            
            // Expression<Func<BlockInEntity, bool>> mustQuery = p => p.InBlockHeight >=100 && p.InBlockHeight <= 110;
            // mustQuery = p => p.blockIns.Any(i => i.InBlockHash == input.InBlockHash);
            // queryable = queryable.Where(mustQuery);
            
            // ns.Filter(mustQuery);

            // NestedSortBuilder nestedSort = new NestedSortBuilder
            // NestedSortBuilder nestedSort = new NestedSortBuilder("tenantIdList");
            // nestedSort.setFilter(QueryBuilders.nestedQuery(
            //     StringUtils.camelToUnderline("tenantIdList.lastTime"),
            //     QueryBuilders.rangeQuery("tenantIdList.lastTime"),
            //     ScoreMode.Avg
            // ));
            // SortBuilder<?> sortBuilderOrder = SortBuilders.fieldSort("tenantIdList.lastTime")
            //     .order( SortOrder.DESC).setNestedSort(nestedSort);
            // esQueryWrapper.sort(sortBuilderOrder);


        }
        
        //排序 -子对象升序 pass
        if(input.OrderByHe == 5)
        {
            queryable = queryable.OrderByDescending(p => p.Metadata.ChainId);
        }
        //排序 -子对象升序 paa
        if(input.OrderByHe == 6)
        {
            queryable = queryable.OrderBy(p => p.Metadata.ChainId);
        }
        //排序 -子对象-子对象升序 paa
        if(input.OrderByHe == 61)
        {
            // queryable = queryable.OrderBy(p => p.BlockTmpEntity.BlockTmpTmpEntity.TmpBlockHeight);
        }
        //排序 -子对象-子对象升序 paa
        if(input.OrderByHe == 62)
        {
            // queryable = queryable.OrderByDescending(p => p.BlockTmpEntity.BlockTmpTmpEntity.TmpBlockHeight);
        }
        
        // //排序 -嵌套->子 升序
        // if(input.OrderByHe == 11)
        // {
        //     queryable = queryable.OrderBy(p => p.blockIns);
        //     
        // }
        // //排序 -嵌套->子 升序
        // if(input.OrderByHe == 12)
        // {
        //     queryable = queryable.OrderBy(p => p.blockIns[0].BlockTmpEntity);
        //     
        // }
        //排序 -嵌套->子 升序 pass
        if(input.OrderByHe == 13)
        {
           
            // queryable = queryable.OrderBy(p => p.blockIns[0].BlockTmpEntity.TmpBlockHash);
            
        }
        // //排序 -嵌套->子 升序
        // if(input.OrderByHe == 14)
        // {
        //    
        //     queryable = queryable.OrderBy(p => p.blockIns.OrderBy(i=>i.BlockTmpEntity));
        // }
        //排序 -嵌套->子 升序
        // if(input.OrderByHe == 15)
        // {
        //    
        //     queryable = queryable.OrderBy(p => p.blockIns.OrderBy(i=>i.BlockTmpEntity.TmpBlockHash));
        // }
        //排序 -子对象-q嵌套升序
        // if(input.OrderByHe == 21)
        // {
        //     queryable = queryable.OrderByDescending(p => p.BlockTmpEntity.blockInsTmp);
        //    
        // }
        // //排序 -子对象-q嵌套升序
        // if(input.OrderByHe == 22)
        // {
        //     
        //     queryable = queryable.OrderBy(p => p.BlockTmpEntity.blockInsTmp);
        //    
        // }
        //排序 -子对象-q嵌套升序
        // if(input.OrderByHe == 23)
        // {
        //    
        //     queryable = queryable.OrderBy(p => p.BlockTmpEntity.blockInsTmp.OrderBy(i=>i.InTmpBlockHeight));
        //    
        // }
        //排序 -子对象-q嵌套升序
        // if(input.OrderByHe == 24)
        // {
        //    
        //     queryable = queryable.OrderBy(p => p.BlockTmpEntity.blockInsTmp[0]);
        //    
        // }
        //排序 -子对象-q嵌套升序 pass
        if(input.OrderByHe == 25)
        {
           
            // queryable = queryable.OrderBy(p => p.BlockTmpEntity.blockInsTmp[0].InTmpBlockHeight);
        }
        
        //子对象普通查询 pass
        if(!input.InChainId.IsNullOrWhiteSpace())
        {
            // queryable = queryable.Where(a => a.blockIns.Any(i => i.ChainId == input.InChainId));
            
            // queryable = queryable.Where(a => a.Block1Entity.Block2Entity.Block3Entity.BlockHeight == input.BlockHeight);
        }
        
        //嵌套 -pass
        if(!input.InBlockHash.IsNullOrWhiteSpace())
        {
            // Expression<Func<BlockEntity, bool>> mustQuery = p => p.blockIns.Any(i => i.ChainId == input.InChainId && i.InBlockHeight >= 100 && i.InBlockHeight <= 110);
            // mustQuery = p => p.blockIns.Any(i => i.InBlockHash == input.InBlockHash);
            // queryable = queryable.Where(mustQuery);
        }
        
        
        // Expression<Func<BlockIndexDto, bool>> mustQuery = p => p.blockIns.Any(i => i.Id == input.InChainId && i.InBlockHeight >= 100 && i.InBlockHeight <= 110);
        // mustQuery = p => p.blockIns.Any(i => i.InBlockHash == input.InBlockHash);
        // // var queryable = await _transactionIndexRepository.GetQueryableAsync();
        // var filterList = queryable.Where(mustQuery).ToList();
        // filterList.Count.ShouldBe(1);
        
        
        var blockIndex = queryable.ToList();
        return objectMapper.Map<List<BlockEntity>, List<BlockIndexDto>>(blockIndex);
    }
    
    public static async Task<List<BlockIndexDto>> BlockIndex3(
        [FromServices] IReadOnlyRepository<BlockEntity> repository,
        [FromServices] IObjectMapper objectMapper,
        long height,
        string chain
    )
    {
        var queryable = await repository.GetQueryableAsync();
        
                
        if (height != 0)
        {
            queryable = queryable.Where(a => a.BlockHeight <= height);
        }
        if(!chain.IsNullOrWhiteSpace())
        {
            queryable = queryable.Where(a => a.Metadata.ChainId == chain);
        }
        
        var blockIndex = queryable.ToList();
        return objectMapper.Map<List<BlockEntity>, List<BlockIndexDto>>(blockIndex);
    }
    
    
    
    public static async Task<List<BlockIndexDto>> childuqery(
        [FromServices] IReadOnlyRepository<BlockEntity> repository,
        [FromServices] IObjectMapper objectMapper,
        GetBlockInput input
    )
    {
        var queryable = await repository.GetQueryableAsync();
        
        
        
        //普通查询  pass
        if (input.BlockHeight != 0)
        {
            queryable = queryable.Where(a => a.BlockHeight <= input.BlockHeight);
        }
        // if(!input.ChainId.IsNullOrWhiteSpace())
        // {
        //     queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);
        // }
        // if(!input.BlockHash.IsNullOrWhiteSpace())
        // {
        //     queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
        // }
        //
        // //模糊匹配 StartWithStr pass
        // if(!input.StartWithStr.IsNullOrWhiteSpace())
        // {
        //     
        //     // queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
        //     queryable = queryable.Where(a => a.BlockHash.StartsWith(input.StartWithStr));
        // }
        // //模糊匹配 EndsWith pass
        // if(!input.EndWithStr.IsNullOrWhiteSpace())
        // {
        //     
        //     // queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
        //     queryable = queryable.Where(a => a.BlockHash.EndsWith(input.EndWithStr));
        // }
        //模糊匹配 Contains pass
        if(!input.ContainsStr.IsNullOrWhiteSpace())
        {
            
            // queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
            queryable = queryable.Where(a => a.BlockHash.Contains(input.ContainsStr));
        }
        //
        // //searchafter pass
        // if(input.OrderByHe == 99)
        // {
        //     // queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
        //     queryable = queryable.OrderBy(a => a.Id).OrderBy(a => a.BlockHeight).After(new object[]{input.SearAfterCHainId, input.SearAfterBlockHeight});
        // }
        //
        // //排序 -普通升序  pass
        // if(input.OrderByHe == 0)
        // {
        //     queryable = queryable.OrderBy(a => a.BlockHeight);
        // }
        //排序 -普通降序  pass
        // if(input.OrderByHe == 1)
        // {
        //     queryable = queryable.OrderByDescending(a => a.BlockHeight);
        // }
        //
        //
        //子对象普通查询 pass
        if(!input.InChainId.IsNullOrWhiteSpace())
        {
            // queryable = queryable.Where(a => a.blockIns.Any(i => i.ChainId == input.InChainId));
            
            // queryable = queryable.Where(a => a.Block1Entity.Block2Entity.Block3Entity.BlockHeight >= (input.BlockHeight - 2));
        }
        
       
        
        var blockIndex = queryable.ToList();
        return objectMapper.Map<List<BlockEntity>, List<BlockIndexDto>>(blockIndex);
    }
    
    public static async Task<List<BlockIndexDto>> termsQuery(
        [FromServices] IReadOnlyRepository<BlockEntity> repository,
        [FromServices] IObjectMapper objectMapper,
        GetBlockInput input
    )
    {
        var queryable = await repository.GetQueryableAsync();

        if (input.Termsop == 1)
        {
            List<string> inputs = new List<string>()
            {
                "607cf104146baa22befd294f33adfd925313ee5afa301277183d7e9a459e8d11",
                "8836247611129a31b653a40bf866e5bc910cd2737900110c837506fce66d2347",
                "80dd4d622bdb950d44718265068dc91a0e1c9a029773a9a815678a7357297287"
            };
        
            queryable = queryable.Where(item => inputs.Contains(item.BlockHash));
        }
        if (input.Termsop == 2)
        {
            List<long> inputs = new List<long>()
            {
                10334175,
                10330746,
                10332801
            };

            queryable = queryable.Where(item =>
                item.blockIns.Any(x => inputs.Contains(x.InBlockHeight)));
        }
        
        if (input.Termsop == 3)
        {
            List<string> inputs = new List<string>()
            {
                "607cf104146baa22befd294f33adfd925313ee5afa301277183d7e9a459e8d11",
                "8836247611129a31b653a40bf866e5bc910cd2737900110c837506fce66d2347",
                "80dd4d622bdb950d44718265068dc91a0e1c9a029773a9a815678a7357297287",
                String.Empty
            };
        
            queryable = queryable.Where(item => inputs.Contains(item.Miner));
        }
        
        long unixTimeStamp = 1617187200; // 例如

// 转换为 DateTime
        DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp).DateTime;
        if (input.Termsop == 4)
        {
            List<DateTime> inputs = new List<DateTime>()
            {
                
                dateTime
            };
        
            queryable = queryable.Where(item => inputs.Contains(item.TimeTest));
        }
        
        if (input.Termsop == 5)
        {
            List<int?> inputs = new List<int?>()
            {
                null
            };
        
            queryable = queryable.Where(item => inputs.Contains(item.nulltest));
        }
        if (input.Termsop == 7)
        {
            List<DateTime?> inputs = new List<DateTime?>()
            {
                null
            };
        
            queryable = queryable.Where(item => inputs.Contains(item.TimeNUllTest));
        }
        
        if (input.Termsop == 6)
        {
            List<int?> inputs = new List<int?>()
            {
                // null,
                1,11,12,13,14,15,16,17,18,19,
                2,21,22,23,24,25,26,27,28,29,
                3,31,32,33,34,35,36,37,38,39,
                4,41,42,43,44,45,46,47,48,49,
                5,51,52,53,54,55,56,57,58,59,
                6,62,62,63,64,65,66,67,68,69,
                7,71,72,73,74,75,76,77,78,79,
                8,81,82,83,84,85,86,87,88,89,
                9,91,92,93,94,95,96,97,98,99,
                10,20,30,40,50,60,70,80,90,
                111,222,333,444
                
            };
        
            queryable = queryable.Where(item => inputs.Contains(item.nulltest));
        }
        

        
        // Expression<Func<TransactionIndex, bool>> mustQuery = item =>
        //     item.LogEvents.Any(x => inputs.Contains(x.BlockHeight));
        
        //普通查询  pass
        if (input.BlockHeight != 0)
        {
            // queryable = queryable.Where(a => a.BlockHeight <= input.BlockHeight);
            queryable = queryable.Where(a => a.BlockHeight == input.BlockHeight);
        }
        // if(!input.ChainId.IsNullOrWhiteSpace())
        // {
        //     queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);
        // }
        // if(!input.BlockHash.IsNullOrWhiteSpace())
        // {
        //     queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
        // }
        //
        // //模糊匹配 StartWithStr pass
        if(!input.StartWithStr.IsNullOrWhiteSpace())
        {
            
            // queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
            queryable = queryable.Where(a => a.BlockHash.StartsWith(input.StartWithStr));
        }
        // //模糊匹配 EndsWith pass
        // if(!input.EndWithStr.IsNullOrWhiteSpace())
        // {
        //     
        //     // queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
        //     queryable = queryable.Where(a => a.BlockHash.EndsWith(input.EndWithStr));
        // }
        //模糊匹配 Contains pass
        if(!input.ContainsStr.IsNullOrWhiteSpace())
        {
            
            // queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
            queryable = queryable.Where(a => a.BlockHash.Contains(input.ContainsStr));
        }
        //
        // //searchafter pass
        // if(input.OrderByHe == 99)
        // {
        //     // queryable = queryable.Where(a => a.BlockHash == input.BlockHash);
        //     queryable = queryable.OrderBy(a => a.Id).OrderBy(a => a.BlockHeight).After(new object[]{input.SearAfterCHainId, input.SearAfterBlockHeight});
        // }
        //
        //排序 -普通升序  pass
        if(input.OrderByHe == 0)
        {
            queryable = queryable.OrderBy(a => a.BlockHeight);
        }
        // //排序 -普通降序  pass
        // if(input.OrderByHe == 1)
        // {
        //     queryable = queryable.OrderByDescending(a => a.BlockHeight);
        // }
        // //排序 -嵌套升序 pass
        // if(input.OrderByHe == 3)
        // {
        //     // queryable = queryable.OrderByDescending(p => p.blockIns[0].InBlockHeight);
        //     
        // }
        // //排序 -嵌套升序 pass
        // if(input.OrderByHe == 4)
        // {
        //     // queryable = queryable.OrderBy(p => p.blockIns[0].InBlockHeight);
        //     // queryable = queryable.OrderBy(p => p.blockIns.OrderBy(i=>i.ChainId));
        //     //queryable = queryable.OrderBy(p => p.blockIns);
        //
        //
        //     // NestedSortDescriptor<BlockInEntity> ns = new NestedSortDescriptor<BlockInEntity>();
        //     // ns.Path(p => p.InBlockHeight);
        //     
        //     // Expression<Func<BlockInEntity, bool>> mustQuery = p => p.InBlockHeight >=100 && p.InBlockHeight <= 110;
        //     // mustQuery = p => p.blockIns.Any(i => i.InBlockHash == input.InBlockHash);
        //     // queryable = queryable.Where(mustQuery);
        //     
        //     // ns.Filter(mustQuery);
        //
        //     // NestedSortBuilder nestedSort = new NestedSortBuilder
        //     // NestedSortBuilder nestedSort = new NestedSortBuilder("tenantIdList");
        //     // nestedSort.setFilter(QueryBuilders.nestedQuery(
        //     //     StringUtils.camelToUnderline("tenantIdList.lastTime"),
        //     //     QueryBuilders.rangeQuery("tenantIdList.lastTime"),
        //     //     ScoreMode.Avg
        //     // ));
        //     // SortBuilder<?> sortBuilderOrder = SortBuilders.fieldSort("tenantIdList.lastTime")
        //     //     .order( SortOrder.DESC).setNestedSort(nestedSort);
        //     // esQueryWrapper.sort(sortBuilderOrder);
        //
        //
        // }
        //
        // //排序 -子对象升序 pass
        // if(input.OrderByHe == 5)
        // {
        //     queryable = queryable.OrderByDescending(p => p.Metadata.ChainId);
        // }
        // //排序 -子对象升序 paa
        // if(input.OrderByHe == 6)
        // {
        //     queryable = queryable.OrderBy(p => p.Metadata.ChainId);
        // }
        // //排序 -子对象-子对象升序 paa
        // if(input.OrderByHe == 61)
        // {
        //     // queryable = queryable.OrderBy(p => p.BlockTmpEntity.BlockTmpTmpEntity.TmpBlockHeight);
        // }
        // //排序 -子对象-子对象升序 paa
        // if(input.OrderByHe == 62)
        // {
        //     // queryable = queryable.OrderByDescending(p => p.BlockTmpEntity.BlockTmpTmpEntity.TmpBlockHeight);
        // }
        //
        // // //排序 -嵌套->子 升序
        // // if(input.OrderByHe == 11)
        // // {
        // //     queryable = queryable.OrderBy(p => p.blockIns);
        // //     
        // // }
        // // //排序 -嵌套->子 升序
        // // if(input.OrderByHe == 12)
        // // {
        // //     queryable = queryable.OrderBy(p => p.blockIns[0].BlockTmpEntity);
        // //     
        // // }
        // //排序 -嵌套->子 升序 pass
        // if(input.OrderByHe == 13)
        // {
        //    
        //     // queryable = queryable.OrderBy(p => p.blockIns[0].BlockTmpEntity.TmpBlockHash);
        //     
        // }
        // // //排序 -嵌套->子 升序
        // // if(input.OrderByHe == 14)
        // // {
        // //    
        // //     queryable = queryable.OrderBy(p => p.blockIns.OrderBy(i=>i.BlockTmpEntity));
        // // }
        // //排序 -嵌套->子 升序
        // // if(input.OrderByHe == 15)
        // // {
        // //    
        // //     queryable = queryable.OrderBy(p => p.blockIns.OrderBy(i=>i.BlockTmpEntity.TmpBlockHash));
        // // }
        // //排序 -子对象-q嵌套升序
        // // if(input.OrderByHe == 21)
        // // {
        // //     queryable = queryable.OrderByDescending(p => p.BlockTmpEntity.blockInsTmp);
        // //    
        // // }
        // // //排序 -子对象-q嵌套升序
        // // if(input.OrderByHe == 22)
        // // {
        // //     
        // //     queryable = queryable.OrderBy(p => p.BlockTmpEntity.blockInsTmp);
        // //    
        // // }
        // //排序 -子对象-q嵌套升序
        // // if(input.OrderByHe == 23)
        // // {
        // //    
        // //     queryable = queryable.OrderBy(p => p.BlockTmpEntity.blockInsTmp.OrderBy(i=>i.InTmpBlockHeight));
        // //    
        // // }
        // //排序 -子对象-q嵌套升序
        // // if(input.OrderByHe == 24)
        // // {
        // //    
        // //     queryable = queryable.OrderBy(p => p.BlockTmpEntity.blockInsTmp[0]);
        // //    
        // // }
        // //排序 -子对象-q嵌套升序 pass
        // if(input.OrderByHe == 25)
        // {
        //    
        //     // queryable = queryable.OrderBy(p => p.BlockTmpEntity.blockInsTmp[0].InTmpBlockHeight);
        // }
        //
        // //子对象普通查询 pass
        // if(!input.InChainId.IsNullOrWhiteSpace())
        // {
        //     // queryable = queryable.Where(a => a.blockIns.Any(i => i.ChainId == input.InChainId));
        //     
        //     // queryable = queryable.Where(a => a.Block1Entity.Block2Entity.Block3Entity.BlockHeight == input.BlockHeight);
        // }
        //
        // //嵌套 -pass
        // if(!input.InBlockHash.IsNullOrWhiteSpace())
        // {
        //     // Expression<Func<BlockEntity, bool>> mustQuery = p => p.blockIns.Any(i => i.ChainId == input.InChainId && i.InBlockHeight >= 100 && i.InBlockHeight <= 110);
        //     // mustQuery = p => p.blockIns.Any(i => i.InBlockHash == input.InBlockHash);
        //     // queryable = queryable.Where(mustQuery);
        // }
        //
        //
        // // Expression<Func<BlockIndexDto, bool>> mustQuery = p => p.blockIns.Any(i => i.Id == input.InChainId && i.InBlockHeight >= 100 && i.InBlockHeight <= 110);
        // // mustQuery = p => p.blockIns.Any(i => i.InBlockHash == input.InBlockHash);
        // // // var queryable = await _transactionIndexRepository.GetQueryableAsync();
        // // var filterList = queryable.Where(mustQuery).ToList();
        // // filterList.Count.ShouldBe(1);
        
        
        var blockIndex = queryable.ToList();
        return objectMapper.Map<List<BlockEntity>, List<BlockIndexDto>>(blockIndex);
    }
}
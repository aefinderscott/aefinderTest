using AutoMapper;
using SDKCases.Entities;
using SDKCases.GraphQL;

namespace SDKCases;

public class SDKCasesMapperProfile : Profile
{
    public SDKCasesMapperProfile()
    {
        CreateMap<Account, AccountDto>();
        CreateMap<AccountList, AccountListDto>();
        CreateMap<TestTransferRecord, TestTransferRecordDto>();
        CreateMap<TransactionCount, TransactionCountDto>();
        CreateMap<BlockEntity, BlockIndexDto>();
        CreateMap<Block1Entity, BlockIndex1Dto>();
        CreateMap<Block2Entity, BlockIndex2Dto>();
        CreateMap<Block3Entity, BlockIndex3Dto>();
        CreateMap<BlockInEntity, BlockInIndexDto>();
        CreateMap<BlockInTmpEntity, BlockInTmpIndexDto>();
        CreateMap<BlockTmpEntity, BlockTmpIndexDto>();
        CreateMap<BlockTmpTmpEntity, BlockTmpTmpIndexDto>();
        CreateMap<SomeEntity, SomeIndexDto>();
    }
}
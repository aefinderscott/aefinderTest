using AutoMapper;
using TestApp.Entities;
using TestApp.GraphQL;

namespace TestApp;

public class TestAppMapperProfile : Profile
{
    public TestAppMapperProfile()
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
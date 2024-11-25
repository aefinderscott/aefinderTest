using System;
using System.Collections.Generic;
using AElf.Types;
using Volo.Abp.EventBus;
using Newtonsoft.Json;


namespace AeIndexerTester;

//块数量
//交易数量
//事件数量
//IrreversibleBlockFound
//分叉
//自定义交易
//自定义事件
public class BlockChainDataFactory
{

    public static void Main()
    {
        var js = new BlockChainDataFactory().makeNormalBlocks("tDVV", 2, 3, 1);
        string jsonString = JsonConvert.SerializeObject(js);
        Console.WriteLine(jsonString);
    }


    public BlockChainDataEto makeNormalBlocks(string chainId, int blockCount, int transactionCount, int logeventCount)
    {
        // long defaultHeight = 1000000000000000;
        List<BlockEto> BlocksList = new List<BlockEto>();
        for (int i = 1; i < blockCount + 1; i++)
        {
            // long blockHeight = defaultHeight + i;
            // BlockHash = blockHeight + "cb6089ca4a8192e6770ce4468a482c1002ffa76ccbfacfd2";

            BlocksList.Add(getOneBlock(chainId, i, transactionCount));
        }

        var myObject = new BlockChainDataEto
        {
            ChainId = "chainId",
            Blocks = BlocksList
        };

        return myObject;
    }
    
    BlockEto getOneBlock(string chainId, long bHeight, int transactionCount)
    {
        string blockHash = "";
        string previousBlockHash = "";
        long defaultHeight = 1000000000000000;
        if (bHeight == 1)
        {
            blockHash = (defaultHeight + bHeight) + "cb6089ca4a8192e6770ce4468a482c1002ffa76ccbfacfd2";
            previousBlockHash = "0000000000000000000000000000000000000000000000000000000000000000";
            
        }
        else
        {
            blockHash = (defaultHeight + bHeight) + "cb6089ca4a8192e6770ce4468a482c1002ffa76ccbfacfd2";
            previousBlockHash = (defaultHeight + bHeight - 1) + "cb6089ca4a8192e6770ce4468a482c1002ffa76ccbfacfd2";
        }
        
       
        List<TransactionEto> lts = new List<TransactionEto>();
        for (int i = 0; i < transactionCount; i++)
        {
            // defaultHeight * bHeight +  + i;
            lts.Add(getOneTransaction( (defaultHeight * bHeight) + i));
        }
        BlockEto be = new BlockEto();
        be.ChainId = chainId;
        be.Height = bHeight;
        // BlockHash = defaultHeight + "cb6089ca4a8192e6770ce4468a482c1002ffa76ccbfacfd2",
        be.BlockHash = blockHash;
        Console.WriteLine(previousBlockHash + "------");
        be.PreviousBlockId = Hash.LoadFromHex(previousBlockHash);//.Parser(""),
        be.BlockHeight = bHeight;
        be.PreviousBlockHash = previousBlockHash;
        be.BlockTime = DateTime.Now;
        be.SignerPubkey = "";
        be.Signature = "";
        be.ExtraProperties = new Dictionary<string, string>()
        {

        };
        be.Transactions = lts;
        return be;
    }
    
    
    TransactionEto getOneTransaction(long bHeight)
    {
        
        // long defaultHeight = 1000000000000000;
        return new TransactionEto()
        {
            TransactionId = (bHeight) + "5d419d9397e8ae30290795340d6285db2794abe61a443966",
            From = "aefinderautotestfrom",
            To = "JRmBduh4nXWi1aXgdUsj5gJrzeZb2LxmrAbf7W99faZSvoAaE",
            MethodName = "aefinderautotestmethod",
            Params = "",
            Signature = "",
            Status = AElf.Types.TransactionResultStatus.Mined,
            Index = 1,
            ExtraProperties = new Dictionary<string, string>()
            {
                                    
            },
            LogEvents = new List<LogEventEto>()
            {
                                    
            }
        };
    }

   
    LogEventEto getOneLogEvent(string contractAddress, string  eventName)
    {
        return new LogEventEto()
        {
            ContractAddress = "",
            EventName = "",
            Index = 1
        };
    }
    
    TransactionEto getOneTransaction(long bHeight, string from, string to, string method, string status)
    {
        long defaultHeight = 1000000000000000;
        return new TransactionEto()
        {
            TransactionId = (1000000000000000 + bHeight) + "5d419d9397e8ae30290795340d6285db2794abe61a443966",
            From = from,
            To = to,
            MethodName = method,
            Params = "",
            Signature = "",
            Status = AElf.Types.TransactionResultStatus.Mined,
            Index = 1,
            ExtraProperties = new Dictionary<string, string>()
            {
                                    
            },
            LogEvents = new List<LogEventEto>()
            {
                                    
            }
        };
    }

}

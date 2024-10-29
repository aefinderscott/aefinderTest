using System.Text;
using RabbitMQ.Client;
using System;
using System.Security.Cryptography;
using System.Text;
using AElf.Types;
using Newtonsoft.Json;

namespace AeIndexerTester;

public class ProducerAuto
{
    
    // public static void Main()
    // {
    //     // 创建连接工厂
    //     var factory = new ConnectionFactory() 
    //     { 
    //         // HostName = "localhost" // 这里假设 RabbitMQ 在本地运行
    //         HostName = "192.168.71.155",  // RabbitMQ服务器地址
    //         UserName = "admin",      // 用户名
    //         Password = "admin123456"       // 密码
    //     };
    //
    //     // 建立连接
    //     using (var connection = factory.CreateConnection())
    //     {
    //         // 创建信道
    //         using (var channel = connection.CreateModel())
    //         {
    //             // 定义 exchange 的名称和类型
    //             string exchangeName = "scott_exchange";
    //             string exchangeType = "direct"; // exchange 的类型有 direct, fanout, topic, headers
    //             
    //             
    //             
    //             // string ExchangeName = "scott_exchange";
    //             // string exchangeType = "direct";
    //             string QueueName = "hello";
    //             // string RoutingKeyConfirmBlocks = "scott_routingKey";
    //
    //             // 声明 exchange
    //             channel.ExchangeDeclare(exchange: exchangeName, type: exchangeType);
    //
    //             // 定义路由键和消息
    //             string routingKey = "scott_routingKey";
    //             string message = "Hello, RabbitMQ!";
    //             var body = Encoding.UTF8.GetBytes(message);
    //
    //             // 发布消息到指定的 exchange
    //             channel.BasicPublish(exchange: exchangeName,
    //                 routingKey: routingKey,
    //                 basicProperties: null,
    //                 body: body);
    //
    //             Console.WriteLine($"[x] Sent '{message}'");
    //         }
    //     }
    //
    //     Console.WriteLine(" Press [enter] to exit.");
    //     Console.ReadLine();
    // }
    
    //
    public static void Main()
    {
        // 创建连接工厂，并设置用户名和密码
        var factory = new ConnectionFactory()
        {
            HostName = "192.168.71.155",  // RabbitMQ服务器地址
            UserName = "admin",      // 用户名
            Password = "admin123456"       // 密码
        };
    
        // 建立连接
        using (var connection = factory.CreateConnection())
            // 创建信道
        using (var channel = connection.CreateModel())
        {
            // 声明一个 direct 类型的交换机
            
            string exchangeName = "AeFinder-tDVV";
            string exchangeType = "direct";
            string QueueName = "tDVV";
            string routingKey = "AElf.WebApp.MessageQueue.BlockChainDataEto";
    
            // 声明 exchange
            // channel.ExchangeDeclare(exchange: exchangeName, type: exchangeType);
            channel.ExchangeDeclare(exchange: exchangeName, type: exchangeType, durable: true, autoDelete: false, arguments: null);
    
            // 定义路由键和消息
            // string routingKey = "example_routingKey";

            long unixTimeStamp = 1617187200; // 例如

            // 转换为 DateTime
            DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp).DateTime;
            
            
            // string input = "Hello, World!";
            //
            // using (MD5 md5 = MD5.Create())
            // {
            //     byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            //     byte[] hashBytes = md5.ComputeHash(inputBytes);
            //
            //     // 将字节数组转换为十六进制字符串
            //     string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            //     Console.WriteLine($"MD5 Hash: {hash}");
            // }
            
            var myObject = new BlockChainDataEto
            {
                ChainId = "tDVV",
                Blocks = new List<BlockEto>()
                {
                    new BlockEto()
                    {
                        ChainId = "tDVV",
                        Height = 1,
                        BlockHash = "0000000000000001cb6089ca4a8192e6770ce4468a482c1002ffa76ccbfacfd2",
                        PreviousBlockId = Hash.LoadFromHex("0000000000000000000000000000000000000000000000000000000000000000"),//.Parser(""),
                        BlockHeight = 1,
                        PreviousBlockHash = "0000000000000000000000000000000000000000000000000000000000000000",
                        BlockTime =  dateTime,
                        SignerPubkey = "",
                        Signature = "",
                        ExtraProperties = new Dictionary<string, string>()
                        {
                            
                        },
                        Transactions = new List<TransactionEto>()
                        {
                            new TransactionEto()
                            {
                                TransactionId = "",
                                From = "",
                                To = "",
                                MethodName = "",
                                Params = "",
                                Signature = "",
                                Status = AElf.Types.TransactionResultStatus.Failed,
                                Index = 1,
                                ExtraProperties = new Dictionary<string, string>()
                                {
                                    
                                },
                                LogEvents = new List<LogEventEto>()
                                {
                                    
                                }
                            }
                        }
                    },
                    new BlockEto()
                    {
                        ChainId = "tDVV",
                        Height = 2,
                        BlockHash = "0000000000000002cb6089ca4a8192e6770ce4468a482c1002ffa76ccbfacfd2",
                        PreviousBlockId = Hash.LoadFromHex("0000000000000001cb6089ca4a8192e6770ce4468a482c1002ffa76ccbfacfd2"),//.Parser(""),
                        BlockHeight = 2,
                        PreviousBlockHash = "0000000000000001cb6089ca4a8192e6770ce4468a482c1002ffa76ccbfacfd2",
                        BlockTime =  dateTime,
                        SignerPubkey = "",
                        Signature = "",
                        ExtraProperties = new Dictionary<string, string>()
                        {
                            
                        },
                        Transactions = new List<TransactionEto>()
                        {
                            new TransactionEto()
                            {
                                TransactionId = "",
                                From = "",
                                To = "",
                                MethodName = "",
                                Params = "",
                                Signature = "",
                                Status = AElf.Types.TransactionResultStatus.Failed,
                                Index = 1,
                                ExtraProperties = new Dictionary<string, string>()
                                {
                                    
                                },
                                LogEvents = new List<LogEventEto>()
                                {
                                    
                                }
                            }
                        }
                    },
                    new BlockEto()
                    {
                        ChainId = "tDVV",
                        Height = 2,
                        BlockHash = "0000000000000003cb6089ca4a8192e6770ce4468a482c1002ffa76ccbfacfd2",
                        PreviousBlockId = Hash.LoadFromHex("0000000000000002cb6089ca4a8192e6770ce4468a482c1002ffa76ccbfacfd2"),//.Parser(""),
                        BlockHeight = 3,
                        PreviousBlockHash = "0000000000000002cb6089ca4a8192e6770ce4468a482c1002ffa76ccbfacfd2",
                        BlockTime =  dateTime,
                        SignerPubkey = "",
                        Signature = "",
                        ExtraProperties = new Dictionary<string, string>()
                        {
                            
                        },
                        Transactions = new List<TransactionEto>()
                        {
                            new TransactionEto()
                            {
                                TransactionId = "",
                                From = "",
                                To = "",
                                MethodName = "",
                                Params = "",
                                Signature = "",
                                Status = AElf.Types.TransactionResultStatus.Failed,
                                Index = 1,
                                ExtraProperties = new Dictionary<string, string>()
                                {
                                    
                                },
                                LogEvents = new List<LogEventEto>()
                                {
                                    
                                }
                            }
                        }
                    }
                }
            };
            
            string jsonString = JsonConvert.SerializeObject(myObject);
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(jsonString);
            
            // var body = Encoding.UTF8.GetBytes(message);
    
            // 发布消息到指定的 exchange
            channel.BasicPublish(exchange: exchangeName,
                routingKey: routingKey,
                basicProperties: null,
                body: utf8Bytes);
    
            Console.WriteLine($"[x] Sent '{myObject}'");
        }
    
        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}
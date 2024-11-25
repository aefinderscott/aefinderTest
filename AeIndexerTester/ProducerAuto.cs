using System.Text;
using RabbitMQ.Client;
using System;
using System.Security.Cryptography;
using System.Text;
using AElf.Types;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using Scriban;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Scriban.Runtime;

namespace AeIndexerTester;

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
}

public class Person
{
    public string Name { get; set; }
    public Address Address { get; set; }
}
public class ProducerAuto
{
    public static void Main()
    {
        // string baseDir1 = AppDomain.CurrentDomain.BaseDirectory;
        // baseDir1 = Environment.CurrentDirectory;
        // string projectDir1 = Directory.GetParent(baseDir1).Parent.Parent.Parent.FullName;
        // string srcFolderPath1 = Path.Combine(projectDir1, "CaseOne") + "/";
        // var configFilePath1 = srcFolderPath1 + "CaseDescription/Data";
        // var filePath = Path.Combine(configFilePath1, "TokenTestDataProvider.json");
        // var jsonData = File.ReadAllText(filePath);
        // Console.WriteLine(jsonData);
        // var testDataList = JsonConvert.DeserializeObject<List<DataProviderObj>>(jsonData);
        // // CaseObj config = JsonConvert.DeserializeObject<CaseObj>(jsonString);
        //
        //
        // foreach (var testData in testDataList)
        // {
        //     JObject assertJsonObject = JObject.Parse(testData.Asserts.ToString());
        //     JObject jsResponse = HttpTools.HttpPostFormRequestJson("http://192.168.71.128:8082", "/connect/token", testData.Params);
        //
        //     Console.WriteLine(testData.Params);
        //     Console.WriteLine(jsResponse);
        //     // yield return new object[] { testData.Params, assertJsonObject };
        // }
        //
        // string tmp11223 = "123";
        // if ("123".Equals(tmp11223))
        // {
        //     return;
        // }
        
        
        
        CaseForTemplateObj  caseForTemplateObj = new CaseForTemplateObj();
        // 获取项目的根目录（相对于输出目录） + src路径
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        baseDir = Environment.CurrentDirectory;
        string projectDir = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;

        // 定位 src 文件夹
        string srcFolderPath = Path.Combine(projectDir, "CaseOne") + "/";

        Console.WriteLine("项目的 src 文件夹路径：" + srcFolderPath);
        
        var configFilePath = srcFolderPath + "CaseDescription/Template";


        List<string> configFiles = new List<string>();
        // 检查目录是否存在
        if (Directory.Exists(configFilePath))
        {
            // 调用递归函数遍历所有文件
            TraverseDirectory(configFilePath, configFiles);
        }
        else
        {
            Console.WriteLine("指定的目录不存在.");
        }

        string clazzname = "";
        foreach (var configFile in configFiles)
        {
            Console.WriteLine("指定的目录不存在." + configFile);
            string fileName = configFile.Replace(configFilePath, "");
            clazzname = fileName.Replace(".json","").Substring(1);
            string namespacename = "";
            Console.WriteLine("123指定的目录不存在." + fileName);
            Console.WriteLine("123指定的目录不存在." + fileName.Replace("/", "."));
            string[] str = fileName.Replace("/", ".").Split(".");
            Console.WriteLine("123指定的目录不存在." + str.Length);
            for (int i = 1; i < str.Length - 2; i++)
            {
                namespacename = namespacename + "." + str[i];
            }

            if ("".Equals(namespacename))
            {
                namespacename = "CaseOne";
            }

            if (namespacename.StartsWith("."))
            {
                namespacename = namespacename.Substring(1);
            }
            namespacename = "CaseOne";

            caseForTemplateObj.NameSpaceName = namespacename;
            Console.WriteLine("指定的目录不存在.namespacename:" + namespacename);
            try
            {
                // 读取 JSON 文件内容
                string? jsonString = File.ReadAllText(configFile);
                // List<CaseObj> config = JsonConvert.DeserializeObject<List<CaseObj>>(jsonString);
                // // 将 JS
                CaseObj config = JsonConvert.DeserializeObject<CaseObj>(jsonString);
                
                
               
                
                    
                    
                    
                caseForTemplateObj.CaseObj = new CaseObjForTemplate()
                {
                    SetUp = config.SetUp,
                    TearDown = config.TearDown
                };
                caseForTemplateObj.CaseObj.CaseDetail = new CaseDetailsForTemplate()
                {
                    Name = config.CaseDetail.Name,
                    Description = config.CaseDetail.Description,
                    DataProvider = config.CaseDetail.DataProvider
                };
                List<StepsForTemplate> stlst = new List<StepsForTemplate>();
                List<Steps> stls  = config.CaseDetail.Steps;
                foreach (var stl in stls)
                {
                    
                    
                    var jsonObject = JObject.Parse( stl.Asserts.ToString());
                    List<AssertObj> assertObjList = new List<AssertObj>();
                    foreach (var property in jsonObject.Properties())
                    {
                        assertObjList.Add(new AssertObj()
                        {
                            AssertPath = property.Name,
                            ExpectValue = property.Value
                        });
                    }


                    string resType = "JObject";
                    if (null != stl.ResponseType)
                    {
                        resType = stl.ResponseType;
                    }
                        
                        
                    //参数处理，增加json引号
                    Request re = stl.Request;
                    string paramstr = re.Params.ToString();
                    // paramstr.Replace("\"", "\\\"").Replace("\r\n", "").Replace("\n", "").Replace(" ", "");;
                    // JObject jo = JObject.Parse(re.Params.ToString());
                    re.Params = paramstr.Replace("\"", "\\\"").Replace("\r\n", "").Replace("\n", "").Replace("  ", "");
                    // re.Params = JsonSerializer.Serialize(re.Params.ToString());
                    
                    
                    stlst.Add(new StepsForTemplate()
                    {
                        StepNo = stl.StepNo,
                        Request = re,
                        Asserts = assertObjList,
                        ResponseType = resType
                    });

                }

                caseForTemplateObj.CaseObj.CaseDetail.Steps = stlst;
                Console.WriteLine("Database Connection String: " + config.CaseDetail.Name);
                // Console.teLine("Log File Path: " + appConfig.Logging.LogFilePath);
                
                caseForTemplateObj.ClazzName = clazzname;
        
                // Console.WriteLine(caseForTemplateObj.CaseObj.CaseDetail.Steps[0].Request.Params.ToString());
                // string tmp1122 = "123";
                // if ("123".Equals(tmp1122))
                // {
                //     return;
                // }


        string path = projectDir + "/AeIndexerTester/test_template2.sbn";
        if (null != caseForTemplateObj.CaseObj.CaseDetail.DataProvider)
        {
            path = projectDir + "/AeIndexerTester/test_template.sbn";
        }
        
        // string path = projectDir + "/AeIndexerTester/test_template.sbn";
        string fileContent = File.ReadAllText(path);
        // 创建模板
        var template = Template.Parse(fileContent);
        
        var result = template.Render(new {  case_for_template_obj = caseForTemplateObj});
        // 渲染模板并生成测试代码
        // string result = template.Render(model);

        // 将生成的代码保存到文件中
        File.WriteAllText(srcFolderPath + caseForTemplateObj.ClazzName + ".cs", result);

        // 打印生成的代码
        Console.WriteLine("Generated Test Code:\n");
        Console.WriteLine(result);
                
                
                
                
                
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取配置文件时出错: " + ex.Message);
            }
        }

        
    


        string tmp = "123";
        if ("123".Equals(tmp))
        {
            return;
        }
        
        // string hname = "192.168.71.155";  // RabbitMQ服务器地址
        // string uname = "admin";     // 用户名
        // string pwd = "admin123456";  //密码
        // string chainid = "tDVV";  //链id
        // int blockCount = 3; //生成block数量
        // int transactionCount = 3;  //生成交易数量
        // int logeventCount = 3; //生成logevent数量
        //
        // var blockstr = new BlockChainDataFactory().makeNormalBlocks(chainid, blockCount, transactionCount, logeventCount);
        //
        // new ProducerAuto().sendBlocks(hname, uname, pwd, chainid, blockstr);
        
        
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
            // var js = new BlockChainDataFactory().makeNormalBlocks("tDVV", 2, 3, 1);
            // string blocksStr = JsonConvert.SerializeObject(js);
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(jsonString);
            
            // var body = Encoding.UTF8.GetBytes(message);
        
            // 发布消息到指定的 exchange
            channel.BasicPublish(exchange: exchangeName,
                routingKey: routingKey,
                basicProperties: null,
                body: utf8Bytes);
        
            Console.WriteLine($"[x] Sent '{jsonString}'");
        }
        
        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
    
    // 递归遍历目录及其子目录下的所有文件
    static void TraverseDirectory(string directoryPath, List<string> configFiles)
    {
        try
        {
            // 获取当前目录下的所有文件
            string[] files = Directory.GetFiles(directoryPath);
            foreach (var file in files)
            {
                Console.WriteLine(file); // 输出文件名
                configFiles.Add(file);
            }

            // 获取当前目录下的所有子目录并递归遍历
            string[] subDirectories = Directory.GetDirectories(directoryPath);
            foreach (var subDirectory in subDirectories)
            {
                TraverseDirectory(subDirectory, configFiles); // 递归调用自身
            }
        }
        catch (Exception ex)
        { 
            Console.WriteLine($"遍历目录 {directoryPath} 时出错: {ex.Message}");
        }
    }

    public void sendBlocks(string host, string uname, string pwd, string chainid, BlockChainDataEto blocks)
    {
        // 创建连接工厂，并设置用户名和密码
        var factory = new ConnectionFactory()
        {
            HostName = host,  // RabbitMQ服务器地址
            UserName = uname,      // 用户名
            Password = pwd       // 密码
        };
    
        // 建立连接
        using (var connection = factory.CreateConnection())
            // 创建信道
        using (var channel = connection.CreateModel())
        {
            // 声明一个 direct 类型的交换机
            string exchangeName = "AeFinder-" + chainid;
            string exchangeType = "direct";
            // string QueueName = chainid;
            string routingKey = "AElf.WebApp.MessageQueue.BlockChainDataEto";
    
            // 声明 exchange
            // channel.ExchangeDeclare(exchange: exchangeName, type: exchangeType);
            channel.ExchangeDeclare(exchange: exchangeName, type: exchangeType, durable: true, autoDelete: false, arguments: null);
            
            // string jsonString = JsonConvert.SerializeObject(myObject);
            // var js = new BlockChainDataFactory().makeNormalBlocks("tDVV", 2, 3, 1);
            string blocksStr = JsonConvert.SerializeObject(blocks);
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(blocksStr);
            
            // var body = Encoding.UTF8.GetBytes(message);
    
            // 发布消息到指定的 exchange
            channel.BasicPublish(exchange: exchangeName,
                routingKey: routingKey,
                basicProperties: null,
                body: utf8Bytes);
    
            Console.WriteLine($"[x] Sent '{blocksStr}'");
        }
    
        // Console.WriteLine(" Press [enter] to exit.");
        // Console.ReadLine();
    }
}
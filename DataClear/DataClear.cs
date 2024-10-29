using AeIndexerTester;

namespace DataClear;

[TestFixture]
public class DataClear
{
    [SetUp]
    public void Setup()
    {
        EsTools.FlushIndex("http://192.168.71.150:9200", null).GetAwaiter().GetResult();
        Console.WriteLine("es completed.");
        MongdbTools.FlushDB("mongodb://admin:admin123456@192.168.71.170:20000,192.168.71.171:20000,192.168.71.172:20000", "AeFinderOrleansDB").GetAwaiter().GetResult();
        Console.WriteLine("mong completed.");
        RedisTools.flushRedis("192.168.71.150:6375");
        
        
        
        // "HostName": "192.168.71.155",
        // "Port": "5672",
        // "UserName": "admin",
        // "Password": "admin123456"
        string rabbitMqHost = "192.168.71.155"; // RabbitMQ 主机名或 IP
        // string managementUrl = $"http://{rabbitMqHost}:15672/api/queues";
        string username = "admin"; // 默认用户名
        string password = "admin123456"; // 默认密码
        RabbitmqTools.FlusQueues(rabbitMqHost, username, password).GetAwaiter().GetResult();
        Console.WriteLine("Rabbitmq completed.");
        RabbitmqTools.FlusExchanges(rabbitMqHost, username, password).GetAwaiter().GetResult();
        Console.WriteLine("Rabbitmq completed.");
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    
}
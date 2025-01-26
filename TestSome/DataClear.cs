using AeIndexerTester;

namespace DataClear;

[TestFixture]
public class DataClear
{
    [SetUp]
    public void Setup()
    {
        //es清理
        EsTools.FlushIndex("http://192.168.71.38:9200", null).GetAwaiter().GetResult();
        Console.WriteLine("es completed.");
        
        //mong清理
        MongdbTools.FlushDB("mongodb://admin:admin@192.168.71.146:20000,192.168.71.147:20000,192.168.71.148:20000", "AeFinderOrleansDB").GetAwaiter().GetResult();
        Console.WriteLine("mong completed.");
        
        //redis清理
        RedisTools.flushRedis("192.168.71.127:6379");
        
        //mq清理
        string rabbitMqHost = "192.168.71.127"; // RabbitMQ 主机名或 IP
        string username = "admin"; // 默认用户名
        string password = "admin123456"; // 默认密码
        RabbitmqTools.FlusQueues(rabbitMqHost, username, password).GetAwaiter().GetResult();
        RabbitmqTools.FlusExchanges(rabbitMqHost, username, password).GetAwaiter().GetResult();
        Console.WriteLine("Rabbitmq completed.");
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    
}
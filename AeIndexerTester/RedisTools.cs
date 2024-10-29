using StackExchange.Redis;

namespace AeIndexerTester;

public class RedisTools
{
    public static void flushRedis(string dbUrl)
    {
        // 连接到 Redis 服务器
        var redis = ConnectionMultiplexer.Connect("localhost");

        // 获取默认数据库
        var db = redis.GetDatabase();

        // 执行 FLUSHDB 命令
        db.Execute("FLUSHDB");

        Console.WriteLine("Redis database cleared.");
    }
}
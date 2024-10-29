using MongoDB.Driver;
using Nest;

namespace AeIndexerTester;

public class MongdbTools
{
    public static async Task FlushDB(string dbUrl, string databaseName)
    {
        // 连接到 MongoDB 服务器
        var client = new MongoClient(dbUrl);

        // 指定数据库名称
        // var databaseName = "yourDatabaseName";

        // 删除数据库
        await client.DropDatabaseAsync(databaseName);

        System.Console.WriteLine($"{databaseName} has been dropped.");
    }
}
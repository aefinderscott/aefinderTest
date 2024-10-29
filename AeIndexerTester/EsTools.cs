using Nest;

namespace AeIndexerTester;

public class EsTools
{
    public static void Main(string[] args)
    {
        // 同步等待异步任务完成
        // FlushIndex().GetAwaiter().GetResult();
        Console.WriteLine("Main completed.");
    }

    /*
     * 清理es索引，indexDelName为null则清理全部
     */
    public static async Task FlushIndex(string esUrl, string? indexDelName)
    {

        // 设置 Elasticsearch 连接设置
        var settings = new ConnectionSettings(new Uri(esUrl));

        // 创建 Elastic 客户端
        var client = new ElasticClient(settings);

        try
        {

            if (null != indexDelName)
            {
                string indexName = indexDelName;
                var deleteIndexResponse = await client.Indices.DeleteAsync(indexName);

                if (deleteIndexResponse.IsValid)
                {
                    Console.WriteLine($"Index {indexName} deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to delete index {indexName}. Reason: {deleteIndexResponse.ServerError?.Error.Reason}");
                }
            }
            else
            {
                
                // 获取集群所有索引信息
                var indicesResponse = await client.Cat.IndicesAsync();

                if (indicesResponse.IsValid)
                {
                    foreach (var indexInfo in indicesResponse.Records)
                    {
                        string indexName = indexInfo.Index;
                        Console.WriteLine($"Attempting to delete index: {indexName}");

                        // 删除索引
                        var deleteIndexResponse = await client.Indices.DeleteAsync(indexName);

                        if (deleteIndexResponse.IsValid)
                        {
                            Console.WriteLine($"Index {indexName} deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to delete index {indexName}. Reason: {deleteIndexResponse.ServerError?.Error.Reason}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Failed to retrieve index information.");
                }
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

    }
}
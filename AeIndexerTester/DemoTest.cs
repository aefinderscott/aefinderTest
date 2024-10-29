namespace AeIndexerTester;

using System;
using System.Threading.Tasks;
using RestSharp;

class DemoTest
{
    static async Task Main()
    {
        // 创建 RestClient 实例并设置请求的 URL
        var client = new RestClient("https://api.example.com");

        // 创建 RestRequest 实例并指定请求的资源和方法
        var request = new RestRequest("submit", Method.Post);

        // 将请求内容类型设置为 application/x-www-form-urlencoded
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

        // 添加表单参数
        request.AddParameter("username", "john_doe");
        request.AddParameter("password", "securepassword");
        request.AddParameter("age", "30");

        try
        {
            // 执行异步请求并获取响应
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine("Success:");
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine("Error:");
                Console.WriteLine(response.Content);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Request failed: {ex.Message}");
        }
    }
}
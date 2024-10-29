using System.Net.Http.Headers;
using System.Text;
using RabbitMQ.Client;

namespace AeIndexerTester;

public class RabbitmqTools
{
    public static async Task FlusQueues(string rabbitMqHost, string username, string password  )
    {
        // "HostName": "192.168.71.155",
        // "Port": "5672",
        // "UserName": "admin",
        // "Password": "admin123456"
        // string rabbitMqHost = "localhost"; // RabbitMQ 主机名或 IP
        string managementUrl = $"http://{rabbitMqHost}:15672/api/queues";
        // string username = "guest"; // 默认用户名
        // string password = "guest"; // 默认密码
        
        // var factory = new ConnectionFactory()
        // {
        //     HostName = rabbitMqHost,
        //     UserName = username, // 用户名
        //     Password = password, // 密码
        //     VirtualHost = "/"    // 虚拟主机名
        // };
        // try
        // {
        //     using var connection = factory.CreateConnection();
        //     using var channel = connection.CreateModel();
        //
        //     Console.WriteLine("Connected to RabbitMQ successfully!");
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine($"Connection failed: {ex.Message}");
        // }

        // 获取所有队列的列表
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));

        HttpResponseMessage response = await client.GetAsync(managementUrl);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            dynamic queues = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

            // 连接到 RabbitMQ
            // var factory = new ConnectionFactory() { HostName = rabbitMqHost };
            var factory = new ConnectionFactory()
            {
                HostName = rabbitMqHost,
                UserName = username, // 用户名
                Password = password, // 密码
                VirtualHost = "/"    // 虚拟主机名
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                foreach (var queue in queues)
                {
                    string queueName = queue.name;
                    Console.WriteLine($"Deleting queue: {queueName}");
                    channel.QueueDelete(queueName);
                }
            }
            Console.WriteLine("All queues deleted.");
        }
        else
        {
            Console.WriteLine($"Failed to get queues: {response.ReasonPhrase}");
        }
    }

    public static async Task FlusExchanges(string rabbitMqHost, string username, string password)
    {
        // string rabbitMqHost = "localhost"; // RabbitMQ 主机名或 IP
        string managementUrl = $"http://{rabbitMqHost}:15672/api/exchanges/%2F"; // 使用 HTTP API
        // string username = "guest"; // 默认用户名
        // string password = "guest"; // 默认密码

        // 初始化 HTTP 客户端
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));

        // 获取所有交换的信息
        HttpResponseMessage response = await client.GetAsync(managementUrl);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            dynamic exchanges = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

            foreach (var exchange in exchanges)
            {
                string exchangeName = exchange.name.ToString();
                if (!string.IsNullOrEmpty(exchangeName) && exchangeName != "amq.default"&& !exchangeName.StartsWith("amq"))
                {
                    Console.WriteLine($"Deleting exchange: {exchangeName}");

                    HttpResponseMessage deleteResponse = await client.DeleteAsync(
                        $"{managementUrl}/{Uri.EscapeDataString(exchangeName)}");

                    if (deleteResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Exchange {exchangeName} deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to delete exchange {exchangeName}: {deleteResponse.ReasonPhrase}");
                    }
                }
            }
            Console.WriteLine("Done deleting exchanges.");
        }
        else
        {
            Console.WriteLine($"Failed to get exchanges: {response.ReasonPhrase}");
        }
    }
}
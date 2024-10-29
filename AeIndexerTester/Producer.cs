namespace AeIndexerTester;

using System;
using RabbitMQ.Client;
using System.Text;

class Producer
{
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
            // 声明一个队列
            channel.QueueDeclare(queue: "hello",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            string message = "Hello World with Auth!";
            var body = Encoding.UTF8.GetBytes(message);

            // 发送消息
            channel.BasicPublish(exchange: "scott",
                routingKey: "hello",
                basicProperties: null,
                body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}

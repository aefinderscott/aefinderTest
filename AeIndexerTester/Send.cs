namespace AeIndexerTester;

using System;
using RabbitMQ.Client;
using System.Text;

class Send
{
    public static void Main()
    {
        // "RabbitMQ": {
        //     "HostName": "192.168.71.155",
        //     "Port": "5672",
        //     "ClientName": "AELF",
        //     "ExchangeName": "AeFinder-AELF",
        //     "UserName": "admin",
        //     "Password": "admin123456",
        //     "Uri": "amqp://192.168.71.155:5672"
        // },
        // 创建连接工厂，设置主机名
        var factory = new ConnectionFactory() { HostName = "192.168.71.155" };

        // 建立连接
        using(var connection = factory.CreateConnection())
            // 创建信道
        using(var channel = connection.CreateModel())
        {
            // 声明队列
            channel.QueueDeclare(queue: "AELF",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            // 要发送的消息
            string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);

            // 发布消息到队列
            channel.BasicPublish(exchange: "AeFinder-AELF",
                routingKey: "AELF",
                basicProperties: null,
                body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }

        Console.WriteLine("按任意键退出。");
        Console.ReadKey();
    }
}

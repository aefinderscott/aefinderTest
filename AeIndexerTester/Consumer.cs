namespace AeIndexerTester;

using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

class Consumer
{
    public static void Main()
    {
        // "HostName": "192.168.71.155",
        // "Port": "5672",
        // "UserName": "admin",
        // "Password": "admin123456"
        // 创建连接工厂，并设置用户名和密码
        // var factory = new ConnectionFactory()
        // {
        //     HostName = "192.168.71.155",  // RabbitMQ服务器地址
        //     UserName = "admin",      // 用户名
        //     Password = "admin123456"       // 密码
        // };
        //
        // // 建立连接
        // using (var connection = factory.CreateConnection())
        //     // 创建信道
        // using (var channel = connection.CreateModel())
        // {
        //     // 声明队列
        //     channel.QueueDeclare(queue: "hello",
        //         durable: false,
        //         exclusive: false,
        //         autoDelete: false,
        //         arguments: null);
        //
        //     Console.WriteLine(" [*] Waiting for messages.");
        //
        //     // 定义消费者
        //     var consumer = new EventingBasicConsumer(channel);
        //     consumer.Received += (model, ea) =>
        //     {
        //         var body = ea.Body.ToArray();
        //         var message = Encoding.UTF8.GetString(body);
        //         Console.WriteLine(" [x] Received {0}", message);
        //     };
        //
        //     // 启动消费者
        //     channel.BasicConsume(queue: "hello",
        //         autoAck: true,
        //         consumer: consumer);
        //
        //     Console.WriteLine(" Press [enter] to exit.");
        //     Console.ReadLine();
        // }
        
        Run();
    }
    
    
    
    
    
    public static void Run()
{
    // var factory = new ConnectionFactory() { HostName = "127.0.0.1", UserName = "guest", Password = "guest"};
    var factory = new ConnectionFactory() {  UserName = "admin", Password = "admin123456"};
    var connection = factory.CreateConnection(new string[] {
                        "192.168.71.155",
                        
        });
    
    string ExchangeName = "AeFinder-tDVV";
    string exchangeType = "direct";
    string QueueName = "tDVV";
    // string routingKey = "scott_routingKey";
    
    // string ExchangeName = "scott_exchange";
    // string exchangeType = "direct";
    // string QueueName = "hello";
    string RoutingKeyConfirmBlocks = "AElf.WebApp.MessageQueue.BlockChainDataEto";
    using (var channel = connection.CreateModel())
    {
        //声明交换机
        channel.ExchangeDeclare(ExchangeName, "direct", durable: true);
        //声明队列
        // channel.QueueDeclare(QueueName);
        //将队列绑定到交换机
        // channel.QueueBind(QueueName, ExchangeName, RoutingKeyNewBlocks);
        channel.QueueBind(QueueName, ExchangeName, RoutingKeyConfirmBlocks);

        Console.WriteLine(" [*] Waiting for messages.");
        // Log.Logger = new LoggerConfiguration().
        //     MinimumLevel.Debug().
        //     MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
        //     .ReadFrom.Configuration(new ConfigurationBuilder()
        //         .AddJsonFile("appsettings.json")
        //         .Build())
        //     .Enrich.FromLogContext().
        //     /*WriteTo.File(Path.Combine("logs", @"log.txt"), (Serilog.Events.LogEventLevel)RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}").
        //      .WriteTo.MSSqlServer("Data Source=DESKTOP-4TU9A6M;Initial Catalog=CoreFrame;User ID=sa;Password=123456", "logs", autoCreateSqlTable: true, restrictedToMinimumLevel: LogEventLevel.Information)*/
        //     CreateLogger();

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, basicDeliverEventArgs) =>
        {
            try
            {
                var body = basicDeliverEventArgs.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());
                // Log.Information(message);
                Console.WriteLine(" [x] Received '{0}':'{1}'",
                    basicDeliverEventArgs.RoutingKey, message);
                channel.BasicAck(basicDeliverEventArgs.DeliveryTag, multiple: false);

                throw new Exception("just for test");
            }
            catch (Exception ex)
            {
                try
                {
                    channel.BasicNack(
                        basicDeliverEventArgs.DeliveryTag,
                        multiple: false,
                        requeue: true
                    );
                }
                // ReSharper disable once EmptyGeneralCatchClause
                catch { }
                // Log.Error(ex, "Error");

            }
        };

        // channel.BasicConsume(queue: QueueName,
        //     autoAck: true,
        //     consumer: consumer);
        channel.BasicConsume(
            queue: QueueName,
            autoAck: false,
            consumer: consumer
        );
        // Log.Information("Consume end.");
        Console.ReadLine();


    }
}
}

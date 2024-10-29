using Renci.SshNet;

namespace AeIndexerTester;

using System;
using System.Diagnostics;

public class EnvManager
{
    public static void initEnv()
    {
        //stop
        //flush
        //start
    }
    
    public static void stopEnv()
    {
        // 配置远程连接的详细信息
        string host = "your-remote-host.com";
        string username = "your-username";
        string password = "your-password";

        using (var client = new SshClient(host, username, password))
        {
            try
            {
                // 连接到远程服务器
                client.Connect();

                // 定义要执行的多个命令
                string commands = "echo Hello; echo World; ls -l;";

                // 执行命令
                using (var cmd = client.CreateCommand(commands))
                {
                    string result = cmd.Execute();

                    Console.WriteLine("Command Output:");
                    Console.WriteLine(result);

                    if (!string.IsNullOrWhiteSpace(cmd.Error))
                    {
                        Console.WriteLine("Command Error:");
                        Console.WriteLine(cmd.Error);
                    }
                }

                // 断开连接
                client.Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
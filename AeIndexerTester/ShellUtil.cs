namespace AeIndexerTester;

using System;
using System.Diagnostics;

public class ShellUtil
{
    public string RunShellCommand(string command)
    {
        try
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "/bin/bash",   // 使用bash执行所有命令 (Windows可使用 cmd.exe)
                Arguments = "-c \"" + command + "\"",  // 使用"-c"传递命令
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(processStartInfo))
            {
                // 读取并打印输出
                string result = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                Console.WriteLine(result);
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine($"Error: {error}");
                    return error;
                }

                return result;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return ex.Message;
        }

        return "";
    }
}
using AeIndexerTester;
using Microsoft.Extensions.Options;
using HttpRequest = AeIndexerTester.HttpRequest;

namespace DataManager;

public interface IEnvService
{
    void InitEnv(string envName);
    void StopEnv(string envName);
    void StartEnv(string name);
    
    EnvSettings GetEnv(string name);
}

public class EnvService : IEnvService
{
    private readonly List<EnvSettings> _envSettings;

    // 通过构造函数注入 EmailSettings
    public EnvService(IOptions<List<EnvSettings>> envSettings)
    {
        _envSettings = envSettings.Value;
    }

    public void InitEnv(string envName)
    {
        StopEnv(envName);
        StartEnv(envName);
    }
    
    public void StopServer(string envName)
    {
        StopEnv(envName);
        StartEnv(envName);
    }

    public void StopEnv(string envName)
    {
        foreach (var esetibg in _envSettings)
        {
            if (esetibg.Name.Equals(envName))
            {
                string hostname = esetibg.Apps.Aefinder.FinderMainchainEntityEventHandler;
                HttpRequest.BaseUrl("http://" + hostname).Path("/api/envagent/exec?execCommand=docker stop finder-silo finder-sidechain-entity-event-handler finder-mainchain-entity-event-handler finder-sidechain-blockchaineventhandler finder-mainchain-blockchaineventhandler finder-backgroundworker finder-httpapi-host finder-auth-server").HttpMethod("post").ContentType("application/x-www-form-urlencoded").Params("{\"execCommand\":\"docker stop finder-silo finder-sidechain-entity-event-handler finder-mainchain-entity-event-handler finder-sidechain-blockchaineventhandler finder-mainchain-blockchaineventhandler finder-backgroundworker finder-httpapi-host finder-auth-server\"}")
                    .QuickExec();
                
                
                
                // ShellUtil su = new ShellUtil();
                //
                // string multiCommand = "docker stop finder-silo finder-sidechain-entity-event-handler finder-mainchain-entity-event-handler finder-sidechain-blockchaineventhandler finder-mainchain-blockchaineventhandler finder-backgroundworker finder-httpapi-host finder-auth-server";  // Linux/macOS 脚本测试
                // su.RunShellCommand(multiCommand);
                
                //es清理
                EsTools.FlushIndex(esetibg.Elasticsearch.Uri, null).GetAwaiter().GetResult();
                Console.WriteLine("es completed.");
                
                //mong清理
                MongdbTools.FlushDB(esetibg.Mongodb.Uri, esetibg.Mongodb.Dbname).GetAwaiter().GetResult();
                Console.WriteLine("mong completed.");
                
                //redis清理
                RedisTools.flushRedis(esetibg.Redis.Configuration);
                
                //mq清理
                string rabbitMqHost = esetibg.RabbitMQ.HostName; // RabbitMQ 主机名或 IP
                string username = esetibg.RabbitMQ.UserName; // 默认用户名
                string password = esetibg.RabbitMQ.Password; // 默认密码
                RabbitmqTools.FlusQueues(rabbitMqHost, username, password).GetAwaiter().GetResult();
                RabbitmqTools.FlusExchanges(rabbitMqHost, username, password).GetAwaiter().GetResult();
                Console.WriteLine("Rabbitmq completed.");
            }
        }
        
    }
    
    public EnvSettings GetEnv(string envName)
    {
        foreach (var esetibg in _envSettings)
        {
            if (esetibg.Name.Equals(envName))
            {
                return esetibg; 
            }
        }

        return null;
    }
    

    public void StartEnv(string envName)
    {
        foreach (var esetibg in _envSettings)
        {
            if (esetibg.Name.Equals(envName))
            {
                string hostname = esetibg.Apps.Aefinder.FinderMainchainEntityEventHandler;
                HttpRequest.BaseUrl("http://" + hostname)
                    .Path(
                        "/api/envagent/exec?execCommand=docker restart finder-silo finder-sidechain-entity-event-handler finder-mainchain-entity-event-handler finder-sidechain-blockchaineventhandler finder-mainchain-blockchaineventhandler finder-backgroundworker finder-httpapi-host finder-auth-server")
                    .HttpMethod("post").ContentType("application/x-www-form-urlencoded").Params(
                        "{\"execCommand\":\"docker stop finder-silo finder-sidechain-entity-event-handler finder-mainchain-entity-event-handler finder-sidechain-blockchaineventhandler finder-mainchain-blockchaineventhandler finder-backgroundworker finder-httpapi-host finder-auth-server\"}")
                    .QuickExec();
            }
        }
        // ShellUtil su = new ShellUtil();
        // string multiCommand = "docker restart finder-silo finder-sidechain-entity-event-handler finder-mainchain-entity-event-handler finder-sidechain-blockchaineventhandler finder-mainchain-blockchaineventhandler finder-backgroundworker finder-httpapi-host finder-auth-server";  // Linux/macOS 脚本测试
        // su.RunShellCommand(multiCommand);
    }
}
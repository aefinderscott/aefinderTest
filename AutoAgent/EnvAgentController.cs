using AeIndexerTester;
using Microsoft.AspNetCore.Mvc;

namespace AutoAgent.Controllers
{
    // [ApiController] 标识这是一个API控制器
    [ApiController]
    [Route("api/[controller]")]  // [controller] 将自动映射为控制器名称，如 'Hello'
    public class EnvAgentController : ControllerBase
    {
        // private readonly IEnvService _envService;  // 引入服务接口
        //
        // // 通过构造函数注入服务
        // public EnvAgentController(IEnvService envService)
        // {
        //     _envService = envService;
        // }
        
        [HttpPost("exec")]
        public IActionResult Exec(string execCommand)
        {
            ShellUtil su = new ShellUtil();
            // string multiCommand = "docker restart finder-silo finder-sidechain-entity-event-handler finder-mainchain-entity-event-handler finder-sidechain-blockchaineventhandler finder-mainchain-blockchaineventhandler finder-backgroundworker finder-httpapi-host finder-auth-server";  // Linux/macOS 脚本测试
            string rs = su.RunShellCommand(execCommand);
            return Ok($"Exec!{execCommand}\n{rs}");  // 
        }
    }

    
}
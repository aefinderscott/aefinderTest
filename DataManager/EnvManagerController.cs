using AeIndexerTester;
using DataManager;
using Microsoft.AspNetCore.Mvc;

namespace EnvManager.Controllers
{
    // [ApiController] 标识这是一个API控制器
    [ApiController]
    [Route("api/[controller]")]  // [controller] 将自动映射为控制器名称，如 'Hello'
    public class EnvmanagerController : ControllerBase
    {
        private readonly IEnvService _envService;  // 引入服务接口

        // 通过构造函数注入服务
        public EnvmanagerController(IEnvService envService)
        {
            _envService = envService;
        }
        
        [HttpGet("Stop")]
        public IActionResult Stop(string envName)
        {
            _envService.StopEnv(envName);
            return Ok($"stop!{envName}");  // 
        }
        
        [HttpGet("Start")]
        public IActionResult Start(string envName)
        {
            _envService.StartEnv(envName);
            return Ok($"Start!");  // 
        }
        
        [HttpGet("Init")]
        public IActionResult Init(string envName)
        {
            _envService.InitEnv(envName);
            return Ok($"Start!{envName}");  // 
        }
        
        [HttpGet("maker")]
        public IActionResult maker(string chainid, int blockCount, int transactionCount, int logeventCount)
        {
            string hname = "192.168.71.155";  // RabbitMQ服务器地址
            string uname = "admin";     // 用户名
            string pwd = "admin123456";  //密码
            // string chainid = "tDVV";  //链id
            // int blockCount = 4; //生成block数量
            // int transactionCount = 1;  //生成交易数量
            // int logeventCount = 1; //生成logevent数量
        
            var blockstr = new BlockChainDataFactory().makeNormalBlocks(chainid, blockCount, transactionCount, logeventCount);
            
            new ProducerAuto().sendBlocks(hname, uname, pwd, chainid, blockstr);
            return Ok($"Start!");  // 
        }
        
        // 处理 GET: api/hello
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello, World!");  // 返回 200 OK 状态码和消息
        }

        // 支持带参数的 GET 请求：GET: api/hello/{name}
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return Ok($"Hello, {name}!");  // 动态返回用户提供的名字
        }
        
        
    }

    
}
using AeIndexerTester;
using Microsoft.AspNetCore.Mvc;

namespace DataManager.Controllers
{
    // [ApiController] 标识这是一个API控制器
    [ApiController]
    [Route("api/[controller]")]  // [controller] 将自动映射为控制器名称，如 'Hello'
    public class DatamanagerController : ControllerBase
    {
        private readonly IEnvService _envService;  // 引入服务接口

        // 通过构造函数注入服务
        public DatamanagerController(IEnvService envService)
        {
            _envService = envService;
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
        
        [HttpPost("makeBlocks")]
        public IActionResult makeBlocks([FromBody] BlockDto bd)
        {
            // string hname = "192.168.71.155";  // RabbitMQ服务器地址
            // string uname = "admin";     // 用户名
            // string pwd = "admin123456";  //密码
            // bd.hname = hname;
            // bd.pwd = pwd;
            // bd.uname = uname;
            // 检查数据模型是否有效
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }
            
            // string chainid = "tDVV";  //链id
            // int blockCount = 3; //生成block数量
            // int transactionCount = 3;  //生成交易数量
            // int logeventCount = 3; //生成logevent数量
        
            var blockstr = new BlockChainDataFactory().makeNormalBlocks(bd.Chainid, bd.BlockCount, bd.TransactionCount, bd.LogeventCount);


            EnvSettings envSettings = _envService.GetEnv(bd.EnvName);
            new ProducerAuto().sendBlocks(envSettings.RabbitMQ.HostName, envSettings.RabbitMQ.UserName, envSettings.RabbitMQ.Password, bd.Chainid, blockstr);
            

            // 数据处理逻辑 (例如存储到数据库)
            return Ok($"Block Created: {bd.BlockCount} {bd.TransactionCount}, Age: {bd.LogeventCount}");
        }
    }

    
}
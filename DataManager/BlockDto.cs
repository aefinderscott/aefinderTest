namespace DataManager.Controllers;

public class BlockDto
{
    // public string hname { get; set; }
    // public string uname { get; set; }
    // public string pwd { get; set; }
    public string EnvName { get; set; }
    public string Chainid { get; set; }
    public int BlockCount { get; set; }
    public int TransactionCount { get; set; }
    public int LogeventCount { get; set; }

    // string hname = "192.168.71.155";  // RabbitMQ服务器地址
    // string uname = "admin";     // 用户名
    // string pwd = "admin123456";  //密码
    // string chainid = "tDVV";  //链id
    // int blockCount = 3; //生成block数量
    // int transactionCount = 3;  //生成交易数量
    // int logeventCount = 3; //生成logevent数量
}
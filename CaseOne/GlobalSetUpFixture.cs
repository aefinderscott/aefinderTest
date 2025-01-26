using System.Reflection;
using AeIndexerTester;
using DataManager.Controllers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CaseOne;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

//所有test管控
[SetUpFixture]
public class GlobalSetUpFixture
{
    public static ExtentReports Extent;
    private ExtentHtmlReporter htmlReporter;

    private string  DataServerUrl = "http://192.168.71.14:6555";
    private string  MakeBlockPath = "/api/datamanager/makeBlocks";
    private string  InitEnvPath = "/api/envmanager/init";
    private string  TestEnvName = "test001";
    //
    // private static ExtentTest test;
    // // 静态成员在应用程序启动时自动创建
    // // private static ExtentReports ext;// = new GlobalExtentReport();
    //
    // public static Dictionary<string, ExtentTest?>? TestReport = new Dictionary<string, ExtentTest?>();
    //
    // 全局初始化：所有测试类运行之前
    //1、定义测试报告 2、环境初始化 3、数据初始化
    [OneTimeSetUp]
    public void GlobalSetup()
    { 
        //初始化环境
        initEnv(TestEnvName);
        
        //批量初始化数据
        makeBlocks(TestEnvName,"tDVV",100,1,1);

        //初始化测试报告
        initReport();

    }

    // 全局结束：所有测试类运行完毕之后
    [OneTimeTearDown]
    public void GlobalTeardown()
    {
        // 结束并生成报告
        Extent.Flush();
    }
    
    
    public void makeBlocks(string envName, string chainid, int blockCount, int transactionCount, int logeventCount)
    {
        BlockDto BlockDto = new BlockDto()
        {
            EnvName = envName,
            Chainid = chainid,
            BlockCount = blockCount,
            TransactionCount = transactionCount,
            LogeventCount = logeventCount
        };
        
        string json = JsonConvert.SerializeObject(BlockDto);
        JObject jobj = JObject.Parse(json);
        
        HttpRequest.BaseUrl(DataServerUrl).ContentType("application/json")
            .Path(MakeBlockPath).Params(jobj).QuickExec();
        Thread.Sleep(5000);
    }
    
    public void initEnv(string envName)
    {
        JObject jobj = JObject.Parse("{\"envName\":\""+ TestEnvName + "\"}");
        HttpRequest.BaseUrl(DataServerUrl).Path(InitEnvPath + "?envName=" + TestEnvName).HttpMethod("get").ContentType("application/x-www-form-urlencoded").Params("{\"envName\":\""+ TestEnvName + "\"}")
            .QuickExec();
        Thread.Sleep(5000);
    }
    
    public void initReport()
    {
        // 创建 ExtentHtmlReporter 并配置
        // string reportPath = "/Users/lianqingdong/Desktop/Code/report/NUnitTestReport.html";
        string reportPath = "NUnitTestReport.html";

        htmlReporter = new ExtentHtmlReporter(reportPath);
        htmlReporter.Config.DocumentTitle = "Test Execution Report";
        htmlReporter.Config.ReportName = "Extent Report for tests";

        // 创建 ExtentReports 实例
        Extent = new ExtentReports();
        Extent.AttachReporter(htmlReporter);

        // 可以在这里配置全局的 Extent 报告属性
        Extent.AddSystemInfo("Environment", "QA");
        Extent.AddSystemInfo("User", "Scott");
        // ext = new ExtentReports();
    }
}
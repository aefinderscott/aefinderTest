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
        Console.WriteLine("-----++++++++++++++");
        //初始化环境
        initEnv("test001");
        
        //批量初始化数据
        makeBlocks("test001","tDVV",100,1,1);

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
    
    // public void InitTest(Type type)
    // {
    //     string fullname = TestContext.CurrentContext.Test.FullName;
    //     string name = TestContext.CurrentContext.Test.Name;
    //     if (fullname.IndexOf("(") > 0)
    //     {
    //         fullname = fullname.Substring(0, fullname.IndexOf("("));
    //         name = fullname.Split(".")[fullname.Split(".").Length - 1];
    //     }
    //     
    //     if (TestReport.ContainsKey(fullname))
    //     {
    //         test = TestReport[fullname];
    //     }
    //     else
    //     {
    //         MethodInfo methodInfo = type.GetMethod(name);
    //         // Console.WriteLine(method.Name);
    //         // 获取方法上的 Description 特性
    //         var descriptionAttribute = methodInfo?.GetCustomAttribute<DescriptionAttribute>();
    //         
    //         string description = descriptionAttribute?.Properties.Get("Description").ToString() ?? "No description provided";
    //         test = GlobalSetUpFixture.Extent.CreateTest(fullname, description);
    //         TestReport[fullname] = test;
    //     }
    // }
    
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
        // json =
        //     "{\"envName\":\"test001\",\"chainid\":\"tDVV\",\"blockCount\":10,\"transactionCount\":2,\"logeventCount\":3}";
        JObject jobj = JObject.Parse(json);

        // HttpTools.HttpPostJsonRequestJson("http://192.168.71.14:6555", "/api/datamanager/makeBlocks", json);

        HttpRequest.BaseUrl("http://192.168.71.14:6555").ContentType("application/json")
            .Path("/api/datamanager/makeBlocks").Params(jobj).QuickExec();
        Thread.Sleep(5000);
    }
    
    public void initEnv(string envName)
    {
        JObject jobj = JObject.Parse("{\"envName\":\"test001\"}");
        // HttpRequest.BaseUrl("http://192.168.71.14:6555").ContentType("application/json")
        //     .Path("/api/envmanager/init").Params(jobj).QuickExec();
        HttpRequest.BaseUrl("http://192.168.71.14:6555").Path("/api/envmanager/init?envName=test001").HttpMethod("get").ContentType("application/x-www-form-urlencoded").Params("{\"envName\":\"test001\"}")
            .QuickExec();
        Thread.Sleep(5000);
    }
    
    public void initReport()
    {
        // 创建 ExtentHtmlReporter 并配置
        // string reportPath = "/Users/lianqingdong/Desktop/Code/report/NUnitTestReport.html";
        string reportPath = "NUnitTestReport.html";

        Console.WriteLine("12345678910111213");
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
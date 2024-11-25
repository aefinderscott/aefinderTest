using System.Reflection;

namespace CaseOne;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

[SetUpFixture]
public class GlobalSetUpFixture
{
    public static ExtentReports Extent;
    private ExtentHtmlReporter htmlReporter;

    private static ExtentTest test;
    // 静态成员在应用程序启动时自动创建
    // private static ExtentReports ext;// = new GlobalExtentReport();
    
    public static Dictionary<string, ExtentTest?>? TestReport = new Dictionary<string, ExtentTest?>();

    // addReport(string methodName, string mess)
    // {
    //         
    // }
    // public static void initTest(string name)
    // {
    //     new GlobalSetUpFixture().InitTes(name);
    // }

    public void InitTes(Type type)
    {
        // string fullname = TestContext.CurrentContext.Test.FullName;
        
        
        string fullname = TestContext.CurrentContext.Test.FullName;
        string name = TestContext.CurrentContext.Test.Name;
        if (fullname.IndexOf("(") > 0)
        {
            fullname = fullname.Substring(0, fullname.IndexOf("("));
            name = fullname.Split(".")[fullname.Split(".").Length - 1];
        }
        
        Console.WriteLine("000000" + fullname);
        Console.WriteLine("000000" + name);
        
        if (TestReport.ContainsKey(fullname))
        {
            test = TestReport[fullname];
        }
        else
        {
            // string methodName = name.Split(".")[name.Split(".").Length - 1];
            // var method = GetType().GetMethod(name);
            // // string temname = TestContext.CurrentContext.Test.FullName;
            // // if (temname.IndexOf("(") > 0)
            // // {
            // //     temname = temname.Substring(0, temname.IndexOf("("));
            // // }
            // // Console.WriteLine("00000" + temname);
            // // Console.WriteLine("00000" + temname.Split(".")[temname.Split(".").Length - 1]);
            // Console.WriteLine("111111111111111111" + TestContext.CurrentContext.Test.Name);
            // Console.WriteLine("222222222222222222" + TestContext.CurrentContext.Test.FullName);
            
            MethodInfo methodInfo = type.GetMethod(name);
            // Console.WriteLine(method.Name);
            // 获取方法上的 Description 特性
            var descriptionAttribute = methodInfo?.GetCustomAttribute<DescriptionAttribute>();

            Console.WriteLine("=========" + descriptionAttribute?.Properties.ToString());
            
            string description = descriptionAttribute?.Properties.Get("Description").ToString() ?? "No description provided";
            Console.WriteLine("=========" + description);
            test = GlobalSetUpFixture.Extent.CreateTest(fullname, description);
            TestReport[fullname] = test;
        }
    }
    
    
    // 全局初始化：所有测试类运行之前
    //1、定义测试报告 2、环境初始化 3、数据初始化
    [OneTimeSetUp]
    public void GlobalSetup()
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

    // 全局结束：所有测试类运行完毕之后
    [OneTimeTearDown]
    public void GlobalTeardown()
    {
        // 结束并生成报告
        Extent.Flush();
    }
}
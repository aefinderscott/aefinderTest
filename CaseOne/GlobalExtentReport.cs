using System.Reflection;

namespace CasesOne;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

[SetUpFixture]
public class GlobalExtentReport
{
    public static ExtentReports Extent;
    private ExtentHtmlReporter htmlReporter;

    private static ExtentTest test;
    // 静态成员在应用程序启动时自动创建
    // private static ExtentReports ext;// = new GlobalExtentReport();
    
    public static Dictionary<string, ExtentTest?>? ages = new Dictionary<string, ExtentTest>();

    // addReport(string methodName, string mess)
    // {
    //         
    // }
    public static void initTest(string name)
    {
        new GlobalExtentReport().initTes(name);
    }

    public void initTes(string name)
    {
        if (ages.ContainsKey(name))
        {
            test = ages[name];
        }
        else
        {
            string methodName = name.Split(".")[name.Split(".").Length - 1];
            Console.WriteLine("+++++++++___________" + methodName);
            var method = GetType().GetMethod(methodName);

            // 获取方法上的 Description 特性
            var descriptionAttribute = method?.GetCustomAttribute<DescriptionAttribute>();

            string description = descriptionAttribute?.Properties.Get("Description").ToString() ?? "No description provided";

            
            test = GlobalExtentReport.Extent.CreateTest(name, description);
            ages[name] = test;
        }
        
    }
    
    
    // 全局初始化：所有测试类运行之前
    [OneTimeSetUp]
    public void GlobalSetup()
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
        Extent.AddSystemInfo("User", "Tester");
        
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
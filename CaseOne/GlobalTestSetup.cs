// using System.Reflection;
// using AventStack.ExtentReports;
// using AventStack.ExtentReports.Reporter;
// using NUnit.Framework.Interfaces;
//
// namespace CasesOne;
//
// using NUnit.Framework;
//
// [SetUpFixture]
// public class GlobalTestSetup
// {
//     private static ExtentReports _extent;
//     // private ExtentTest _test;
//     
//     [OneTimeSetUp]
//     public void RunBeforeAnyTests()
//     {
//         TestContext.WriteLine("9999999999999.");
//
//         var htmlReporter = new ExtentHtmlReporter("/Users/lianqingdong/Desktop/Code/report/NUnitTestReport.html");
//         _extent = new ExtentReports();
//         _extent.AttachReporter(htmlReporter);
//         // 全局初始化代码
//         TestContext.WriteLine("Global Test Setup: Runs once before all tests in the namespace.");
//     }
//
//     [OneTimeTearDown]
//     public void RunAfterAllTests()
//     {
//         _extent.Flush();
//         // 全局清理代码
//         TestContext.WriteLine("Global Test Teardown: Runs once after all tests in the namespace.");
//     }
//     
//     
//     // [SetUp]
//     // public void SetUp()
//     // {
//     //     // // 使用反射获取当前测试方法的信息
//     //     // MethodBase currentMethod = typeof(CalculatorTests).GetMethod(TestContext.CurrentContext.Test.MethodName);
//     //     //
//     //     // // 从方法中获取 Description 特性
//     //     // var descriptionAttribute = currentMethod.GetCustomAttribute<DescriptionAttribute>();
//     //     //
//     //     // // 输出 Description，如果存在的话
//     //     // if (descriptionAttribute != null)
//     //     // {
//     //     //     Console.WriteLine($"Description: {descriptionAttribute.Description}");
//     //     // }
//     //     // else
//     //     // {
//     //     //     Console.WriteLine("No Description attribute found.");
//     //     // }
//     //     
//     //     
//     //     
//     //     
//     //     // 使用反射获取当前测试方法上的 Description 属性
//     //     var currentMethod = MethodBase.GetCurrentMethod().DeclaringType.GetMethod(TestContext.CurrentContext.Test.MethodName);
//     //     var descriptionAttribute = currentMethod.GetCustomAttribute<DescriptionAttribute>();
//     //     // descriptionAttribute.
//     //     string description = descriptionAttribute?.Properties.Get("Description").ToString() ?? "No description provided";
//     //
//     //     // 在 Extent Reports 中创建测试并添加描述
//     //     _test = _extent.CreateTest(TestContext.CurrentContext.Test.FullName)
//     //         .Info(description);
//     //     
//     //     // 初始化代码，每个测试方法之前调用
//     //     // _calculator = new Calculator();
//     //     // _httpTools = new HttpTools();
//     //     
//     //     // _client = new RestClient("https://jsonplaceholder.typicode.com");
//     // }
//     //
//     // [TearDown]
//     // public void TearDown()
//     // {
//     //     // 清理代码，每个测试方法之后调用
//     //     // _calculator = null;
//     //     // _httpTools = null;
//     //     
//     //     
//     //     var status = TestContext.CurrentContext.Result.Outcome.Status;
//     //     var stacktrace = TestContext.CurrentContext.Result.StackTrace;
//     //     var errorMessage = TestContext.CurrentContext.Result.Message;
//     //
//     //     if (status == TestStatus.Failed)
//     //     {
//     //         _test.Log(Status.Fail, "Test failed." + errorMessage);
//     //     }
//     //
//     //     _extent.Flush();
//     // }
//     
//     // [OneTimeTearDown]
//     // public void CloseReport()
//     // {
//     //     _extent.Flush();
//     // }
// }
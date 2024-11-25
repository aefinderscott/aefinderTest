// using System.Reflection;
// using AeIndexerTester;
// // using AventStack.ExtentReports;
// // using AventStack.ExtentReports.Reporter;
// // using RestSharp;
// // using NUnit.Framework;
// // using NUnit.Framework.Interfaces;
// using System;
// using System.Reflection;
// using AventStack.ExtentReports;
// using AventStack.ExtentReports.Reporter;
// using NUnit.Framework;
// using NUnit.Framework.Interfaces;
//

using AeIndexerTester;

namespace CaseOne
{
    [TestFixture]
// [Description("法")]
    public class VersionTest : BaseTestSetup
    {
        private HttpTools _httpTools;

        [SetUp]
        public void Setup()
        {
            Type type = typeof(VersionTest);

            // // Get the method info using reflection
            // MethodInfo methodInfo = type.GetMethod(TestContext.CurrentContext.Test.Name);
            // // type.FullName;
            // Console.WriteLine(type.FullName);
            // Console.WriteLine(methodInfo.Name);
            SetUpBeforeEachTest(typeof(VersionTest));
            _httpTools = new HttpTools();
        }

        // [Test]
        // [Description("version-正向")]
        // public void DemoTest()
        // {
        //     var result = _httpTools.RestTest();
        //
        //     // Assert.AreEqual()
        //     Assert.IsNotNull(result["access_token"]);
        //     string rs = result["token_type"].ToString();
        //     Assert.AreEqual("", "",
        //         ""); //.AreEqual("Bearer1", rs, "The actual value did not match the expected value.");
        //     // Assert.AreEqual("35991", result["expires_in"].ToString(), "The actual value did not match the expected value.");
        // }

        // [Test]
        // [Description("version-正向")]
        // public void TestVersion()
        // {
        //     var result = _httpTools.RestTest();
        //
        //     // Assert.AreEqual()
        //     Assert.IsNotNull(result["access_token"]);
        //     string rs = result["token_type"].ToString();
        //     Assert.AreEqual("", "",
        //         ""); //.AreEqual("Bearer1", rs, "The actual value did not match the expected value.");
        //     // Assert.AreEqual("35991", result["expires_in"].ToString(), "The actual value did not match the expected value.");
        // }
        //
        // [Test]
        // [Description("version-不存在")]
        // public void TestVersion001()
        // {
        //     
        // }

        [Test]
        [Description("version-替换")]
        public void TestVersion002()
        {
            Assert.AreEqual(1,1);
        }

        [TearDown]
        public void TearDown()
        {
            TearDownAfterEachTest(typeof(VersionTest));
            // base.TearDownAfterEachTest();
            // 清理代码，每个测试方法之后调用
            _httpTools = null;

        }
    }
}

// {
//     
// [TestFixture]
// // [Description("法")]
// public class Test112 : BaseTestSetup
// {
//     private Calculator _calculator;
//     private HttpTools _httpTools;
//     // private RestClient _client;
//     
//     
//     private ExtentTest test;
//     
//     [SetUp]
//     public void Setup()
//     {
//         
//         
//         // ExtentTest test = GlobalExtentReport.Extent.CreateTest(TestContext.CurrentContext.Test.ClassName + "." + TestContext.CurrentContext.Test.Name);
//         GetTestMethodDescription(GlobalExtentReport.Extent.CreateTest(TestContext.CurrentContext.Test.ClassName + "." + TestContext.CurrentContext.Test.Name));
//
//         _calculator = new Calculator();
//         _httpTools = new HttpTools();
//     }
//
//     // [SetUp]
//     // public void SetupBeforeEachTest()
//     // {
//     //     SetupBase();
//     //     // base.SetupBeforeEachTest();
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
//     //     // // 使用反射获取当前测试方法上的 Description 属性
//     //     // var currentMethod = MethodBase.GetCurrentMethod().DeclaringType.GetMethod(TestContext.CurrentContext.Test.MethodName);
//     //     // var descriptionAttribute = currentMethod.GetCustomAttribute<DescriptionAttribute>();
//     //     // // descriptionAttribute.
//     //     // string description = descriptionAttribute?.Properties.Get("Description").ToString() ?? "No description provided";
//     //     //
//     //     // // 在 Extent Reports 中创建测试并添加描述
//     //     // _test = _extent.CreateTest(TestContext.CurrentContext.Test.FullName)
//     //     //     .Info(description);
//     //     
//     //     // 初始化代码，每个测试方法之前调用
//     //     _calculator = new Calculator();
//     //     _httpTools = new HttpTools();
//     //     
//     //     TestContext.WriteLine("setup3.");
//     //     
//     //     // _client = new RestClient("https://jsonplaceholder.typicode.com");
//     // }
//
//     [Test]
//     [Description("测试获取token")]
//     public void TestConnectToken123()
//     {
//         var result = _httpTools.RestTest();
//         
//         // Assert.AreEqual()
//         Assert.IsNotNull(result["access_token"]);
//         string rs = result["token_type"].ToString();
//         Assert.AreEqual("","","");//.AreEqual("Bearer1", rs, "The actual value did not match the expected value.");
//         // Assert.AreEqual("35991", result["expires_in"].ToString(), "The actual value did not match the expected value.");
//     }
//
//     // [Test]
//     // public async Task GetTodos_ShouldReturnSuccess()
//     // {
//     //     // 创建请求
//     //     var request = new RestRequest("todos/1", Method.Get);
//     //
//     //     // 执行请求并等待响应
//     //     var response = await _client.ExecuteAsync(request);
//     //
//     //     // 验证请求是否成功
//     //     Assert.IsTrue(response.IsSuccessful, "请求未成功");
//     //
//     //     // 检查响应内容
//     //     Assert.IsNotNull(response.Content, "响应内容为空");
//     // }
//
//     // [Test]
//     // public async Task TestAsyncMethod()
//     // {
//     //     await DemoTest RunAsyncTask();
//     //     Assert.IsTrue(true); // 示例断言
//     // }
//     
//     [Test]
//     [Description("测试登录-正向")]
//     public void TestLogin001111()
//     {
//         _httpTools.RestTest();
//         // Arrange
//         int a = 5;
//         int b = 7;
//
//         // Act
//         int result = _calculator.Add(a, b);
//
//         // Assert
//         Assert.AreEqual(121, result);
//     }
//
//     [Test]
//     [Description("测试登录-用户名异常")]
//     public void TestLogin002111()
//     {
//         // Arrange
//         int a = 10;
//         int b = 4;
//
//         // Act
//         int result = _calculator.Subtract(a, b);
//
//         // Assert
//         Assert.AreEqual(6, result);
//     }
//
//     [TearDown]
//     public void TearDownAfterEachTest()
//     {
//         // base.TearDownAfterEachTest();
//         // 清理代码，每个测试方法之后调用
//         _calculator = null;
//         _httpTools = null;
//         
//         
//         TestDelegate11(test);
//     
//         
//         // var status = TestContext.CurrentContext.Result.Outcome.Status;
//         // var stacktrace = TestContext.CurrentContext.Result.StackTrace;
//         // var errorMessage = TestContext.CurrentContext.Result.Message;
//         //
//         // if (status == TestStatus.Failed)
//         // {
//         //     test.Log(Status.Fail, "Test failed." + errorMessage);
//         // }
//         //
//         // _extent.Flush();
//     }
//     
//     // [OneTimeTearDown]
//     // public void CloseReport()
//     // {
//     //     _extent.Flush();
//     // }
// }
// }

using System.Reflection;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace CasesOne;

using NUnit.Framework;

public class BaseTestSetup
{
    

    public void TearDownAfterEachTest(string name)
    {
        
        // GlobalExtentReport.Extent
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stacktrace = TestContext.CurrentContext.Result.StackTrace;
        var errorMessage = TestContext.CurrentContext.Result.Message;
        //
        if (status == TestStatus.Failed)
        {
            // ExtentTest test = GlobalExtentReport.Extent.CreateTest(name);
            GlobalExtentReport.ages[name].Log(Status.Fail, "Test failed." + errorMessage);
        }
        else
        {
            GlobalExtentReport.ages[name].Log(Status.Pass, "Test success.");
        }
    }
    
    public void SetUpBeforeEachTest(string testName)
    {
        GlobalExtentReport.initTest(testName);
        
    }
    public void SetupBase()
    {
        // 获取当前正在执行的测试方法
        var methodName = TestContext.CurrentContext.Test.MethodName;
    
        // 通过反射获取方法上的 Description 属性
        MethodInfo method = GetType().GetMethod(methodName);
        var descriptionAttribute = method?.GetCustomAttribute<DescriptionAttribute>();
    
        string description = descriptionAttribute?.Properties.Get("Description").ToString() ?? "No description provided";
    
        
        // 如果该方法有 Description 属性，写入测试报告；否则提示没有描述。
        if (descriptionAttribute != null)
        {
            
            TestContext.WriteLine($"Description for {methodName}: {description}");
        }
        else
        {
            TestContext.WriteLine($"Description for {methodName}: No description found.");
        }
    }
    
    // [SetUp]
    // public void SetUp()
    // {
    //     
    //     TestContext.WriteLine("setup1.");
    //
    //     // 使用反射获取当前测试方法上的 Description 属性
    //     var currentMethod = MethodBase.GetCurrentMethod().DeclaringType.GetMethod(TestContext.CurrentContext.Test.MethodName);
    //     var descriptionAttribute = currentMethod.GetCustomAttribute<DescriptionAttribute>();
    //     // descriptionAttribute.
    //     string description = descriptionAttribute?.Properties.Get("Description").ToString() ?? "No description provided";
    //
    //     // 在 Extent Reports 中创建测试并添加描述
    //     _test = _extent.CreateTest(TestContext.CurrentContext.Test.FullName)
    //         .Info(description);
    //     
    //     
    // }
    
    // [TearDown]
    // public virtual void TearDownAfterEachTest()
    // {
    //     var status = TestContext.CurrentContext.Result.Outcome.Status;
    //     var stacktrace = TestContext.CurrentContext.Result.StackTrace;
    //     var errorMessage = TestContext.CurrentContext.Result.Message;
    //
    //     if (status == TestStatus.Failed)
    //     {
    //         _test.Log(Status.Fail, "Test failed." + errorMessage);
    //     }
    //
    //     
    // }
    
    // [TearDown]
    // public void TearDown()
    // {
    //     
    //     var status = TestContext.CurrentContext.Result.Outcome.Status;
    //     var stacktrace = TestContext.CurrentContext.Result.StackTrace;
    //     var errorMessage = TestContext.CurrentContext.Result.Message;
    //
    //     if (status == TestStatus.Failed)
    //     {
    //         _test.Log(Status.Fail, "Test failed." + errorMessage);
    //     }
    //
    //     _extent.Flush();
    // }
}
//
// [TestFixture]
// public class TestClass1 : BaseTestSetup
// {
//     [Test]
//     public void TestMethod1()
//     {
//         Assert.Pass("Test 1");
//     }
// }
//
// [TestFixture]
// public class TestClass2 : BaseTestSetup
// {
//     [Test]
//     public void TestMethod2()
//     {
//         Assert.Pass("Test 2");
//     }
// }
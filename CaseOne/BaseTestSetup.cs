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
   
}
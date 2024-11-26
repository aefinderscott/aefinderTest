using System.Reflection;
using AeIndexerTester;
using AventStack.ExtentReports;
using Newtonsoft.Json;
using NUnit.Framework.Interfaces;

namespace CaseOne;

using NUnit.Framework;

//一个test管控
public class BaseTestSetup
{
    // public static ExtentReports Extent;
    // private ExtentHtmlReporter htmlReporter;

    private static ExtentTest test;
    // 静态成员在应用程序启动时自动创建
    // private static ExtentReports ext;// = new GlobalExtentReport();
    
    public static Dictionary<string, ExtentTest?>? TestReport = new Dictionary<string, ExtentTest?>();

    protected OneCaseDto oneCaseDto;
    
    public void SetUpBeforeEachTest(Type type)
    {
        oneCaseDto = new OneCaseDto();
        InitTest(type);
    }
    
    public void TearDownAfterEachTest(Type type)
    {
        string fullname = TestContext.CurrentContext.Test.FullName;
        string name = TestContext.CurrentContext.Test.Name;
        if (fullname.IndexOf("(") > 0)
        {
            fullname = fullname.Substring(0, fullname.IndexOf("("));
            name = fullname.Split(".")[fullname.Split(".").Length - 1];
        }

        // GlobalExtentReport.Extent
        // string name = TestContext.CurrentContext.Test.FullName;
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stacktrace = TestContext.CurrentContext.Result.StackTrace;
        var errorMessage = TestContext.CurrentContext.Result.Message;
        //
        if (status == TestStatus.Failed)
        {
            // ExtentTest test = GlobalExtentReport.Extent.CreateTest(name);
            TestReport[fullname].Log(Status.Fail, "Test failed." + errorMessage);
        }
        else
        {
            TestReport[fullname].Log(Status.Pass, "Test success.");
        }

        oneCaseDto = null;
    }
    
    public void InitTest(Type type)
    {
        string fullname = TestContext.CurrentContext.Test.FullName;
        string name = TestContext.CurrentContext.Test.Name;
        if (fullname.IndexOf("(") > 0)
        {
            fullname = fullname.Substring(0, fullname.IndexOf("("));
            name = fullname.Split(".")[fullname.Split(".").Length - 1];
        }
        
        if (TestReport.ContainsKey(fullname))
        {
            test = TestReport[fullname];
        }
        else
        {
            MethodInfo methodInfo = type.GetMethod(name);
            // Console.WriteLine(method.Name);
            // 获取方法上的 Description 特性
            var descriptionAttribute = methodInfo?.GetCustomAttribute<DescriptionAttribute>();
            
            string description = descriptionAttribute?.Properties.Get("Description").ToString() ?? "No description provided";
            test = GlobalSetUpFixture.Extent.CreateTest(fullname, description);
            TestReport[fullname] = test;
        }
    }
    
    public static IEnumerable<Object[]?> GetDataProvider(string datafile)
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        baseDir = Environment.CurrentDirectory;
        string projectDir = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;
        string srcFolderPath = Path.Combine(projectDir, "CaseOne") + "/";
        var configFilePath = srcFolderPath + "CaseDescription/Data";
        var filePath = Path.Combine(configFilePath, datafile);
        var jsonData = File.ReadAllText(filePath);
            
        var testDataList = JsonConvert.DeserializeObject<List<List<DataProviderObj>>>(jsonData);
        foreach (var testDatas in testDataList)
        {
            Dictionary<int, DataProviderObj> dictionary = new Dictionary<int, DataProviderObj>();
            foreach (var testData in testDatas)
            {
                dictionary[testData.StepNo] = testData;
            }
            yield return new object[] { dictionary };
            //JObject assertJsonObject = JObject.Parse(testData.Asserts.ToString());
            //yield return new object[] { testData.Params, assertJsonObject };
        }
            
    }
   
}


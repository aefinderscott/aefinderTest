using System.Reflection;
using AeIndexerTester;
using AventStack.ExtentReports;
using DataManager.Controllers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Interfaces;

namespace CaseOne;

using NUnit.Framework;

public class BaseTestSetup
{


    protected OneCaseDto oneCaseDto;
    public void TearDownAfterEachTest(Type type)
    {
        string fullname = TestContext.CurrentContext.Test.FullName;
        string name = TestContext.CurrentContext.Test.Name;
        if (fullname.IndexOf("(") > 0)
        {
            fullname = fullname.Substring(0, fullname.IndexOf("("));
            name = fullname.Split(".")[fullname.Split(".").Length - 1];
        }
        
        Console.WriteLine("11111" + fullname);
        Console.WriteLine("11111" + name);

        // GlobalExtentReport.Extent
        // string name = TestContext.CurrentContext.Test.FullName;
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stacktrace = TestContext.CurrentContext.Result.StackTrace;
        var errorMessage = TestContext.CurrentContext.Result.Message;
        //
        if (status == TestStatus.Failed)
        {
            // ExtentTest test = GlobalExtentReport.Extent.CreateTest(name);
            GlobalSetUpFixture.TestReport[fullname].Log(Status.Fail, "Test failed." + errorMessage);
        }
        else
        {
            GlobalSetUpFixture.TestReport[fullname].Log(Status.Pass, "Test success.");
        }

        oneCaseDto = null;
    }
    
    public void SetUpBeforeEachTest(Type type)
    {
        // Console.WriteLine("00000");
        // Console.WriteLine(TestContext.CurrentContext.Test.Name);
        // Console.WriteLine("00000");
        oneCaseDto = new OneCaseDto();
        // GlobalSetUpFixture.initTest(testName);
        new GlobalSetUpFixture().InitTes(type);
    }
    
    public void SetUpBeforeEachTest11(Type type)
    {
        Console.WriteLine("00000");
        Console.WriteLine(TestContext.CurrentContext.Test.Name);
        Console.WriteLine("00000");
        oneCaseDto = new OneCaseDto();
        
        MethodInfo methodInfo = type.GetMethod(TestContext.CurrentContext.Test.Name);
        // type.FullName;
        Console.WriteLine(type.FullName);
        Console.WriteLine(methodInfo.Name);
        
        
        var descriptionAttribute = methodInfo?.GetCustomAttribute<DescriptionAttribute>();

        Console.WriteLine("=========" + descriptionAttribute?.Properties.ToString());
            
        string description = descriptionAttribute?.Properties.Get("Description").ToString() ?? "No description provided";
        Console.WriteLine("=========" + description);
        
        
        
        // if (methodInfo != null)
        // {
        //     // Get the Description attribute from the method
        //     var attributes = methodInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        //
        //     if (attributes.Length > 0)
        //     {
        //         // Assuming there's only one DescriptionAttribute
        //         DescriptionAttribute description = (DescriptionAttribute)attributes[0];
        //         Console.WriteLine("Method Description: " + description.Description);
        //     }
        //     else
        //     {
        //         Console.WriteLine("The method does not have a Description attribute.");
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("Method not found.");
        // }
        
        
        // GlobalSetUpFixture.initTest(testName);
        
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
        
        HttpTools.HttpPostJsonRequestJson("http://192.168.71.13:6555", "/api/datamanager/makeBlocks", json);

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


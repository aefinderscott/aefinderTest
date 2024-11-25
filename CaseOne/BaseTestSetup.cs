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
            GlobalSetUpFixture.TestReport[name].Log(Status.Fail, "Test failed." + errorMessage);
        }
        else
        {
            GlobalSetUpFixture.TestReport[name].Log(Status.Pass, "Test success.");
        }

        oneCaseDto = null;
    }
    
    public void SetUpBeforeEachTest(string testName)
    {
        oneCaseDto = new OneCaseDto();
        GlobalSetUpFixture.initTest(testName);
        
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


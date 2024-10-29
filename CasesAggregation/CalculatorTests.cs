using AeIndexerTester;
using RestSharp;
using NUnit.Framework;


namespace CasesAggregation;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calculator;
    private HttpTools _httpTools;
    // private RestClient _client;

    [SetUp]
    public void SetUp()
    {
        // 初始化代码，每个测试方法之前调用
        _calculator = new Calculator();
        _httpTools = new HttpTools();
        
        // _client = new RestClient("https://jsonplaceholder.typicode.com");
    }

    [Test]
    public void resttestcase()
    {
        var result = _httpTools.RestTest();
        
        // Assert.AreEqual()
        Assert.IsNotNull(result["access_token"]);
        string rs = result["token_type"].ToString();
        Assert.AreEqual("","","");//.AreEqual("Bearer1", rs, "The actual value did not match the expected value.");
        Assert.AreEqual("35991", result["expires_in"].ToString(), "The actual value did not match the expected value.");
    }

    // [Test]
    // public async Task GetTodos_ShouldReturnSuccess()
    // {
    //     // 创建请求
    //     var request = new RestRequest("todos/1", Method.Get);
    //
    //     // 执行请求并等待响应
    //     var response = await _client.ExecuteAsync(request);
    //
    //     // 验证请求是否成功
    //     Assert.IsTrue(response.IsSuccessful, "请求未成功");
    //
    //     // 检查响应内容
    //     Assert.IsNotNull(response.Content, "响应内容为空");
    // }

    // [Test]
    // public async Task TestAsyncMethod()
    // {
    //     await DemoTest RunAsyncTask();
    //     Assert.IsTrue(true); // 示例断言
    // }
    
    [Test]
    public void Add_ShouldReturnSum_WhenGivenTwoIntegers()
    {
        _httpTools.RestTest();
        // Arrange
        int a = 5;
        int b = 7;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.AreEqual(12, result);
    }

    [Test]
    public void Subtract_ShouldReturnDifference_WhenGivenTwoIntegers()
    {
        // Arrange
        int a = 10;
        int b = 4;

        // Act
        int result = _calculator.Subtract(a, b);

        // Assert
        Assert.AreEqual(6, result);
    }

    [TearDown]
    public void TearDown()
    {
        // 清理代码，每个测试方法之后调用
        _calculator = null;
        _httpTools = null;
    }
}
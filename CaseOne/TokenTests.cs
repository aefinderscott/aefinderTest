using AeIndexerTester;
using AventStack.ExtentReports;

namespace CaseOne
{
    [TestFixture]
    // [Description("法")]
    public class TokenTests : BaseTestSetup
    {
        private HttpTools _httpTools;

        [SetUp]
        public void Setup()
        {
            SetUpBeforeEachTest(TestContext.CurrentContext.Test.FullName);
            _httpTools = new HttpTools();
        }


        [Test]
        [Description("测试获取token")]
        public void TestConnectToken()
        {
            var result = _httpTools.RestTest();
            
            // Assert.AreEqual()
            Assert.IsNotNull(result["access_token"]);
            string rs = result["token_type"].ToString();
            Assert.AreEqual("","","");//.AreEqual("Bearer1", rs, "The actual value did not match the expected value.");
            // Assert.AreEqual("35991", result["expires_in"].ToString(), "The actual value did not match the expected value.");
        }
        
        [Test]
        [Description("测试登录-正向")]
        public void TestLogin001()
        {
            
        }

        [Test]
        [Description("测试登录-用户名异常")]
        public void TestLogin002()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            TearDownAfterEachTest(TestContext.CurrentContext.Test.FullName);
            // base.TearDownAfterEachTest();
            // 清理代码，每个测试方法之后调用
            _httpTools = null;
            
        }
    }
}

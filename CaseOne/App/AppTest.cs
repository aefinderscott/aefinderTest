using AeIndexerTester;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CaseOne.App
{
    [TestFixture]
    public class AppTestTests : BaseTestSetup
    {
    
        [SetUp]
        public void Setup()
        {
            SetUpBeforeEachTest(typeof(AppTestTests));
            //makeBlocks("test001","tDVV",1,1,1);
        }
        
        [Test]
        [Description( "创建app-正向")]
        public void testAppCreate_Test()
        {
            JObject param = new JObject();
            
            //request
            param = JObject.Parse("{\"username\": \"admin\",\"password\": \"1q2W3e*\",\"client_id\": \"AeFinder_App\",\"grant_type\": \"password\",\"scope\": \"AeFinder\"}");
            JObject result1 = HttpRequest.BaseUrl("http://192.168.71.156:8082").Path("/api/users/info")
                                                    .ContentType("application/x-www-form-urlencoded")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result1.SelectToken("$.error"));
            Assert.IsNotNull(result1.SelectToken("$.error_description"));
            
            //request
            param = JObject.Parse("{\"appName\": \"atest01\"}");
            JObject result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/apps")
                                                    .ContentType("application/json")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.AreEqual("admin", result2.SelectToken("$.userName").ToString());
        }
        
        [Test]
        [Description( "创建app，auth验证")]
        public void testAppCreateErrorAuth_Test()
        {
            JObject param = new JObject();
            
            //request
            param = JObject.Parse("{\"appName\": \"atest01\"}");
            JObject result1 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/users/info")
                                                    .ContentType("application/json")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result1.SelectToken("$.error"));
        }
        
        [Test]
        [Description( "app详情-正向")]
        public void testAppInfo_Test()
        {
            JObject param = new JObject();
            
            //request
            param = JObject.Parse("{\"username\": \"admin\",\"password\": \"1q2W3e*\",\"client_id\": \"AeFinder_App\",\"grant_type\": \"password\",\"scope\": \"AeFinder\"}");
            JObject result1 = HttpRequest.BaseUrl("http://192.168.71.156:8082").Path("/api/users/info")
                                                    .ContentType("application/x-www-form-urlencoded")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result1.SelectToken("$.error"));
            Assert.IsNotNull(result1.SelectToken("$.error_description"));
            
            //request
            param = JObject.Parse("{\"appName\": \"atest01\"}");
            JObject result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/apps")
                                                    .ContentType("application/json")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.AreEqual("admin", result2.SelectToken("$.userName").ToString());
        }
        
        [Test]
        [Description( "app列表-正向")]
        public void testAppList_Test()
        {
            JObject param = new JObject();
            
            //request
            param = JObject.Parse("{\"username\": \"admin\",\"password\": \"1q2W3e*\",\"client_id\": \"AeFinder_App\",\"grant_type\": \"password\",\"scope\": \"AeFinder\"}");
            JObject result1 = HttpRequest.BaseUrl("http://192.168.71.156:8082").Path("/api/users/info")
                                                    .ContentType("application/x-www-form-urlencoded")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result1.SelectToken("$.error"));
            Assert.IsNotNull(result1.SelectToken("$.error_description"));
            
            //request
            param = JObject.Parse("{\"appName\": \"atest01\"}");
            JObject result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/apps")
                                                    .ContentType("application/json")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.AreEqual("admin", result2.SelectToken("$.userName").ToString());
        }
        
        [TearDown]
        public void TearDown()
        {
            TearDownAfterEachTest(typeof(AppTestTests));
        }
    }
}
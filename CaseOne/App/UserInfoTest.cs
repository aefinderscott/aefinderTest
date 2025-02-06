using AeIndexerTester;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CaseOne.App
{
    [TestFixture]
    public class UserInfoTestTests : BaseTestSetup
    {
    
        [SetUp]
        public void Setup()
        {
            SetUpBeforeEachTest(typeof(UserInfoTestTests));
            //makeBlocks("test001","tDVV",1,1,1);
        }
        
        [Test]
        [Description( "获取用户信息-正向")]
        public void testUserInfo_Test()
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
            param = JObject.Parse("{\"displayName\": \"tnet00\"}");
            JObject result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/users/info")
                                                    .ContentType("application/json")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.AreEqual("admin", result2.SelectToken("$.userName").ToString());
        }
        
        [Test]
        [Description( "创建组织")]
        public void testUserInfoErrorAuth_Test()
        {
            JObject param = new JObject();
            
            //request
            param = JObject.Parse("{\"displayName\": \"tnet00\"}");
            JObject result1 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/users/info")
                                                    .ContentType("application/json")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result1.SelectToken("$.error"));
        }
        
        [TearDown]
        public void TearDown()
        {
            TearDownAfterEachTest(typeof(UserInfoTestTests));
        }
    }
}